using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECPay_FontEnd_Test.Models
{
    public class ECPayViewModel
    {
        /// <summary>
        /// MerchantID 商店代號：2000132
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// MerchantTradeNo 商店交易編號：訂單編號
        /// 字元大小：20
        /// </summary>
        public string MerchantTradeNo { get; set; }

        /// <summary>
        /// *MerchantTradeDate 商店交易時間
        /// 格式：yyyy/MM/dd HH:mm:ss
        /// </summary>
        public string MerchantTradeDate { get; set; }

        /// <summary>
        /// *PaymentType 交易類型：aio
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// *TotalAmount 交易金額
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// *TradeDesc 交易描述：知租網
        /// </summary>
        public string TradeDesc { get; set; }

        /// <summary>
        /// *ItemName 商品名稱
        /// 限制400字元
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// *ReturnURL 付款完成通知回傳網址
        /// </summary>
        public string ReturnURL { get; set; }

        /// <summary>
        /// *ChoosePayment 預設付款方式：Credit
        /// </summary>
        public string ChoosePayment { get; set; }

        /// <summary>
        /// ClientBackURL Client端返回廠商網址
        /// </summary>
        public string ClientBackURL { get; set; }

        /// <summary>
        /// *CheckMacValue 加密類型：1
        /// </summary>
        public string EncryptType { get; set; }

        ///<summary>
        ///*CheckMacValue 檢查碼:
        ///</summary>
        public string CheckMacValue { get; set; }

        public string OrderResultURL { get; set; }

        public ECPayViewModel()
        {
            MerchantID = "2000132";
            PaymentType = "aio";
            TradeDesc = "知租網";
            ChoosePayment = "Credit";
            EncryptType = "1";
        }
    }
}