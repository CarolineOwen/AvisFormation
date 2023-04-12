using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Formation
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string NomSeo { get; set; }
        public string Description { get; set; }
        public List<Avis> Avis { get; set; }
    }
}
