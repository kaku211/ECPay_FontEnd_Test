using ECPay_FontEnd_Test.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECPay_FontEnd_Test.Service
{
    public class ECPayService
    {
        public ECPayViewModel ECPay(string TradeNo, int TotalAmount, string ItemName)
        {
            ECPayViewModel ec = new ECPayViewModel();
            ec.MerchantTradeNo = $"qqcq{TradeNo}";
            ec.MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            ec.TotalAmount = TotalAmount;
            ec.ItemName = ItemName;
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

            return ec;
        }

        //private async Task<string> PostToECPay(ECPayViewModel ec)
        //{
        //    var ecJson = JsonConvert.SerializeObject(ec);
        //    string url = "https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5";
            
        //    HttpClient client = new HttpClient();
        //    HttpContent content = new StringContent(ecJson);
        //    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
        //    HttpResponseMessage response = await client.PostAsync(url, content);
        //    response.EnsureSuccessStatusCode();
        //    string result = await response.Content.ReadAsStringAsync();
        //    return result;
        //}
    }
}