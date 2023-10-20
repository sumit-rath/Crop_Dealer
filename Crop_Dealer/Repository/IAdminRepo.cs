using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public interface IAdminRepo
    {
        List<Dealer> GetAllDealers();
        List<Farmer> GetAllFarmers();
        string DeleteDealer(int id);
        string Deletefarmer(int id);
    }
}
