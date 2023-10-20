using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public interface IInvoiceRepo
    {
        List<Invoice> GetFarmerInvoice(int id);
        List<Invoice> GetDealerInvoice(int id);
        List<Invoice> GetAllInvoices();
        string DeleteInvoice(int id);
    }
}
