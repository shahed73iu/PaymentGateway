using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentGatewayIBMS.PWGs;
using PaymentGatewayIPaymentGatewayIBMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayIPaymentGatewayIBMS.Controllers
{
  
    public class HomeController : Controller
    {
        string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("SslCommerz")]
        //[HttpPost("SslCommerz/{gatewayId}/{gatewayPass}/{enabledPayMethods}")]
        public IActionResult SslCommerz(string gatewayId, string gatewayPass, string enabledPayMethods, [FromBody] PaymentGatewayTransaction trans)
        {
            try
            {
                // CREATING LIST OF POST DATA
                NameValueCollection PostData = new NameValueCollection();

                decimal amount = trans.TotalAmount * (trans.ConvertionRate ?? 1);

                PostData.Add("total_amount", amount.ToString());
                PostData.Add("currency", "BDT");

                PostData.Add("tran_id", trans.TransId.ToString());
                PostData.Add("product_category", "education");

                PostData.Add("success_url", baseUrl + "SslCommerz/Success");
                PostData.Add("fail_url", baseUrl + "SslCommerz/Failed");
                PostData.Add("cancel_url", baseUrl + "SslCommerz/Cancel");
                PostData.Add("ipn_url", baseUrl + "SslCommerz/Ipn");

                PostData.Add("emi_option", trans.IsEnableEmi ? "1" : "0");
                PostData.Add("cus_name", String.IsNullOrEmpty(trans.CustomerName) ? "Anonymous " : trans.CustomerName);
                PostData.Add("cus_email", String.IsNullOrEmpty(trans.CustomerEmail) ? "info@projuktinext.com" : trans.CustomerEmail);
                PostData.Add("cus_add1", String.IsNullOrEmpty(trans.CustomerAdd1) ? "Address line one " : trans.CustomerAdd1);
                PostData.Add("cus_add2", String.IsNullOrEmpty(trans.CustomerAdd2) ? "Address line two " : trans.CustomerAdd2);
                PostData.Add("cus_city", String.IsNullOrEmpty(trans.CustomerCity) ? "Dhaka " : trans.CustomerCity);
                PostData.Add("cus_postcode", String.IsNullOrEmpty(trans.CustomerPostCode) ? "1200 " : trans.CustomerPostCode);
                PostData.Add("cus_country", String.IsNullOrEmpty(trans.CustomerCountry) ? "Bangladesh " : trans.CustomerCountry);
                PostData.Add("cus_phone", String.IsNullOrEmpty(trans.CustomerPhone) ? "01521200542" : trans.CustomerPhone);

                if (!String.IsNullOrEmpty(enabledPayMethods))
                {
                    PostData.Add("multi_card_name", enabledPayMethods);
                }

                PostData.Add("shipping_method", "NO");
                PostData.Add("num_of_item", "1");


                PostData.Add("product_name", "tution fee");
                PostData.Add("product_category", "fee");
                PostData.Add("product_profile", "non-physical-goods");

               // PostData.Add("value_a", requestedFrom);

               // SignIn(trans.TransId.ToString(), requestedFrom);

                PgwSslCommerz sslcz = new PgwSslCommerz(gatewayId, gatewayPass, !trans.IsLive);
                String response = sslcz.InitiateTransaction(PostData);

                _logger.LogInformation("START >> SSLCOMMERZ >> transId > " + trans.TransId);


                //Response.Redirect(response, false);
                return Ok(response);
                
            }
            catch (Exception ex)
            {
                _logger.LogInformation("transId > " + trans.TransId + " >  SSLCOMMERZ > " + ex.Message);

                Response.Redirect("~/Home/Unauthorised?err=invalid gateway parameters");
                return BadRequest(ex);
            }
        }
    }
}
