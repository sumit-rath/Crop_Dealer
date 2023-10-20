using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public interface IDealerRepo
    {
        List<Crop> ViewCrop();
        string AddSubscription(string cropname, int dealerId);
        string deleteSubscription(string cropname, int dealerId);
        List<Subscribe> GetAllSubs(int id);
        Invoice InvoiceGenerate(int cropId, int dealerId, double quantity);
        string NewDetails(Dealer details);
        Dealer GetDealerDetails(int id);
    }
}
