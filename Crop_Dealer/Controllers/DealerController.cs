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
    public class DealerController : ControllerBase
    {
        private readonly DealerServices _services;
        private ILogger<DealerController> _logger;
        public DealerController(DealerServices services, ILogger<DealerController> logger)
        {
            _services = services;
            _logger = logger;
        }

        #region Registration
        [HttpPost("Dealer_Registration")]
        [AllowAnonymous]
        public ActionResult AddDealer(Model.Dealer dealer)
        {
            string result = _services.AddDealerService(dealer);
            _logger.LogInformation("Registering Dealer");
            if (result == "Dealer Added Successfully")
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            _logger.LogError(result);
            return Content(result);
        }
        #endregion
        #region Edit Profile
        [HttpPut("Edit_Dealer_Profile")]
        [Authorize(Roles ="Dealer")]
        public IActionResult EditProfile(Dealer dealer)
        {
            string result=_services.EditProfileService(dealer);
            _logger.LogInformation("Updating Dealer Profile");
            if(result== "Dealer Updated Successfully")
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            _logger.LogError(result);
            return Content(result);
        }
        #endregion
        #region Invoice
        [HttpGet("View_Dealer_Invoice")]
        [Authorize(Roles = "Dealer")]
        public IActionResult ViewDealerInvoice()
        {
            var dealerclaimId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int dealerId = int.Parse(dealerclaimId.Value);
            List<Invoice> result = _services.ViewDealerInvoiceService(dealerId);
            _logger.LogInformation("Fetching Dealer Invoices");
            if (result.Count > 0)
            {
                
                return Ok(result);
            }
            _logger.LogError("Error Invoice not Found");
            return Content("No Invoice By This Dealer Id ");
        }
        #endregion
        #region View Profile
        [HttpGet("View_Profile")]
        [Authorize(Roles = "Dealer")]
        public IActionResult ViewProfile()
        {
            var dealerclaimId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int dealerId = int.Parse(dealerclaimId.Value);
            Dealer result = _services.GetDealerDetailsService(dealerId);
            _logger.LogInformation("View Dealer Details");
            if (result != null)
            {
                _logger.LogInformation("Dealer Details Found");
                return Ok(result);
            }
            _logger.LogError("Error");
            return StatusCode(405);//detail not found
        }
        #endregion
        #region ViewAllCrops
        [HttpGet("View_All_Crops")]
        [Authorize(Roles ="Dealer,Admin")]
        public IActionResult AllCrops()
        {
            List<Crop> result = _services.AllCropsService();
            _logger.LogInformation("Fetching Available Crop");
            if (result.Count > 0)
            {
                return Ok(result);
            }
            _logger.LogError("Error Crops Not Found");
            return Content("No Crops");
        }
        #endregion
        #region BuyCrops
        [HttpPost("Buy_Crops")]
        [Authorize(Roles = "Dealer")]
        public IActionResult BuyCrops(BuyData buyData)
        {
            var dealerclaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int dealerid = int.Parse(dealerclaim.Value);
            Invoice generated=_services.BuyCropsService(buyData.Id,buyData.quantity,dealerid);
            _logger.LogInformation("Transction In process");
            if(generated!=null)
            {
                if(generated.InvoiceId==401)
                {
                    return StatusCode(425);//quantity not available
                }
                return Ok(generated);
            }
            _logger.LogError("Error Retry");
            return StatusCode(450);//unknown error
        }
        #endregion
        #region Subscribe
        [HttpPost("Subscribe_Crop")]
        [Authorize(Roles ="Dealer")]
        public IActionResult AddSub(string cropname)
        {
            var dealerclaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int dealerid = int.Parse(dealerclaim.Value);
            string result=_services.AddSubService(cropname, dealerid);
            _logger.LogInformation("Subscribing");
            if(result.Equals("Subscribed to " + cropname))
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            else if(result.Equals("Already subscribed"))
            {
                return Ok(result);
            }
            _logger.LogError("Not able to subscribe retry");
            return Content(result);
        }
        #endregion
        #region Unsubscribe
        [HttpDelete("Unsubscribe_Crop")]
        [Authorize(Roles = "Dealer")]
        public IActionResult UnSub(string cropname)
        {
            var dealerclaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int dealerid = int.Parse(dealerclaim.Value);
            string result = _services.UnSubService(cropname, dealerid);
            if (result.Equals("Unsubscribed " + cropname))
            {
                _logger.LogInformation(result);
                return Ok(result);
            }
            _logger.LogError("Unable to unsubscribe");
            return Content(result);
        }
        #endregion
        #region ViewSubCrops
        [HttpGet("View_Sub_Crops")]
        [Authorize(Roles = "Dealer")]
        public IActionResult SubCrops()
        {
            var dealerclaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int dealerid = int.Parse(dealerclaim.Value);
            List<Subscribe> result = _services.SubCropsService(dealerid);
            _logger.LogInformation("Fetching Subscribed Crop");
            if (result.Count > 0)
            {
                return Ok(result);
            }
            _logger.LogError("Error Crops Not Found");
            return StatusCode(405);//No subscription
        }
        #endregion
    }
}
