using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePack : Service<Pack>, IServicePack
    {
        public ServicePack(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double GetPercentage()
        {
            //return GetMany(p => p.Duree>7).Average();
            return 0;
        }
    }
}
