using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace TestTaskWebApplication.Services
{
    public interface IMailService
    {
        Task SendAsync(IdentityMessage message);
        Task SendTemplateMessageAsync(string to, string templatePath, object model, bool isBodyHtml = false);
    }
}