using System.ComponentModel.DataAnnotations;

namespace AvisFormation.Models
{
    public class LaisserUnAvisViewModel
    {
        
        public string Commentaire { get; set; }

        
        public string Nom { get; set; }
        
        public string Note { get; set; }
       
        public string IdFormation { get; set; }
        
        public string NomFormation { get; set; }
    }
}
