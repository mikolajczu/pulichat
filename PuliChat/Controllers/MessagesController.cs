using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using PuliChat.DataAccessLayer.Repositories.Abstract;
using PuliChat.Entities;
using PuliChat.Entities.Models;

namespace PuliChat.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChannelRepository _channelRepository;
        private readonly IServerRepository _serverRepository;

        public MessagesController(IMessageRepository messageRepository, IChannelRepository channelRepository, IServerRepository serverRepository)
        {
            _messageRepository = messageRepository;
            _channelRepository = channelRepository;
            _serverRepository = serverRepository;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                await _messageRepository.SaveAsync(message);
                var channel = await _channelRepository.GetByIdAsync(message.ChannelId);
                var server = await _serverRepository.GetByIdAsync(channel.ServerId);
                var user = server.Users.Where(x => x.Id == message.UserId).First();
                var userServer = server.UsersServers.Where(x => x.UserId == message.UserId).First();
                var userRole = userServer.Role.ToString();
                var userImageB64S = Convert.ToBase64String(user.Image);
                string[] message1 = 
                { 
                    message.UserName, 
                    message.Created.ToString("dd/MM/yyyy HH:mm"), 
                    message.Text, 
                    userImageB64S, 
                    userRole,
                    message.ChannelId.ToString()
                };
                return Json(message1);
            }
            return Problem();
        }

        //// GET: Messages/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Messages == null)
        //    {
        //        return NotFound();
        //    }

        //    var message = await _context.Messages
        //        .Include(m => m.Channel)
        //        .Include(m => m.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (message == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(message);
        //}

        //// POST: Messages/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Messages == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Messages'  is null.");
        //    }
        //    var message = await _context.Messages.FindAsync(id);
        //    if (message != null)
        //    {
        //        _context.Messages.Remove(message);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
