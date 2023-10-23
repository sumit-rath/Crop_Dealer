using Crop_Dealer.Model;
using Crop_Dealer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Dealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        private readonly AdminServices _adminServices;
        private ILogger<AdminController> _logger;
        public AdminController(AdminServices adminServices, ILogger<AdminController> logger)
        {
            _adminServices = adminServices;
            _logger = logger;
        }

        #region InvoiceAll
        [HttpGet("All_Invoice")]
        public IActionResult AllInvoice()
        {
            List<Invoice> result = _adminServices.AllInvoiceService();
            _logger.LogInformation("Getting All Invoices");
            if (result.Count > 0)
            {
                return Ok(result);
            }
            _logger.LogError("Invoice Not Found");
            return Content("No Invoice");
        }
        #endregion
        #region DeleteInvoice
        [HttpDelete("Delete_Invoice")]
        public IActionResult DeleteInvoices(int id)
        {
            string result = _adminServices.DeleteInvoicesService(id);
            
            if (result == "Deleted Successfully")
            {
                _logger.LogInformation($"{result}");
                return Ok(result);
            }
            _logger.LogError("Error while deleting");
            return Content(result);
        }
        #endregion
        #region ViewFarmers
        [HttpGet("All_Farmers")]
        public IActionResult AllFarmers()
        {
            List<Farmer> result = _adminServices.AllFarmersService();
            _logger.LogInformation("Getting All Registered Farmer");
            if (result.Count > 0)
            {
                return Ok(result);
            }
            _logger.LogError("Not able to find farmers");
            return Content("No Farmer");
        }
        #endregion
        #region ViewDealers
        [HttpGet("All_Dealers")]
        public IActionResult AllDealers()
        {
            List<Dealer> result = _adminServices.AllDealersService();
            _logger.LogInformation("Getting All Registered Dealer");
            if (result.Count > 0)
            {
                return Ok(result);
            }
            _logger.LogError("Not able to find Dealer");
            return Content("No Dealer");
        }
        #endregion
        #region DeleteFarmers
        [HttpDelete("Delete_Farmer")]
        public IActionResult DeleteFarmers(int id)
        {
            string result = _adminServices.DeleteFarmersService(id);
            if (result == "Deleted Successfully")
            {
                _logger.LogInformation($"{nameof(DeleteFarmers)}");
                return Ok(result);
            }
            _logger.LogError("Not able to delete farmer");
            return Content(result);
        }
        #endregion
        #region DeleteDealers
        [HttpDelete("Delete_Dealer")]
        public IActionResult DeleteDealers(int id)
        {
            string result = _adminServices.DeleteDealersService(id);
            if (result == "Deleted Successfully")
            {
                _logger.LogInformation($"{result}");
                return Ok(result);
            }
            _logger.LogError("Not able to delete dealer");
            return Content(result);
        }
        #endregion
    }
}
//https://localhost:7085/api/
