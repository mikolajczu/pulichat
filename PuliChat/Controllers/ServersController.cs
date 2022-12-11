using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Linq;
using System.Security.Claims;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PuliChat.DataAccessLayer.Repositories.Abstract;
using PuliChat.Entities;
using PuliChat.Entities.Models;
using PuliChat.Hubs;
using SkiaSharp;

namespace PuliChat.Controllers
{
    [Authorize]
    public class ServersController : Controller
    {
        private readonly IServerRepository _serverRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<ChatHub> _chat;

        public ServersController(IServerRepository serverRepository, 
            IMessageRepository messageRepository, 
            UserManager<ApplicationUser> userManager,
            IHubContext<ChatHub> chat)
        {
            _serverRepository = serverRepository;
            _userManager = userManager;
            _messageRepository = messageRepository;
            _chat = chat;
        }

        // GET: Servers
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var servers = await _serverRepository.GetAllAsync(user);
            return View(servers);
        }

        // GET: Servers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Created")] Server server)
        {
            byte[] file = new byte[1];
            if (Request.Form.Files.Count == 0)
            {
                file = System.IO.File.ReadAllBytes("Images/defaultServer.png");
                var ff = file.Length;
            }
            else
                foreach(var file1 in Request.Form.Files)
                {
                    MemoryStream ms1 = new MemoryStream();
                    file1.CopyTo(ms1);
                    file = ms1.ToArray();
                }

            using MemoryStream ms = new MemoryStream(file);
            using SKBitmap sourceBitmap = SKBitmap.Decode(ms);
            using SKBitmap scaledBitmap = sourceBitmap.Resize(new SKImageInfo(200, 200), SKFilterQuality.Medium);
            using SKImage image = SKImage.FromBitmap(scaledBitmap);
            using SKData data = image.Encode();

            server.ImageData = data.ToArray();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            await _serverRepository.SaveAsync(server, user);
            return RedirectToAction("ServerIndex", new { id = server.Id });
        }

        // GET: Servers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var server = await _serverRepository.GetByIdAsync(id.Value);
            if (server == null) return NotFound();

            return View(server);
        }

        // POST: Servers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Created")] Server server)
        {
            if (id != server.Id) return NotFound();

            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                server.ImageData = ms.ToArray();
            }

            await _serverRepository.SaveAsync(server);
            return RedirectToAction("ServerIndex", new { id = server.Id });
        }

        // GET: Servers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var server = await _serverRepository.GetByIdAsync(id.Value);
            if (server == null) return NotFound();

            return View(server);
        }

        // POST: Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Server server = await _serverRepository.GetByIdAsync(id);
            await _serverRepository.DeleteAsync(server);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Invite(int? id)
        {
            if (id == null) return NotFound();
            var server = await _serverRepository.GetByIdAsync(id.Value);
            if (server == null) return NotFound();

            return View(server);
        }

        [HttpPost, ActionName("Invite")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InviteConfirmed(int id)
        {
            Server server = await _serverRepository.GetByIdAsync(id);
            ApplicationUser user = await _userManager.GetUserAsync(User);
            await _serverRepository.SaveAsync(server, user);
            return RedirectToAction("ServerIndex", new { id = server.Id });
        }

        public async Task<IActionResult> LeaveServer(int? id)
        {
            if (id == null) return NotFound();
            var server = await _serverRepository.GetByIdAsync(id.Value);
            if (server == null) return NotFound();

            return View(server);
        }

        [HttpPost, ActionName("LeaveServer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveServerConfirmed(int id)
        {
            Server server = await _serverRepository.GetByIdAsync(id);
            ApplicationUser user = await _userManager.GetUserAsync(User);
            await _serverRepository.RemoveUser(server, user);
            return RedirectToAction("Index", "Home");
        }

        // GET: ServerIndex/5
        public async Task<IActionResult> ServerIndex(int? id)
        {
            if (id == null)
                return NotFound();

            Server server = await _serverRepository.GetByIdAsync(id.Value);
            if (server == null)
            {
                return NotFound();
            }
            string imageBase64Data = Convert.ToBase64String(server.ImageData);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = currentUser.UserName;
            ViewBag.Description = currentUser.Description;
            ViewBag.Image = Convert.ToBase64String(currentUser.Image);
            ViewBag.ImageDataUrl = imageDataURL;

            try
            {
                var userServer = currentUser.UsersServers.Where(x => x.ServerId == server.Id).First();
                
                if (userServer.Role == Role.OWNER || userServer.Role == Role.ADMIN)
                    return View("ServerIndexAdmin", server);
                else
                    return View("ServerIndexUser", server);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserServerPartial(int? serverId, string userId)
        {
            if (serverId == null || userId == null)
                return NotFound();

            var server = await _serverRepository.GetByIdAsync(serverId.Value);
            if (server == null)
                return NotFound();

            try
            {
                var user = server.Users.FirstOrDefault(x => x.Id == userId);
                return PartialView("_UserServerPartial", user);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult SetChannel(string data)
        {
            CookieOptions cookies = new CookieOptions();
            cookies.Expires = DateTime.Now.AddDays(1);
            string[] dataArr = data.Split(' ');
            //First is channel id then serverId

            Response.Cookies.Append("channelCookie" + dataArr[1], dataArr[0], cookies);
            return Ok();
        }
    }
}
