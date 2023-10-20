using Crop_Dealer.Model;
using Crop_Dealer.Repository;
using Crop_Dealer.Repository.AdminUser;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Dealer.Services
{
    public class AdminServices
    {
        IAllFarmer allFarmer;
        IAllDealer allDealer;
        IDeleteDealer deleteDealer;
        IDeleteFarmer deleteFarmer;
        IDeleteBankDetails deletebankdetails;
        IInvoiceRepo invoiceRepo;
        IAdminRepo adminRepo;
        public AdminServices(IInvoiceRepo invoiceRepo, IAdminRepo adminRepo ,IAllFarmer allFarmer, IAllDealer allDealer, IDeleteDealer deleteDealer,
            IDeleteFarmer deleteFarmer, IDeleteBankDetails deletebankdetails)
        {
            this.adminRepo= adminRepo;
            this.invoiceRepo = invoiceRepo;
            this.allFarmer = allFarmer;
            this.allDealer = allDealer;
            this.deleteDealer = deleteDealer;
            this.deleteFarmer = deleteFarmer;
            this.deletebankdetails = deletebankdetails;
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
