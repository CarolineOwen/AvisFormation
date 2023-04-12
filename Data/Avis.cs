using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Avis
    {
        public int id { get; set; }
        
        public string Commentaire { get; set; }
        public double Note { get; set; }
        
        public string NomUtilisateur { get; set; }
        public int FormationId { get; set; }
        public Formation Formation { get; set; }
    }
}
