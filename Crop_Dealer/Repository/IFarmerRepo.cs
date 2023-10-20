using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public interface IFarmerRepo
    {
        List<Crop> ViewCrop(int id);
        string NewDetails(Farmer details);
        Farmer GetFarmerDetails(int id);
        string AddDetails(BankDetail bankDetail);
        string EditDetails(BankDetail bankDetail);
        BankDetail GetBankDetail(int id);
    }
}
