using Crop_Dealer.Model;
using Crop_Dealer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Crop_Dealer.Services
{
    public class DealerServices
    {
        IDealerRepo dealerRepo;
        ILogin_Reg login_Reg;
        IInvoiceRepo invoiceRepo;
        public DealerServices(IDealerRepo dealerRepo, ILogin_Reg login_Reg, IInvoiceRepo invoiceRepo)
        {
            this.dealerRepo = dealerRepo;
            this.login_Reg = login_Reg;
            this.invoiceRepo = invoiceRepo;
        }

        #region Registration
        public string AddDealerService(Model.Dealer dealer)
        {
            string result = login_Reg.AddDealer(dealer);
            return result;
        }
        #endregion
        #region Edit Profile
        public string EditProfileService(Dealer dealer)
        {
            string result = dealerRepo.NewDetails(dealer);
            return result;
        }
        #endregion
        #region Invoice
        public List<Invoice> ViewDealerInvoiceService(int dealerId)
        {
            List<Invoice> result = invoiceRepo.GetDealerInvoice(dealerId);
            return result;
        }
        #endregion
        #region ViewAllCrops

        public List<Crop> AllCropsService()
        {
            List<Crop> result = dealerRepo.ViewCrop();
            return result;
        }
        #endregion
        #region BuyCrops

        public Invoice BuyCropsService(int cropId, double quantity, int dealerid)
        {

            Invoice generated = dealerRepo.InvoiceGenerate(cropId, dealerid, quantity);
            return generated;
        }
        #endregion
        #region Subscribe

        public string AddSubService(string cropname, int dealerid)
        {

            string result = dealerRepo.AddSubscription(cropname, dealerid);
            return result;
        }
        #endregion
        #region Unsubscribe
        public string UnSubService(string cropname, int dealerId)
        {
            string result = dealerRepo.deleteSubscription(cropname, dealerId);
            return result;
        }
        #endregion
        public Dealer GetDealerDetailsService(int id)
        {
            return dealerRepo.GetDealerDetails(id);
        }
        public List<Subscribe> SubCropsService(int id)
        {
            List<Subscribe> result = dealerRepo.GetAllSubs(id);
            return result;
        }
    }
}
