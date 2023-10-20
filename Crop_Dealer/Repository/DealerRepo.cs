using Crop_Dealer.Model;
using Microsoft.EntityFrameworkCore;

namespace Crop_Dealer.Repository
{
    public class DealerRepo : IDealerRepo
    {
        CropDealContext context;
        ISendEmail sendEmail;
        public DealerRepo(CropDealContext context, ISendEmail sendEmail)
        {
            this.context = context;
            this.sendEmail = sendEmail;
        }
        public string AddSubscription(string cropname, int dealerId)
        {
            try
            {
                var tempdealer = context.Dealers.FirstOrDefault(d => d.DealerId == dealerId);
                Subscribe subscribe = new Subscribe();
                subscribe.CropName = cropname;
                subscribe.DealerEmail = tempdealer.DealerEmail;
                subscribe.Subscribed = "Subscribed";
                if (context.Subscribes.Any(s => s.DealerEmail.Equals(subscribe.DealerEmail) && s.CropName.ToLower().Equals(subscribe.CropName.ToLower())))
                {
                    return "Already subscribed";
                }
                context.Subscribes.Add(subscribe);
                context.SaveChanges();
                return "Subscribed to " + cropname;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string deleteSubscription(string cropname, int dealerId)
        {
            try
            {
                var tempdealer = context.Dealers.FirstOrDefault(d => d.DealerId == dealerId);
                var tempsub = context.Subscribes.FirstOrDefault(s => s.CropName.Equals(cropname) && s.DealerEmail.Equals(tempdealer.DealerEmail));
                if (tempsub != null)
                {

                    context.Subscribes.Remove(tempsub);
                    context.SaveChanges();
                    return "Unsubscribed " + cropname;
                }
                return "Subscription Not Found";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public List<Subscribe> GetAllSubs(int id)
        {
            var tempdealer = context.Dealers.FirstOrDefault(f => f.DealerId == id);
            try
            {
                List<Subscribe> result = new List<Subscribe>();
                result = context.Subscribes.Where(c => c.DealerEmail.Equals(tempdealer.DealerEmail)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Subscribe>();
            }

        }

        public Invoice InvoiceGenerate(int cropId, int dealerId, double quantity)
        {
            Invoice result = new Invoice();
            BankDetail bankDetail = new BankDetail();
            try
            {
                var cropdetails = context.Crops.FirstOrDefault(c => c.CropId == cropId);
                if (cropdetails.Quatity < quantity)
                {
                    result.InvoiceId = 401;//Not sufficient quantity available
                    return result;
                }
                bankDetail = context.BankDetails.FirstOrDefault(b => b.FarmerEmail.Equals(cropdetails.FarmerEmail));
                var dealerdetails = context.Dealers.FirstOrDefault(d => d.DealerId == dealerId);
                double amount = cropdetails.PricePerKg * quantity;
                if (cropdetails != null && dealerdetails != null)
                {
                    result.Amount = amount;
                    result.Date = DateTime.Now;
                    result.FarmerEmail = cropdetails.FarmerEmail;
                    result.DealerEmail = dealerdetails.DealerEmail;
                    result.CropId = cropId;
                    sendEmail.InvoiceMail(cropdetails.FarmerEmail, "Farmer Invoice", result, quantity, bankDetail);
                    sendEmail.InvoiceMail(dealerdetails.DealerEmail, "Dealer Invoice", result, quantity, bankDetail);
                    context.Invoices.Add(result);
                    context.SaveChanges();
                }
                cropdetails.Quatity = cropdetails.Quatity - quantity;
                context.Crops.Update(cropdetails);
                context.SaveChanges();
                return result;
            }
            catch
            {
                return result;
            }
        }

        public List<Crop> ViewCrop()
        {
            return context.Crops.ToList();
        }

        public Dealer GetDealerDetails(int id)
        {
            return context.Dealers.FirstOrDefault(a => a.DealerId == id);
        }

        public string NewDetails(Dealer details)
        {
            try
            {
                if (context.Dealers.Any(f => f.DealerId.Equals(details.DealerId)))
                {
                    context.Dealers.Update(details);
                    context.SaveChanges();
                    return "Dealer Updated Successfully";
                }
                return "Dealer Id Not Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

