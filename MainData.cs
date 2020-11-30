using System;
using System.Collections.Generic;

namespace QrData
{
    public struct DetailStruct
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

    public struct MonthStruct
    {
        public MonthStruct(Dictionary<string, DetailStruct> detailDic)
        {
            Amount = 0;
            Price = 0;
            UnTaxedPrice = 0;
            Tax = 0;
            ToLimit = false;
            DetailDic = detailDic;
        }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int UnTaxedPrice { get; set; }
        public int Tax { get; set; }
        public bool ToLimit { get; set; }
        public Dictionary<string, DetailStruct> DetailDic { get; }
        public int CalcTaxOffset()
        {
            int pureTax = (int)MathF.Round(Price / 1.05f * 0.05f);
            return Tax - pureTax;
        }
    }

    public struct BuyerStruct
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
        public static Dictionary<string, BuyerStruct> BuyerDic = new Dictionary<string, BuyerStruct>();

        public static Variable.ResultStruct SetData(string data)
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
                int tax = (int)MathF.Round(price / 1.05f * 0.05f);
                string buyerId = data.Substring(37, 8);
                string sellerId = data.Substring(45, 8);
                DetailStruct detailStruct = new DetailStruct(year, month, date, random, price, unTaxedPrice, tax, buyerId, sellerId);
                if (buyerId == Variable.EmptyId)
                    return new Variable.ResultStruct(Variable.ResultType.BuyerIdEmpty, null);
                if (buyerId != Variable.CurBuyerId)
                    return new Variable.ResultStruct(Variable.ResultType.BuyerIdNotMatch, null);
                if (tax > Variable.MaxTax)
                    return new Variable.ResultStruct(Variable.ResultType.TaxExceed500, null);
                if (BuyerDic.ContainsKey(buyerId))
                {
                    var buyerStruct = BuyerDic[buyerId];
                    if (buyerStruct.MonthDic.ContainsKey(year + month))
                    {
                        var monthStruct = buyerStruct.MonthDic[year + month];
                        if (monthStruct.DetailDic.ContainsKey(uuid))
                        {
                            return new Variable.ResultStruct(Variable.ResultType.UuidExist, null);
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
                                buyerStruct.MonthDic[year + month] = monthStruct;
                                BuyerDic[buyerId] = buyerStruct;
                            }
                            else
                            {
                                monthStruct.Price -= price;
                                monthStruct.UnTaxedPrice -= unTaxedPrice;
                                monthStruct.Tax -= tax;
                                monthStruct.ToLimit = true;
                                buyerStruct.MonthDic[year + month] = monthStruct;
                                return new Variable.ResultStruct(Variable.ResultType.TaxOffsetExceed2, null);
                            }
                        }
                    }
                    else
                    {
                        MonthStruct monthStruct = new MonthStruct(new Dictionary<string, DetailStruct>());
                        monthStruct.Price += price;
                        monthStruct.UnTaxedPrice += unTaxedPrice;
                        monthStruct.Tax += tax;
                        monthStruct.Amount += 1;
                        buyerStruct.Amount += 1;
                        buyerStruct.MonthDic.Add(year + month, monthStruct);
                        monthStruct.DetailDic.Add(uuid, detailStruct);
                        BuyerDic[buyerId] = buyerStruct;
                    }
                }
                else
                {
                    BuyerStruct buyerStruct = new BuyerStruct(new Dictionary<string, MonthStruct>());
                    MonthStruct monthStruct = new MonthStruct(new Dictionary<string, DetailStruct>());
                    monthStruct.Price += price;
                    monthStruct.UnTaxedPrice += unTaxedPrice;
                    monthStruct.Tax += tax;
                    monthStruct.Amount += 1;
                    buyerStruct.Amount += 1;
                    BuyerDic.Add(buyerId, buyerStruct);
                    buyerStruct.MonthDic.Add(year + month, monthStruct);
                    monthStruct.DetailDic.Add(uuid, detailStruct);
                }
                return new Variable.ResultStruct(Variable.ResultType.ScanSuccess, year + "年\n" + month + "月");
            }
            return new Variable.ResultStruct(Variable.ResultType.ScanFailed, null);
        }

        public static Variable.ResultStruct ClearData(string key)
        {
            var buyerStruct = BuyerDic[Variable.CurBuyerId];
            if (buyerStruct.MonthDic.ContainsKey(key))
            {
                buyerStruct.MonthDic.Remove(key);
                if (buyerStruct.MonthDic.Count == 0)
                    BuyerDic.Remove(Variable.CurBuyerId);
                return new Variable.ResultStruct(Variable.ResultType.ClearSuccess, null);
            }
            else
                return new Variable.ResultStruct(Variable.ResultType.ClearFailed, null);
        }

        public static Variable.ResultStruct ClearAllData()
        {
            BuyerDic.Clear();
            return new Variable.ResultStruct(Variable.ResultType.ClearSuccess, null);
        }

        public static Dictionary<string, MonthStruct> GetAllData()
        {
            if (BuyerDic.ContainsKey(Variable.CurBuyerId))
            {
                var buyerStruct = BuyerDic[Variable.CurBuyerId];
                return buyerStruct.MonthDic;
            } else
                return null;
        }
    }
}