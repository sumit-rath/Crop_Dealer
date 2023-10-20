using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public interface ICropRepository
    {
        string DeleteCrop(int id);
        string AddCrop(Crop crop, int farmerid);
    }
}
