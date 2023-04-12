using System.ComponentModel.DataAnnotations;

namespace AvisFormation.Models
{
    public class EnvoieEmailViewModel
    {
        public string Nom { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        public string Message { get; set; }
    }
}
