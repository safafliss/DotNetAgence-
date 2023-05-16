using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IServiceReservation:IService<Reservation>
    {
        public double GetMontant(Client client);
        public int GetNbReser(Client client);
    }
}
