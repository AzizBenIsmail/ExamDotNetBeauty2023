using AM.Core.Domain;
using AM.Core.Interfaces;
using ExamDotNetAzizBenIsmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class PrestataireService : Service<Prestataire>, IPrestataireService 
    {
        public IList<Prestataire> Prestataires { get; set; } //prop

        public PrestataireService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Prestataires = GetAll();

        }

        public IList<Prestataire> GetBestPrestataire()
        {
            return (from p in Prestataires
                   where p.zone == Zone.Raoued
                   orderby p.Note descending
                   select p).Take(3).ToList();
        }
    }
}
