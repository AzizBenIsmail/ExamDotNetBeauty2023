using AM.Core.Domain;
using AM.Core.Interfaces;
using ExamDotNetAzizBenIsmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = AM.Core.Domain.Type;

namespace AM.Core.Services
{
    public class PrestationService : Service<Prestation>, IPrestationService
    {
        public IList<Prestation> Prestations { get; set; } //prop

        public PrestationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Prestations = GetAll();
        }

        public double GetBestPrestataire()
        {
            return (from p in Prestations
                    where p.PrestationType == Type.Coiffure
                    select p.Prix).Average();
        }
    }
}
