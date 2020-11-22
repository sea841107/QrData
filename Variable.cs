namespace QrData
{
    public static class Variable
    {
        public static string CurBuyerId; // 輸入的統編
        readonly public static string EmptyId = "00000000"; // 空白統編
        readonly public static int MaxTax = 500; // 最大稅額
        readonly public static int MaxTaxOffset = 2; // 最大稅額差

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