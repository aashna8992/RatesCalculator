using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateCalculator.Models
{
    public class PrAdjustmentList
    {
        public string description { get; set; }
        public double rate { get; set; }
        public double points { get; set; }
        public double value { get; set; }
    }

    public class LlpaAdjustment
    {
        public double basePrice { get; set; }
        public double noteRate { get; set; }
        public double finalPrice { get; set; }
        public double finalNoteRate { get; set; }
        public List<PrAdjustmentList> prAdjustmentList { get; set; }
        public object priceDiff { get; set; }
        public double rateTotal { get; set; }
        public double priceTotal { get; set; }
    }

    public class ProductDetail
    {
        public int productDetailID { get; set; }
        public double rate { get; set; }
        public int lockTerm { get; set; }
        public int loanTerm { get; set; }
        public double basePrice { get; set; }
        public double finalPrice { get; set; }
        public double discountRebate { get; set; }
        public double pi { get; set; }
        public LlpaAdjustment llpaAdjustment { get; set; }
        public double loanAmount { get; set; }
    }

    public class RateModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string planNumber { get; set; }
        public double rate { get; set; }
        public int lockTerm { get; set; }
        public double basePrice { get; set; }
        public double finalPrice { get; set; }
        public double discountRebate { get; set; }
        public double pi { get; set; }
        public string expirationDate { get; set; }
        public List<ProductDetail> productDetail { get; set; }
        public bool isEligibleProduct { get; set; }
        public string reason { get; set; }
        public bool isCutOffTime { get; set; }
        public bool isReqLockConditonFailed { get; set; }
        public bool isAdvancedLockInEligibleProgram { get; set; }
        public bool isPricingDisabled { get; set; }
        public bool isAdvanceLock { get; set; }
        public bool isPortProduct { get; set; }
        public int selectedLockTerm { get; set; }
        public double priceDiff { get; set; }
        public object description { get; set; }
    }
}