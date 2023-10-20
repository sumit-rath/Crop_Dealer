using Crop_Dealer.Model;

namespace Crop_Dealer.Repository
{
    public class CropRepository : ICropRepository
    {
        CropDealContext context;
        ISendEmail _SendEmail { get; set; }
        public CropRepository(CropDealContext context, ISendEmail sendEmail)
        {
            this.context = context;
            _SendEmail = sendEmail;
        }
        public string AddCrop(Crop crop, int farmerid)
        {
            try
            {
                var tempfarmer = context.Farmers.FirstOrDefault(f => f.FarmerId == farmerid);
                crop.FarmerEmail = tempfarmer.FarmerEmail;
                context.Crops.Add(crop);
                context.SaveChanges();
                var mails = context.Subscribes.Where(a => (a.CropName.ToLower()).Equals((crop.CropName).ToLower())).ToList();
                if (mails != null)
                {
                    string message = crop.CropName + " Available";
                    foreach (var mail in mails)
                    {
                        _SendEmail.CropNotify(mail.DealerEmail, "New Crop", message);
                    }
                }
                return "Crop Added Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string DeleteCrop(int id)
        {

            try
            {
                var temp = context.Crops.Find(id);
                if (temp != null)
                {
                    context.Crops.Remove(temp);
                    context.SaveChanges();
                    return "Deleted Successfully";
                }
                return "Crop Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
