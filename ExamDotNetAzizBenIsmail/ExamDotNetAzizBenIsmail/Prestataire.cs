using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Prestataire
    {
        [Range(0,5)]
        public int Note { get; set; }

        public string PageInstagram { get; set; }

        public int PrestataireId { get; set; }

        public string PrestataireNom { get; set; }

        public int PrestataireTel { get; set; }

        public Zone zone { get; set; }

        public virtual IList<Prestation> MyPrestation { get; set; }
    }
}
