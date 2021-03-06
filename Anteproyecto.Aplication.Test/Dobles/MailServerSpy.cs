using Anteproyecto.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Aplication.Test.Dobles
{
    class MailServerSpy : IMailServer
    {
        public string Email { get; private set; }
        public int CantidadLlamadas { get; private set; }

        public MailServerSpy()
        {
            CantidadLlamadas = 0;
        }
        public void Send(string v, string email)
        {
            CantidadLlamadas++;
            Email = email;
            Console.WriteLine("Se enviar el email");
        }

        public async Task Send(string email, string subject, string body)
        {
            await Task.CompletedTask;
        }

    }
}
