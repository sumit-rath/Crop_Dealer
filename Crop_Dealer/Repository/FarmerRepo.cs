using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public class FarmerRepo : IFarmerRepo
    {
        CropDealContext _context;
        public FarmerRepo(CropDealContext context)
        {
            _context = context;
        }

        public string AddDetails(BankDetail bankDetail)
        {
            try
            {

                _context.BankDetails.Add(bankDetail);
                _context.SaveChanges();
                return "Bank Details Added Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EditDetails(BankDetail bankDetail)
        {
            try
            {
                if (_context.BankDetails.Any(b => b.FarmerEmail.Equals(bankDetail.FarmerEmail)))
                {
                    _context.BankDetails.Update(bankDetail);
                    _context.SaveChanges();
                    return "Bank Details Updated Successfully";
                }
                return "Bank Details Not Found With This Mail Id";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BankDetail GetBankDetail(int id)
        {
            var temp = _context.Farmers.FirstOrDefault(e => e.FarmerId == id);
            return _context.BankDetails.FirstOrDefault(b => b.FarmerEmail.Equals(temp.FarmerEmail));
        }

        public Farmer GetFarmerDetails(int id)
        {
            return _context.Farmers.FirstOrDefault(a => a.FarmerId == id);
        }


        public string NewDetails(Farmer details)
        {
            try
            {
                if (_context.Farmers.Any(f => f.FarmerId.Equals(details.FarmerId)))
                {
                    _context.Farmers.Update(details);
                    _context.SaveChanges();
                    return "Farmer Updated Successfully";
                }
                return "Farmer Id Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Crop> ViewCrop(int id)
        {
            var tempfarmer = _context.Farmers.FirstOrDefault(f => f.FarmerId == id);
            try
            {
                List<Crop> result = new List<Crop>();
                result = _context.Crops.Where(c => c.FarmerEmail.Equals(tempfarmer.FarmerEmail)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Crop>();
            }

        }
    }
}
