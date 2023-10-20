using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public class AdminRepo : IAdminRepo
    {
        CropDealContext _context;
        public AdminRepo(CropDealContext context)
        {
            _context = context;
        }
        

        public string DeleteDealer(int id)
        {
            try
            {
                var temp = _context.Dealers.Find(id);
                if (temp != null)
                {
                    _context.Dealers.Remove(temp);
                    _context.SaveChanges();
                    return "Deleted Successfully";
                }
                return "Dealer Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Deletefarmer(int id)
        {
            try
            {
                var temp = _context.Farmers.Find(id);
                var bank = _context.BankDetails.FirstOrDefault(a=>a.FarmerEmail.Equals(temp.FarmerEmail));
                if (temp != null&&bank !=null)
                {
                    _context.Farmers.Remove(temp);
                    _context.BankDetails.Remove(bank);
                    _context.SaveChanges();
                    return "Deleted Successfully";
                }
                return "Farmer Or Bank Detials Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Dealer> GetAllDealers()
        {
            try
            {
                return _context.Dealers.ToList();
            }
            catch
            {
                return new List<Dealer>();
            }
        }

        public List<Farmer> GetAllFarmers()
        {
            try
            {
                return _context.Farmers.ToList();
            }
            catch
            {
                return new List<Farmer>();
            }
        }
    }
}
