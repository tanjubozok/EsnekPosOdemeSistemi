using System.Collections.Generic;

namespace EsnekPosOdemeSistemi.Models
{
    public class Config
    {
        public string MERCHANT { get; set; }
        public string MERCHANT_KEY { get; set; }
        public string BACK_URL { get; set; }
        public string PRICES_CURRENCY { get; set; }
        public string ORDER_REF_NUMBER { get; set; }
        public string ORDER_AMOUNT { get; set; }
    }

    public class CreditCard
    {
        public string CC_NUMBER { get; set; }
        public string EXP_MONTH { get; set; }
        public string EXP_YEAR { get; set; }
        public string CC_CVV { get; set; }
        public string CC_OWNER { get; set; }
        public string INSTALLMENT_NUMBER { get; set; }
    }

    public class Customer
    {
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string MAIL { get; set; }
        public string PHONE { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string ADDRESS { get; set; }
        public string CLIENT_IP { get; set; }
    }

    public class Product
    {
        public string PRODUCT_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_CATEGORY { get; set; }
        public string PRODUCT_DESCRIPTION { get; set; }
        public string PRODUCT_AMOUNT { get; set; }
    }

    public class Result
    {
        public Config Config { get; set; }
        public CreditCard CreditCard { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Product { get; set; }
        public string ORDER_REF_NUMBER { get; set; }
        public string STATUS { get; set; }
        public string RETURN_CODE { get; set; }
        public string RETURN_MESSAGE { get; set; }
        public object RETURN_MESSAGE_TR { get; set; }
        public object ERROR_CODE { get; set; }
        public string DATE { get; set; }
        public string URL_3DS { get; set; }
        public string REFNO { get; set; }
        public string HASH { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string CUSTOMER_MAIL { get; set; }
        public string CUSTOMER_PHONE { get; set; }
        public string CUSTOMER_ADDRESS { get; set; }
        public string CUSTOMER_CC_NUMBER { get; set; }
        public object CUSTOMER_CC_NAME { get; set; }
        public bool IS_NOT_3D_PAYMENT { get; set; }
        public object VIRTUAL_POS_VALUES { get; set; }
        public object RETURN_MESSAGE_3D { get; set; }
        public int PAYMENT_BANK_CODE { get; set; }
    }
}