using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuliChat.DataAccessLayer.Repositories.Abstract;
using PuliChat.DataAccessLayer.Repositories.Concrete;
using PuliChat.Entities;
using PuliChat.Entities.Models;

namespace PuliChat.Controllers
{
    public class ChannelsController : Controller
    {
        private readonly IChannelRepository _channelRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChannelsController(IChannelRepository channelRepository, UserManager<ApplicationUser> userManager)
        {
            _channelRepository = channelRepository;
            _userManager = userManager;
        }

        // GET: Channels/Create
        public IActionResult Create(int ServerId)
        {
            ViewData["ServerId"] = ServerId;
            return View();
        }

        // POST: Channels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ServerId")] Channel channel)
        {
            if (ModelState.IsValid)
            {
                await _channelRepository.SaveAsync(channel);
                return RedirectToAction("ServerIndex", "Servers", new { id = channel.ServerId });
            }
            return RedirectToAction("ServerIndex", "Servers", new { id = channel.ServerId });
        }

        // GET: Channels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var channel = await _channelRepository.GetByIdAsync(id.Value);
            if (channel == null) return NotFound();

            return View(channel);
        }

        // POST: Channels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Channel channel)
        {
            if (id != channel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _channelRepository.SaveAsync(channel);
                return RedirectToAction("ServerIndex", "Servers", new { id = channel.ServerId });
            }
            return RedirectToAction("ServerIndex", "Servers", new { id = channel.ServerId });
        }

        // GET: Channels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var channel = await _channelRepository.GetByIdAsync(id.Value);
            if (channel == null) return NotFound();

            return View(channel);
        }

        // POST: Channels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Channel channel = await _channelRepository.GetByIdAsync(id);
            int Serverid = channel.ServerId;
            await _channelRepository.DeleteAsync(channel);
            return RedirectToAction("ServerIndex","Servers", new { id = Serverid });
        }

        [HttpGet]
        public async Task<IActionResult> ChannelMessagesPartial(int id)
        {
            var channel = await _channelRepository.GetByIdAsync(id);
            return PartialView("_channelMessagesPartial", channel);
        }
    }
}
