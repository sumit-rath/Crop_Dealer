using Crop_Dealer.Model;
using Crop_Dealer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Crop_Dealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly FarmerServices _farmerServices;
        private ILogger<FarmerController> _logger;
        public FarmerController(FarmerServices farmerServices,ILogger<FarmerController> logger)
        {
           _farmerServices = farmerServices;
            _logger = logger;
        }
        
        #region registraion
        [HttpPost("Farmer_Registration")]
        [AllowAnonymous]
        public ActionResult AddFarmer(Model.Farmer farmer)
        {
            string result = _farmerServices.AddFarmerService(farmer);
            _logger.LogInformation("Registering Farmer");
            if(result == "Farmer Added Successfully")
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            _logger.LogError(result);
            return Content(result);
        }
        #endregion
        #region Add crop
        [HttpPost("Add_Crop")]
        [Authorize(Roles ="Farmer,Admin")]
        public ActionResult AddCrop(Model.Crop crop)
        {
            var farmerclaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int farmerid = int.Parse(farmerclaim.Value);
            string result= _farmerServices.AddCropService(crop,farmerid);
            _logger.LogInformation("Adding Crops");
            if(result== "Crop Added Successfully")
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            _logger.LogError(result);
            return Content(result);
        }
        #endregion
        #region delete crop
        [HttpDelete("Delete_Crop")]
        [Authorize(Roles = "Farmer,Admin")]
        public ActionResult DeleteCrop(int id)
        {
            string result = _farmerServices.DeleteCropService(id);
            _logger.LogInformation("Deleting Crop");
            if (result == "Deleted Successfully")
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            _logger.LogError(result);
            return Content(result);
        }
        #endregion
        #region ViewCrops
        [HttpGet("View_Crop")]
        [Authorize(Roles = "Farmer")]
        public IActionResult ViewCrop()
        {
            var farmerclaimId= HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int farmerId = int.Parse(farmerclaimId.Value);
            List<Crop> result = _farmerServices.ViewCropService(farmerId);
            _logger.LogInformation("Fetching Crops");
            if (result.Count>0)
            {
                return Ok(result);
            }
            _logger.LogError("Error No Crop Found Retry");
            return Content("No Crops By This Farmer Id");
        }
        #endregion
        #region Add bank details
        [HttpPost("Bank_Details")]
        [AllowAnonymous]
        public IActionResult AddBankDetails(Model.BankDetail bankdetails)
        {
            string result = _farmerServices.AddBankDetailsService(bankdetails);
            _logger.LogInformation("Adding Bank Details Of Farmer");
            if(result== "Bank Details Added Successfully")
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            _logger.LogError("Error not able to add bank details");
            return Content(result);
        }
        #endregion
        #region Edit bank details
        [HttpPut("Edit_Bank_Details")]
        [Authorize(Roles ="Farmer")]
        public IActionResult EditBankDetails(BankDetail bankdetails)
        {
            string result = _farmerServices.EditBankDetailsService(bankdetails);
            _logger.LogInformation("Editing Bank Details");
            if (result == "Bank Details Updated Successfully")
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            _logger.LogError(result);
            return Content(result);
        }
        #endregion
        #region Edit profile
        [HttpPut("Edit_Farmer_Profile")]
        [Authorize(Roles = "Farmer")]
        public ActionResult EditProfile(Farmer farmer)
        {
            string result = _farmerServices.EditProfileService(farmer);
            _logger.LogInformation("Editing Farmer Profile");
            if (result == "Farmer Updated Successfully")
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            _logger.LogError(result);
            return Content(result);
        }
        #endregion
        #region Invoice
        [HttpGet("View_Farmer_Invoice")]
        [Authorize(Roles = "Farmer")]
        public IActionResult ViewFarmerInvoice()
        {
            var farmerclaimId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int farmerId = int.Parse(farmerclaimId.Value);
            List<Invoice> result = _farmerServices.ViewFarmerInvoiceService(farmerId);
            _logger.LogInformation("Fetching Farmer Invoices");
            if (result.Count > 0)
            {
                return Ok(result);
            }
            _logger.LogError("Error No Invoice Found Retry");
            return Content("No Invoice By This Farmer Id");
        }
        #endregion
        #region View Bank Details
        [HttpGet("View_Bank_Details")]
        [Authorize(Roles = "Farmer")]
        public IActionResult ViewBankDetails()
        {
            var farmerclaimId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int farmerId = int.Parse(farmerclaimId.Value);
            BankDetail result = _farmerServices.GetBankDetailService(farmerId);
            _logger.LogInformation("View Bank Details");
            if (result!=null)
            {
                _logger.LogInformation("Bank Details Found");
                return Ok(result);
            }
            _logger.LogError("Error");
            return StatusCode(405);//bank detail not found
        }
        #endregion
        #region View Profile
        [HttpGet("View_Profile")]
        [Authorize(Roles = "Farmer")]
        public IActionResult ViewProfile()
        {
            var farmerclaimId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int farmerId = int.Parse(farmerclaimId.Value);
            Farmer result = _farmerServices.GetFarmerDetailsService(farmerId);
            _logger.LogInformation("View Farmer Details");
            if (result != null)
            {
                
                _logger.LogInformation("Farmer Details Found");
                return Ok(result);
            }
            _logger.LogError("Error");
            return StatusCode(405);//detail not found
        }
        #endregion
    }
}
//If the id can go to frontend edit crop table by removing farmeremail and add farmerid
//remove rating from farmer table