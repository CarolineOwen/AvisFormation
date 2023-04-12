namespace Data
{
    public interface IFormationRepository
    {
        List<Formation> GetAllFormations();
        Formation GetFormationById(int iIdFormation);

        List<Formation> GetFormations(int nombre);
    }
}