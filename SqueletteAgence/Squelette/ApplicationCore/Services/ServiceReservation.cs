using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceReservation : Service<Reservation>, IServiceReservation
    {
        public ServiceReservation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double GetMontant(Client client)
        {
            return GetMany(r => r.ClientFK == client.Identifiant).SelectMany(r => r.Pack.Activites.Select(a => a.Prix)).Sum();
        }

        public int GetNbReser(Client client)
        {
            return GetMany(r=> r.ClientFK == client.Identifiant && r.DateReservation.Year == DateTime.Now.Year).Count();
        }
    }
}
