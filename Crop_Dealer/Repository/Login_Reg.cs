using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public class Login_Reg : ILogin_Reg
    {
        CropDealContext _context;
        public Login_Reg(CropDealContext context)
        {
            _context = context;
        }

        public string AddDealer(Dealer dealer)
        {
            try
            {
                string email = dealer.DealerEmail;
                if (_context.Dealers.Any(a => a.DealerEmail == email))
                {
                    string error = "Dealer already exist";
                    return error;
                }
                _context.Dealers.Add(dealer);
                _context.SaveChanges();
                return "Dealer Added Successfully";
            }
            catch (Exception ex)
            {
                return "Not Able To Add Dealer Retry";
            }
        }

        public string AddFarmer(Farmer farmer)
        {
            try
            {
                string email = farmer.FarmerEmail;
                if (_context.Farmers.Any(a => a.FarmerEmail == email))
                {
                    string error = "Farmer already exist";
                    return error;
                }
                _context.Farmers.Add(farmer);
                _context.SaveChanges();
                return "Farmer Added Successfully";
            }
            catch (Exception ex)
            {
                return "Not Able To Add Farmer Retry";
            }
        }

        public Admin AdminLogin(string email, string password)
        {
            return _context.Admins.FirstOrDefault(l => l.Email == email && l.Password == password);
        }

        public Dealer DealerLogin(string email, string password)
        {
            return _context.Dealers.FirstOrDefault(l => l.DealerEmail == email && l.Password == password);
        }

        public Farmer FarmerLogin(string email, string password)
        {
            return _context.Farmers.Where(l => l.FarmerEmail.Equals(email) && l.Password.Equals(password)).FirstOrDefault();
        }
    }
}
