using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public interface ILogin_Reg
    {
        string AddFarmer(Farmer farmer);
        Farmer FarmerLogin(string email, string password);
        string AddDealer(Dealer dealer);
        Dealer DealerLogin(string email, string password);
        Admin AdminLogin(string email, string password);
    }
}
