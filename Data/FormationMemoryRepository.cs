using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FormationMemoryRepository : IFormationRepository
    {
        private List<Formation> _formations = new List<Formation>();

        public FormationMemoryRepository()
        {
            _formations.Add(new Formation { Id = 1, Nom = "Developpeur web", NomSeo = "Java", Description = "Creer un site web avec Java" });
            _formations.Add(new Formation { Id = 2, Nom = "Developpeur front", NomSeo = "React", Description = "Creer un site web avec React" });
            _formations.Add(new Formation { Id = 3, Nom = "Developpeur Wordpress", NomSeo = "Wordpress", Description = "Creer un site web avec Wordpress" });
        }
        public List<Formation> GetAllFormations()
        {
            return _formations;
        }

        public Formation GetFormationById(int iIdFormation)
        {
           return _formations.Where(f=>f.Id== iIdFormation).FirstOrDefault();
        }

        public List<Formation> GetFormations(int nombre)
        {
            return _formations.OrderBy(f => Guid.NewGuid()).Take(nombre).ToList();
        }
    }
}