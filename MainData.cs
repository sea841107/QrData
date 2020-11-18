using System;
using System.Collections.Generic;

namespace QrData
{
    struct DetailStruct
    {
        public DetailStruct(string year, string month, string date, string random,
            int price, int unTaxedPrice, int tax, string buyerId, string sellerId)
        {
            Year = year;
            Month = month;
            Date = date;
            Random = random;
            Price = price;
            UnTaxedPrice = unTaxedPrice;
            Tax = tax;
            BuyerId = buyerId;
            SellerId = sellerId;
        }
        public string Year { get; }
        public string Month { get; }
        public string Date { get; }
        public string Random { get; }
        public int Price { get; }
        public int UnTaxedPrice { get; }
        public int Tax { get; }
        public string BuyerId { get; }
        public string SellerId { get; }
    }

    struct MonthStruct
    {
        public MonthStruct(Dictionary<string, DetailStruct> detailDic)
        {
            Amount = 0;
            Price = 0;
            UnTaxedPrice = 0;
            Tax = 0;
            DetailDic = detailDic;
        }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int UnTaxedPrice { get; set; }
        public int Tax { get; set; }
        public Dictionary<string, DetailStruct> DetailDic { get; }
        public int CalcTaxOffset()
        {
            int pureTax = (int)MathF.Round(Price / 1.05f * 0.05f);
            return pureTax - Tax;
        }
    }

    struct BuyerStruct
    {
        public BuyerStruct(Dictionary<string, MonthStruct> monthDic)
        {
            Amount = 0;
            MonthDic = monthDic;
        }
        public int Amount { get; set; }
        public Dictionary<string, MonthStruct> MonthDic { get; }
    }

    public static class MainData
    {
        static Dictionary<string, BuyerStruct> BuyerDic = new Dictionary<string, BuyerStruct>();
        
        public static Variable.ResultType SetData(string data)
        {
            if (data != null)
            {
                string uuid = data.Substring(0, 10);
                string year = data.Substring(10, 3);
                string month = data.Substring(13, 2);
                string date = data.Substring(15, 2);
                string random = data.Substring(17, 4);
                int price = Convert.ToInt32(data.Substring(29, 8), 16);
                int unTaxedPrice = (int)MathF.Round(price / 1.05f);
                int tax = (int)MathF.Round(unTaxedPrice * 0.05f);
                string buyerId = data.Substring(37, 8);
                string sellerId = data.Substring(45, 8);
                var detailDic = new Dictionary<string, DetailStruct>();
                var monthDic = new Dictionary<string, MonthStruct>();
                DetailStruct detailStruct = new DetailStruct(year, month, date, random, price,
                    unTaxedPrice, tax, buyerId, sellerId);
                //if (buyerId == Variable.EmptyId)
                //    return Variable.ResultType.BuyerIdEmpty;
                if (buyerId != Variable.CurBuyerId)
                    return Variable.ResultType.BuyerIdNotMatch;
                if (tax > Variable.MaxTax)
                    return Variable.ResultType.TaxExceed500;
                if (BuyerDic.ContainsKey(buyerId))
                {
                    var buyerStruct = BuyerDic.GetValueOrDefault(buyerId);
                    if (buyerStruct.MonthDic.ContainsKey(month))
                    {
                        var monthStruct = buyerStruct.MonthDic.GetValueOrDefault(month);
                        if (monthStruct.DetailDic.ContainsKey(uuid))
                        {
                            return Variable.ResultType.UuidExist;
                        }
                        else
                        {
                            monthStruct.Price += price;
                            monthStruct.UnTaxedPrice += unTaxedPrice;
                            monthStruct.Tax += tax;
                            if (monthStruct.CalcTaxOffset() < Variable.MaxTaxOffset)
                            {
                                monthStruct.Amount += 1;
                                buyerStruct.Amount += 1;
                                monthStruct.DetailDic.Add(uuid, detailStruct);
                            }
                            else
                            {
                                monthStruct.Price -= price;
                                monthStruct.UnTaxedPrice -= unTaxedPrice;
                                monthStruct.Tax -= tax;
                                return Variable.ResultType.TaxOffsetExceed2;
                            }
                        }
                    }
                    else
                    {
                        MonthStruct monthStruct = new MonthStruct(detailDic);
                        monthStruct.Price += price;
                        monthStruct.UnTaxedPrice += unTaxedPrice;
                        monthStruct.Tax += tax;
                        monthStruct.Amount += 1;
                        buyerStruct.Amount += 1;
                        monthDic.Add(month, monthStruct);
                        detailDic.Add(uuid, detailStruct);
                    }
                }
                else
                {
                    BuyerStruct buyerStruct = new BuyerStruct(monthDic);
                    MonthStruct monthStruct = new MonthStruct(detailDic);
                    monthStruct.Price += price;
                    monthStruct.UnTaxedPrice += unTaxedPrice;
                    monthStruct.Tax += tax;
                    monthStruct.Amount += 1;
                    buyerStruct.Amount += 1;
                    BuyerDic.Add(buyerId, buyerStruct);
                    monthDic.Add(month, monthStruct);
                    detailDic.Add(uuid, detailStruct);
                }
            }
            return Variable.ResultType.Success;
        }
    }
}