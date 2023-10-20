using Crop_Dealer.Model;
using Crop_Dealer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Crop_Dealer.Services
{
    public class FarmerServices
    {

        ILogin_Reg login_Reg;
        IInvoiceRepo invoiceRepo;
        IFarmerRepo farmerRepo;
        ICropRepository cropsRepo;
        public FarmerServices(ICropRepository cropRepository, ILogin_Reg login_Reg, IInvoiceRepo invoiceRepo, IFarmerRepo farmerRepo)
        {
            this.cropsRepo = cropRepository;
           
            this.login_Reg = login_Reg;
            this.invoiceRepo = invoiceRepo;
            this.farmerRepo = farmerRepo;
        }

        #region registraion

        public string AddFarmerService(Model.Farmer farmer)
        {
            string result = login_Reg.AddFarmer(farmer);
            return result;
        }
        #endregion
        #region Add crop

        public string AddCropService(Model.Crop crop, int farmerid)
        {
            string result = cropsRepo.AddCrop(crop, farmerid);
            return result;
        }
        #endregion
        #region delete crop

        public string DeleteCropService(int id)
        {
            string result = cropsRepo.DeleteCrop(id);
            return result;
        }
        #endregion
        #region ViewCrops
        public List<Crop> ViewCropService(int farmerId)
        {

            List<Crop> result = farmerRepo.ViewCrop(farmerId);
            return result;
        }
        #endregion
        #region Add bank details

        public string AddBankDetailsService(BankDetail bankdetails)
        {
            string result = farmerRepo.AddDetails(bankdetails);
            return result;
        }
        #endregion
        #region Edit bank details

        public string EditBankDetailsService(BankDetail bankdetails)
        {
            string result = farmerRepo.EditDetails(bankdetails);
            return result;
        }
        #endregion
        #region Edit profile
        public string EditProfileService(Farmer farmer)
        {
            string result = farmerRepo.NewDetails(farmer);
            return result;
        }
        #endregion
        #region Invoice

        public List<Invoice> ViewFarmerInvoiceService(int farmerId)
        {
            List<Invoice> result = invoiceRepo.GetFarmerInvoice(farmerId);
            return result;
        }
        #endregion
        #region Get bank details

        public BankDetail GetBankDetailService(int farmerId)
        {
            BankDetail result = farmerRepo.GetBankDetail(farmerId);
            return result;
        }
        #endregion
        #region Get profile
        public Farmer GetFarmerDetailsService(int farmerId)
        {
            Farmer result = farmerRepo.GetFarmerDetails(farmerId);
            return result;
        }
        #endregion
    }
}
