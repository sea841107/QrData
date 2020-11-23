namespace QrData
{
    public static class Variable
    {
        public static string CurBuyerId; // 輸入的統編
        readonly public static string EmptyId = "00000000"; // 空白統編
        readonly public static int MaxTax = 500; // 最大稅額
        readonly public static int MaxTaxOffset = 2; // 最大稅額差
        readonly public static string[] FakeData = {
            // 編號(8)+日期(7)+隨機碼(4)+未稅額16進位(8)+總計額16進位(8)+買方統編(8)+賣方統編(8)
            "AA000000001091107218400000000000002250000000054914283",
            "AA000000011091007218400000000000002240000000054914283",
            "AA000000021091107218400000000000002230000000054914283",
            "AA000000001091107218400000000000002230000000054914283", // 發票已存在
            "AA000000031091107218400000000000002230000000154914283", // 發票統編不符合
            "AA00000004109110721840000000000002AF80000000054914283", // 稅額500元以上
        };

        public enum ResultType
        {
            Success,
            Delete,
            UuidExist, // 發票已存在
            BuyerIdUnvalid, // 無效的統編
            BuyerIdEmpty, // 發票無買方統編
            BuyerIdNotMatch, // 發票統編不符合
            TaxOffsetExceed2, // 稅額差2元以上
            TaxExceed500, // 稅額500元以上
        }

        public enum RequestCode
        {
            Camera = 1,
        }
    }
}