using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Prestation
    {
        public int PrestationId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set;}

        public string Intitule { get; set;}

        public Type PrestationType { get; set;}

        [DataType(DataType.Currency)]
        public Double Prix { get; set; }

        public virtual IList<RDV> RDVs { get; set; }

        [ForeignKey("PrestataireFK")]
        public virtual Prestataire MyPrestataire { get; set; }


        [Column("PrestataireFK")]
        public int? PrestataireFK { get; set; }

    }
}
