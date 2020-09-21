using Chat.API.Models.Message;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.API.Services.Interfaces
{
    public interface IMessagesService
    {
        Task<MessageVM> CreateAsync(CreateMessageVM model);
        Task<List<MessageVM>> GetAllAsync(int take, int skip);
        Task<MessageVM> UpdateAsync(int id, UpdateMessageVM model);
        Task<MessageVM> DeleteAsync(int id);
    }
}
