using EventPlanner360.Areas.Payment.Models;
using EventPlanner360.DAL.Payment;
using Microsoft.AspNetCore.Mvc;
using EventPlanner360.BAL;

namespace EventPlanner360.Areas.Payment.Controllers
{
    [CheckAccess]
    [Area("Payment")]
    [Route("Payment/[Controller]/[Action]")]
    public class PaymentController : Controller
    {
        public IConfiguration Configuration;
        public PaymentController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        PaymentDALBase paymentDALBase = new PaymentDALBase();

        #region Payment Successfull Screen
        public IActionResult PaymentSuccesfull()
        {
            return View();
        }
        #endregion

        #region Select By ID
        public IActionResult PaymentAdd(int PriceID)
        {
            PaymentModel paymentModel = paymentDALBase.PR_Payment_SelectByID(PriceID);
            if (paymentModel != null)
            {
                return View("PaymentPage", paymentModel);
            }
            else
            {
                return View("PaymentSuccesfull");
            }
        }
        #endregion


        #region Payment Save
        public IActionResult PaymentSave(PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                if (paymentDALBase.PaymentSave(paymentModel))

                    return RedirectToAction("PaymentSuccesfull");

            }
            return View("PaymentAdd");
        }
        #endregion

    }
}
