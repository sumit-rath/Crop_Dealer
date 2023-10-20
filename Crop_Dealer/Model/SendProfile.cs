using System.ComponentModel.DataAnnotations;

namespace Crop_Dealer.Model
{
    public class SendProfile
    {
        public string FarmerName { get; set; }
        public string FarmerEmail { get; set; }
        public long Contact { get; set; }
    }
}
