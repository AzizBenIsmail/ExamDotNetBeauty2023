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
    public interface IPrestationService : IService<Prestation>
    {
        public double GetBestPrestataire();

    }
}
