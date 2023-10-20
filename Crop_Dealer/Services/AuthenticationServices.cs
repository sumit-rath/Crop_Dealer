using Crop_Dealer.Model;
using Crop_Dealer.Repository;
using Crop_Dealer.Repository.AdminUser;
using Microsoft.Extensions.Configuration;

namespace Crop_Dealer.Services
{
    public class AuthenticationServices
    {
        private readonly ILogin_Reg login_Reg;
        public AuthenticationServices(ILogin_Reg login_Reg)
        {
            this.login_Reg = login_Reg;
        }
        public Farmer FarmerLoginService(string email, string password)
        {
            return login_Reg.FarmerLogin(email, password);
        }
        public Dealer DealerLoginService(string email, string password)
        {
            return login_Reg.DealerLogin(email, password);
        }
        public Admin AdminLoginService(string email, string password)
        {
            return login_Reg.AdminLogin(email, password);
        }
    }
}
