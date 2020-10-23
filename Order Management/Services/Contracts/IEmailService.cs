using System;
using System.Threading.Tasks;

namespace Order_Management.Services.Contracts
{
    public interface IEmailService
    {
        Task SendEmail(string receiverEmail, string subject, string content);
    }
}
