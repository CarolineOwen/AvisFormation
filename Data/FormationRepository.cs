using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FormationRepository : IFormationRepository
    {

        MonDbContext _context ;

       public FormationRepository(MonDbContext context)
        {
            this._context = context;
        }

        public List<Formation> GetAllFormations()
        {
            return _context.Formations.ToList();
        }

        public Formation GetFormationById(int iIdFormation)
        {
            return _context.Formations.Include("Avis").FirstOrDefault(f => f.Id == iIdFormation);
        }

        public List<Formation> GetFormations(int nombre)
        {
            return _context.Formations.OrderBy(qu => Guid.NewGuid()).Take(nombre).ToList();

        }

    }
}
