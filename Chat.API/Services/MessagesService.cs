using Chat.API.Models.Message;
using Chat.API.Models.ApplicationContext;
using Chat.API.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entities.Message;
using System;

namespace Chat.API.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly ApplicationContext _db;
        public MessagesService(ApplicationContext context)
        {
            _db = context;
        }

        public async Task<MessageVM> CreateAsync(CreateMessageVM model)
        {
            var message = new Message
            {
                UserId = model.UserId,
                Text = model.Text,
                CreatedAt = DateTime.Now,
                UserName = model.UserName
            };

            await _db.Messages.AddAsync(message);
            await _db.SaveChangesAsync();

            return new MessageVM
            {
                Id = message.Id,
                Text = message.Text,
                UserName = message.UserName,
                UserId = message.UserId,
                UpdatedAt = message.UpdatedAt,
                IsDeleted = message.IsDeleted
            };
        }

        public async Task<MessageVM> DeleteAsync(int id)
        {
            var message = await _db.Messages.FirstOrDefaultAsync(x => x.Id == id);

            if (message != null)
            {
                message.UpdatedAt = DateTime.Now;
                message.IsDeleted = true;

                await _db.SaveChangesAsync();

                return new MessageVM
                {
                    Id = message.Id,
                    Text = message.Text,
                    UserName = message.UserName,
                    UserId = message.UserId,
                    UpdatedAt = message.UpdatedAt,
                    IsDeleted = message.IsDeleted
                };
            }

            return null;
        }

        public Task<List<MessageVM>> GetAllAsync(int take, int skip)
        {
            take = take == 0 ? 10 : take;

            return _db.Messages.OrderByDescending(x => x.CreatedAt).Select(x => new MessageVM
            {
                Id = x.Id,
                Text = x.Text,
                UserId = x.UserId,
                UserName = x.UserName,
                UpdatedAt = x.UpdatedAt,
                IsDeleted = x.IsDeleted

            })?.Skip(skip)?.Take(take)?.ToListAsync();
        }

        public async Task<MessageVM> UpdateAsync(int id, UpdateMessageVM model)
        {
            var message = await _db.Messages.FirstOrDefaultAsync(x => x.Id == id);

            if (message != null)
            {
                message.Text = model.Text;
                message.UpdatedAt = DateTime.Now;

                await _db.SaveChangesAsync();

                return new MessageVM
                {
                    Id = message.Id,
                    Text = message.Text,
                    UserName = message.UserName,
                    UserId = message.UserId,
                    UpdatedAt = message.UpdatedAt,
                    IsDeleted = message.IsDeleted
                };
            }

            return null;
        }
    }
}
