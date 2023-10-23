using Crop_Dealer.Model;
using Crop_Dealer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Dealer.Services
{
    public class AdminServices
    {

        IInvoiceRepo invoiceRepo;
        IAdminRepo adminRepo;
        public AdminServices(IInvoiceRepo invoiceRepo, IAdminRepo adminRepo )
        {
            this.adminRepo= adminRepo;
            this.invoiceRepo = invoiceRepo;
        }

        #region InvoiceAll
        public List<Invoice> AllInvoiceService()
        {
            List<Invoice> result = invoiceRepo.GetAllInvoices();
            return result;
        }
        #endregion
        #region DeleteInvoice
        public string DeleteInvoicesService(int id)
        {
            string result = invoiceRepo.DeleteInvoice(id);
            return result;
        }
        #endregion
        #region ViewFarmers
        public List<Farmer> AllFarmersService()
        {
            List<Farmer> result = adminRepo.GetAllFarmers();
            return result;
        }
        #endregion
        #region ViewDealers
        public List<Dealer> AllDealersService()
        {
            List<Dealer> result = adminRepo.GetAllDealers();
            return result;
        }
        #endregion
        #region DeleteFarmers
        public string DeleteFarmersService(int id)
        {
            string result = adminRepo.Deletefarmer(id);
            return result;
        }
        #endregion
        #region DeleteDealers
        
        public string DeleteDealersService(int id)
        {
            string result = adminRepo.DeleteDealer(id);
            return result;
        }
        #endregion
    }
}
