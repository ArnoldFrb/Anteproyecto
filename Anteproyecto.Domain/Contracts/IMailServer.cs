using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteproyecto.Domain.Contracts
{
    public interface IMailServer
    {
        void Send(string v, string email);
    }
}
