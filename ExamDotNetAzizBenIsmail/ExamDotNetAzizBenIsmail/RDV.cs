using ExamDotNetAzizBenIsmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class RDV
    {
        public bool Confirmation { get; set; }

        public DateTime DateRDV { get; set; }

        public virtual Client MyClient { get; set; }
        public int ClientFK { get; set; }
        public virtual Prestation MyPrestation { get; set; }
        public int PrestationFK { get; set; }
    }
}
