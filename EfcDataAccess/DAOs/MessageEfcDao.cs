using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class MessageEfcDao : IMessageDao
{
    private readonly TodoContext context;

    public MessageEfcDao(TodoContext context)
    {
        this.context = context;
    }
    
    public async Task<AnswerMessage> CreateAsync(AnswerMessage message)
    {
        EntityEntry<AnswerMessage> added = await context.AnswerMessages.AddAsync(message);
        await context.SaveChangesAsync();
        return added.Entity;;
    }

    public async Task<AnswerMessage?> GetByIdAsync(int messageId)
    {
        AnswerMessage? message = await context.AnswerMessages.FindAsync(messageId);
        return message;
    }

    public async Task<IEnumerable<AnswerMessage>> GetByPostId(int postId)
    {
        var result = await context.AnswerMessages
            .Where(u => u.postOwnerid == postId)
            .ToListAsync();
        return result;
    }
}