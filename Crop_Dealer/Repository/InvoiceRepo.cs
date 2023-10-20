using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public class InvoiceRepo : IInvoiceRepo
    {
        CropDealContext _context;
        public InvoiceRepo(CropDealContext context)
        {
            _context = context;
        }

        public string DeleteInvoice(int id)
        {
            try
            {
                var temp = _context.Invoices.FirstOrDefault(i => i.InvoiceId == id);
                if (temp != null)
                {
                    _context.Invoices.Remove(temp);
                    _context.SaveChanges();
                    return "Deleted Successfully";
                }
                return "Invoice Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Invoice> GetAllInvoices()
        {
            try
            {
                return _context.Invoices.ToList();
            }
            catch
            {
                return new List<Invoice>();
            }
        }

        public List<Invoice> GetDealerInvoice(int id)
        {
            var tempdealer = _context.Dealers.FirstOrDefault(f => f.DealerId == id);
            try
            {
                List<Invoice> result = new List<Invoice>();
                result = _context.Invoices.Where(c => c.DealerEmail.Equals(tempdealer.DealerEmail)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Invoice>();
            }
        }

        public List<Invoice> GetFarmerInvoice(int id)
        {
            var tempfarmer = _context.Farmers.FirstOrDefault(f => f.FarmerId == id);
            try
            {
                List<Invoice> result = new List<Invoice>();
                result = _context.Invoices.Where(c => c.FarmerEmail.Equals(tempfarmer.FarmerEmail)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Invoice>();
            }
        }
    }
}
