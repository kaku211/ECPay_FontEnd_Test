using ECPay.Payment.Integration;
using ECPay_FontEnd_Test.Models;
using ECPay_FontEnd_Test.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ECPay_FontEnd_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult xx()
        {
            //*MerchantID 商店代號
            ViewBag.MerchantID = "2000132";


            //*MerchantTradeNo 商店交易編號
            ViewBag.MerchantTradeNo = "acpay20130312153028";


            //*MerchantTradeDate 商店交易時間
            ViewBag.MerchantTradeDate = "2013/03/12 15:30:23";


            //*PaymentType 交易類型
            ViewBag.PaymentType = "aio";


            //*TotalAmount 交易金額
            ViewBag.TotalAmount = 1000;


            //*TradeDesc 交易描述
            ViewBag.TradeDesc = "促銷方案";


            //*ItemName 商品名稱
            ViewBag.ItemName = "Apple iphone 7 手機殼";


            //*ReturnURL 付款完成通知回傳網址
            ViewBag.ReturnURL = "https://www.ecpay.com.tw/receive.php";


            //*ChoosePayment 預設付款方式
            ViewBag.ChoosePayment = "ALL";


            //*CheckMacValue 加密類型
            ViewBag.EncryptType = "1";

            //*CheckMacValue 檢查碼:
            string HashKey = "5294y06JbISpM5x9";
            string HashIV = "v77hoKGq4kWxNNIS";

            //step1:參數用&連接
            var step1 = "ChoosePayment=ALL&EncryptType=1&ItemName=Apple iphone 7 手機殼&MerchantID=2000132&MerchantTradeDate=2013/03/12 15:30:23&MerchantTradeNo=acpay20130312153028&PaymentType=aio&ReturnURL=https://www.ecpay.com.tw/receive.php&TotalAmount=1000&TradeDesc=促銷方案";

            //step2:加上HashKey跟HashIV
            var step2 = $"HashKey={HashKey}&{step1}&HashIV={HashIV}";

            //step3：URL code編碼
            var step3 = HttpUtility.UrlEncode(step2);

            //step4：轉小寫
            var step4 = step3.ToLower();

            //var step5 = HttpUtility.UrlEncode(step4);

            //step5：SHA256編碼
            SHA256 sha256 = SHA256.Create();//建立一個SHA256
            byte[] source = Encoding.UTF8.GetBytes(step4);//將字串轉為Byte[]
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            var step6 = string.Empty;
            foreach (byte AddByte in crypto)//把加密後的字串從Byte[]轉為字串
            {
                step6 += String.Format("{0:x2}", AddByte);
            }

            //step6：轉大寫
            var step7 = step6.ToUpper();

            ViewBag.CheckMacValue = step7;

            return View();
        }

        public ActionResult ECPayTest()
        {
            //*MerchantID 商店代號
            ViewBag.MerchantID = "2000132";


            //*MerchantTradeNo 商店交易編號
            //可變動
            ViewBag.MerchantTradeNo = "b44446666";


            //*MerchantTradeDate 商店交易時間
            var dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            ViewBag.MerchantTradeDate = dateTime;


            //*PaymentType 交易類型
            ViewBag.PaymentType = "aio";


            //*TotalAmount 交易金額
            //可變動
            ViewBag.TotalAmount = 5;


            //*TradeDesc 交易描述
            ViewBag.TradeDesc = "知租網";


            //*ItemName 商品名稱
            //可變動
            ViewBag.ItemName = "知租網測試";


            //*ReturnURL 付款完成通知回傳網址
            ViewBag.ReturnURL = "https://localhost:44340/Home/Contact";


            //*ChoosePayment 預設付款方式
            ViewBag.ChoosePayment = "Credit";


            //ClientBackURL Client端返回廠商網址
            ViewBag.ClientBackURL = "https://www.google.com.tw/";


            //*CheckMacValue 加密類型
            ViewBag.EncryptType = "1";


            //*CheckMacValue 檢查碼:
            string HashKey = "5294y06JbISpM5x9";
            string HashIV = "v77hoKGq4kWxNNIS";

            //step1:參數用&連接
            var step1 = $"ChoosePayment={ViewBag.ChoosePayment}&ClientBackURL={ViewBag.ClientBackURL}&" +
                             $"EncryptType={ViewBag.EncryptType}&ItemName={ViewBag.ItemName}&" +
                             $"MerchantID={ViewBag.MerchantID}&MerchantTradeDate={ViewBag.MerchantTradeDate}&" +
                             $"MerchantTradeNo={ ViewBag.MerchantTradeNo}&PaymentType={ViewBag.PaymentType}&" +
                             $"ReturnURL={ViewBag.ReturnURL}&TotalAmount={ViewBag.TotalAmount}" +
                             $"&TradeDesc={ViewBag.TradeDesc}";

            //step2:加上HashKey跟HashIV
            var step2 = $"HashKey={HashKey}&{step1}&HashIV={HashIV}";

            //step3：URL Ecode編碼
            var step3 = HttpUtility.UrlEncode(step2);

            //step4：轉小寫
            var step4 = step3.ToLower();

            //var step5 = HttpUtility.UrlEncode(step4);

            //step5：SHA256編碼
            SHA256 sha256 = SHA256.Create();//建立一個SHA256
            byte[] source = Encoding.UTF8.GetBytes(step4);//將字串轉為Byte[]
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            var step6 = string.Empty;
            foreach (byte AddByte in crypto)//把加密後的字串從Byte[]轉為字串
            {
                step6 += String.Format("{0:x2}", AddByte);
            }

            //step6：轉大寫
            var step7 = step6.ToUpper();

            ViewBag.CheckMacValue = step7;

            return View();
        }

        public async Task<ActionResult> callECPay(string token)
        {
            ECPayViewModel ec = new ECPayViewModel();
            ec.MerchantID = "2000132";
            ec.PaymentType = "aio";
            ec.TradeDesc = "知租網";
            ec.ChoosePayment = "Credit";
            ec.EncryptType = "1";
            ec.MerchantTradeNo = $"qqcq123465";
            ec.MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            ec.TotalAmount = 105;
            ec.ItemName = "測試";
            ec.ReturnURL = "https://tw.yahoo.com/";
            ec.ClientBackURL = "https://www.google.com.tw/";
            ec.OrderResultURL = "https://localhost:44340/Home/callECPay";

            //CheckMacValue 檢查碼設定：
            string HashKey = "5294y06JbISpM5x9";
            string HashIV = "v77hoKGq4kWxNNIS";

            //step1:參數用&連接
            var step1 = $"ChoosePayment={ec.ChoosePayment}&ClientBackURL={ec.ClientBackURL}&" +
                        $"EncryptType={ec.EncryptType}&ItemName={ec.ItemName}&" +
                        $"MerchantID={ec.MerchantID}&MerchantTradeDate={ec.MerchantTradeDate}&" +
                        $"MerchantTradeNo={ec.MerchantTradeNo}&OrderResultURL={ec.OrderResultURL}&PaymentType={ec.PaymentType}&" +
                        $"ReturnURL={ec.ReturnURL}&TotalAmount={ec.TotalAmount}" +
                        $"&TradeDesc={ec.TradeDesc}";

            //step2:加上HashKey跟HashIV
            var step2 = $"HashKey={HashKey}&{step1}&HashIV={HashIV}";

            //step3：URL Ecode編碼
            var step3 = HttpUtility.UrlEncode(step2);

            //step4：轉小寫
            var step4 = step3.ToLower();

            //step5：SHA256編碼
            SHA256 sha256 = SHA256.Create();//建立一個SHA256
            byte[] source = Encoding.UTF8.GetBytes(step4);//將字串轉為Byte[]
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            var step5 = string.Empty;
            foreach (byte AddByte in crypto)//把加密後的字串從Byte[]轉為字串
            {
                step5 += String.Format("{0:x2}", AddByte);
            }

            //step6：轉大寫
            var step6 = step5.ToUpper();

            ec.CheckMacValue = step6;

            //var ec = new ECPayService().ECPay("0101010",1500,"測試綠界0908");
            var ecJson = JsonConvert.SerializeObject(ec);
            string url = "https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5";

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(ecJson);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return Content(result);
        }

    }
}