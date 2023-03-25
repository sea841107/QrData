using System;
using System.Collections.Generic;

namespace QrData
{
    public struct DetailStruct
    {
        public DetailStruct(string name, string year, string month, string date, string random,
            int price, int unTaxedPrice, int tax, string buyerId, string sellerId)
        {
            Name = name;
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
        public string Name { get; set; }
        public string Year { get; }
        public string Month { get; }
        public string Date { get; }
        public string Random { get; }
        public int Price { get; set; }
        public int UnTaxedPrice { get; set; }
        public int Tax { get; set; }
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
            int pureTax = (int)MathF.Round(UnTaxedPrice * 0.05f, MidpointRounding.AwayFromZero);
            return (int)MathF.Abs(Tax - pureTax);
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
                int yearLength = 3; // 中華民國3碼、西元4碼
                string uuid = data.Substring(0, 10);
                string year = data.Substring(10, yearLength);
                if (year[0] == '2' && year[1] == '0')
                {
                    yearLength = 4;
                    year = (Convert.ToInt32(data.Substring(10, yearLength)) - 1911).ToString();
                }
                string month = data.Substring(10 + yearLength, 2);
                string date = data.Substring(12 + yearLength, 2);

                string random;
                int price;
                int unTaxedPrice;
                int realUnTaxedPrice;
                int tax;
                string buyerId;
                string sellerId;

                int endIndex = data.IndexOf("=");
                if (endIndex >= 73 || endIndex < 0)
                {
                    random = data.Substring(14 + yearLength, 4);
                    realUnTaxedPrice = Convert.ToInt32(data.Substring(18 + yearLength, 8), 16);
                    price = Convert.ToInt32(data.Substring(26 + yearLength, 8), 16);
                    unTaxedPrice = (int)MathF.Round(price / 1.05f);
                    tax = price - unTaxedPrice;
                    buyerId = data.Substring(34 + yearLength, 8);
                    sellerId = data.Substring(42 + yearLength, 8);
                }
                else
                {
                    random = "0000";
                    realUnTaxedPrice = Convert.ToInt32(data.Substring(endIndex - 54, 8), 16);
                    price = Convert.ToInt32(data.Substring(endIndex - 46, 8), 16);
                    unTaxedPrice = (int)MathF.Round(price / 1.05f);
                    tax = price - unTaxedPrice;
                    buyerId = data.Substring(endIndex - 38, 8);
                    sellerId = data.Substring(endIndex - 30, 8);
                }

                if (Variable.Tax500Mode)
                {
                    unTaxedPrice = realUnTaxedPrice;
                    tax = price - unTaxedPrice;
                }

                DetailStruct detailStruct = new DetailStruct(uuid, year, month, date, random, price, unTaxedPrice, tax, buyerId, sellerId);
                if (buyerId == Variable.EmptyId)
                    return new Variable.ResultStruct(Variable.ResultType.BuyerIdEmpty, null);
                if (buyerId != Variable.CurBuyerId)
                    return new Variable.ResultStruct(Variable.ResultType.BuyerIdNotMatch, null);
                if ((price - realUnTaxedPrice) == 0)
                    return new Variable.ResultStruct(Variable.ResultType.TaxEqual0, null);
                if (Variable.Tax500Mode && tax <= Variable.MaxTax)
                    return new Variable.ResultStruct(Variable.ResultType.TaxBelow500, tax.ToString());
                else if (!Variable.Tax500Mode && tax > Variable.MaxTax)
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
                            if (Variable.Tax500Mode || (monthStruct.CalcTaxOffset() < Variable.MaxTaxOffset))
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
                                return new Variable.ResultStruct(Variable.ResultType.TaxOffsetExceed2, year + "年\n" + month + "月");
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

        public static Variable.ResultStruct ClearMonthData(string key)
        {
            MainActivity.Instance.DeleteCache();
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

        public static Variable.ResultStruct ClearDetailData(string key)
        {
            MainActivity.Instance.DeleteCache();
            var buyerStruct = BuyerDic[Variable.CurBuyerId];
            if (buyerStruct.MonthDic.ContainsKey(Variable.CurDetailMonth))
            {
                var monthStruct = buyerStruct.MonthDic[Variable.CurDetailMonth];
                if (monthStruct.DetailDic.ContainsKey(key))
                {
                    var detailStruct = monthStruct.DetailDic[key];
                    buyerStruct.Amount--;
                    monthStruct.Amount--;
                    monthStruct.Price -= detailStruct.Price;
                    monthStruct.UnTaxedPrice -= detailStruct.UnTaxedPrice;
                    monthStruct.Tax -= detailStruct.Tax;
                    monthStruct.DetailDic.Remove(key);
                    buyerStruct.MonthDic[Variable.CurDetailMonth] = monthStruct;
                    BuyerDic[Variable.CurBuyerId] = buyerStruct;
                    if (monthStruct.DetailDic.Count == 0)
                    {
                        buyerStruct.MonthDic.Remove(Variable.CurDetailMonth);
                        if (buyerStruct.MonthDic.Count == 0)
                            BuyerDic.Remove(Variable.CurBuyerId);
                    }
                    return new Variable.ResultStruct(Variable.ResultType.ClearSuccess, null);
                }
                else
                    return new Variable.ResultStruct(Variable.ResultType.ClearFailed, null);
            }
            else
                return new Variable.ResultStruct(Variable.ResultType.ClearFailed, null);
        }

        public static Variable.ResultStruct ClearAllData()
        {
            MainActivity.Instance.DeleteCache();
            BuyerDic.Clear();
            return new Variable.ResultStruct(Variable.ResultType.ClearSuccess, null);
        }

        public static Variable.ResultStruct AddDetailData(int price, int tax)
        {
            MainActivity.Instance.DeleteCache();
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string key = timestamp;
            string name = timestamp;
            var buyerStruct = BuyerDic[Variable.CurBuyerId];
            if (buyerStruct.MonthDic.ContainsKey(Variable.CurDetailMonth))
            {
                var monthStruct = buyerStruct.MonthDic[Variable.CurDetailMonth];
                if (!monthStruct.DetailDic.ContainsKey(key))
                {
                    string year = Variable.CurDetailMonth.Substring(0, 3);
                    string month = Variable.CurDetailMonth.Substring(3, 2);
                    var detailStruct = new DetailStruct(name, year, month, "", "", price, price - tax, tax, Variable.CurBuyerId, "");
                    buyerStruct.Amount++;
                    monthStruct.Amount++;
                    monthStruct.Price += price;
                    monthStruct.UnTaxedPrice += (price - tax);
                    monthStruct.Tax += tax;
                    monthStruct.DetailDic.Add(key, detailStruct);
                    buyerStruct.MonthDic[Variable.CurDetailMonth] = monthStruct;
                    BuyerDic[Variable.CurBuyerId] = buyerStruct;
                    return new Variable.ResultStruct(Variable.ResultType.AddSuccess, null);
                }
                else
                    return new Variable.ResultStruct(Variable.ResultType.AddFailed, null);
            }
            else
                return new Variable.ResultStruct(Variable.ResultType.AddFailed, null);
        }


        public static Variable.ResultStruct ModifyDetailData(string key, string name, int price, int tax)
        {
            MainActivity.Instance.DeleteCache();
            var buyerStruct = BuyerDic[Variable.CurBuyerId];
            if (buyerStruct.MonthDic.ContainsKey(Variable.CurDetailMonth))
            {
                var monthStruct = buyerStruct.MonthDic[Variable.CurDetailMonth];
                if (monthStruct.DetailDic.ContainsKey(key))
                {
                    var detailStruct = monthStruct.DetailDic[key];
                    monthStruct.Price -= (detailStruct.Price - price);
                    monthStruct.UnTaxedPrice -= (detailStruct.UnTaxedPrice - (price - tax));
                    monthStruct.Tax -= (detailStruct.Tax - tax);
                    detailStruct.Price = price;
                    detailStruct.UnTaxedPrice = price - tax;
                    detailStruct.Tax = tax;
                    detailStruct.Name = name;
                    monthStruct.DetailDic[key] = detailStruct;
                    buyerStruct.MonthDic[Variable.CurDetailMonth] = monthStruct;
                    BuyerDic[Variable.CurBuyerId] = buyerStruct;
                    return new Variable.ResultStruct(Variable.ResultType.ModifySuccess, null);
                }
                else
                    return new Variable.ResultStruct(Variable.ResultType.ModifyFailed, null);
            }
            else
                return new Variable.ResultStruct(Variable.ResultType.ModifyFailed, null);
        }

        public static Dictionary<string, DetailStruct> GetMonthData(string month)
        {
            if (BuyerDic.ContainsKey(Variable.CurBuyerId))
            {
                var buyerStruct = BuyerDic[Variable.CurBuyerId];
                if (buyerStruct.MonthDic.ContainsKey(month))
                {
                    var monthStruct = buyerStruct.MonthDic[month];
                    return monthStruct.DetailDic;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public static DetailStruct GetDetailData(string key)
        {
            if (BuyerDic.ContainsKey(Variable.CurBuyerId))
            {
                var buyerStruct = BuyerDic[Variable.CurBuyerId];
                if (buyerStruct.MonthDic.ContainsKey(Variable.CurDetailMonth))
                {
                    var detailStruct = buyerStruct.MonthDic[Variable.CurDetailMonth];
                    if (detailStruct.DetailDic.ContainsKey(key))
                        return detailStruct.DetailDic[key];
                    else
                        return new DetailStruct();
                }
                else
                    return new DetailStruct();
            }
            else
                return new DetailStruct();
        }

        public static Dictionary<string, MonthStruct> GetAllMonthData()
        {
            if (BuyerDic.ContainsKey(Variable.CurBuyerId))
            {
                var buyerStruct = BuyerDic[Variable.CurBuyerId];
                return buyerStruct.MonthDic;
            }
            else
                return null;
        }
    }
}