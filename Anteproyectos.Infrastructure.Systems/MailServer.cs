using Anteproyecto.Domain.Contracts;
using System;
using System.Threading.Tasks;

namespace GestionProyectos.Infrastructure.Systems
{
    public class MailServer : IMailServer
    {
        
        Task IMailServer.Send(string email, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
