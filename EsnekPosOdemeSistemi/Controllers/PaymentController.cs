using EsnekPosOdemeSistemi.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using static EsnekPosOdemeSistemi.Models.PaymentRequest;

namespace EsnekPosOdemeSistemi.Controllers
{
    public class PaymentController : Controller
    {
        public ActionResult CreditCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreditCard(EYVCreditCard creditCard)
        {
            JsonDataModel dataModel = new JsonDataModel();

            try
            {
                using (var http = new HttpClient())
                {
                    PaymentRequest paymentRequest = new PaymentRequest
                    {
                        Config = new EYVConfig
                        {
                            MERCHANT = "MERCHANT",
                            MERCHANT_KEY = "MERCHANT_KEY",
                            BACK_URL = "http://localhost:60509/Payment/BackUrl",
                            PRICES_CURRENCY = "TRY",
                            ORDER_REF_NUMBER = "ORDER_REF_NUMBER",
                            ORDER_AMOUNT = creditCard.ORDER_AMOUNT
                        },
                        CreditCard = new EYVCreditCard()
                    };
                    paymentRequest.CreditCard.CC_OWNER = creditCard.CC_OWNER;
                    paymentRequest.CreditCard.CC_NUMBER = creditCard.CC_NUMBER.Replace(" ", "");
                    paymentRequest.CreditCard.EXP_MONTH = creditCard.EXP_MONTH;
                    paymentRequest.CreditCard.EXP_YEAR = creditCard.EXP_YEAR;
                    paymentRequest.CreditCard.CC_CVV = creditCard.CC_CVV;
                    paymentRequest.CreditCard.INSTALLMENT_NUMBER = "1";

                    paymentRequest.Customer = new EYVCustomer
                    {
                        FIRST_NAME = "Tanju",
                        LAST_NAME = "Bozok",
                        ADDRESS = "Muratpaşa",
                        MAIL = "tanjubozok@tanjubozok.com",
                        PHONE = "02422420707",
                        CITY = "Antalya",
                        STATE = "Muratpaşa"
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(paymentRequest));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var request = http.PostAsync("https://posservice.esnekpos.com/api/pay/EYV3DPay", content);

                    var response = request.Result.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<Result>(response);
                    if (result.STATUS == "SUCCESS" && result.RETURN_CODE == "0")
                    {
                        dataModel.Url = result.URL_3DS;
                        dataModel.Result = ResultType.Success;
                        dataModel.Message = result.RETURN_MESSAGE;
                        return Json(dataModel);
                    }
                    else
                    {
                        dataModel.Result = ResultType.Error;
                        dataModel.Message = result.RETURN_MESSAGE;
                        return Json(dataModel);
                    }
                }
            }
            catch (Exception)
            {
                dataModel.Result = ResultType.Error;
                dataModel.Message = "Exception...";
                return Json(dataModel);
            }
        }

        [HttpPost]
        public ActionResult Sms()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BackUrl(Result model)
        {
            if (model.STATUS == "SUCCESS" && model.RETURN_CODE == "0")
            {
                TempData["Message"] = model.RETURN_MESSAGE;
            }
            else
            {
                TempData["Message"] = model.RETURN_MESSAGE;
            }
            return View();
        }
    }
}