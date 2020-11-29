namespace QrData
{
    public static class Variable
    {
        public static string CurBuyerId = ""; // 輸入的統編
        public static string CurQrCode = "";
        readonly public static string EmptyId = "00000000"; // 空白統編
        readonly public static int MaxTax = 500; // 最大稅額
        readonly public static int MaxTaxOffset = 2; // 最大稅額差
        readonly public static bool FakeMode = false;
        readonly public static string[] FakeData = {
            // 編號(8)+日期(7)+隨機碼(4)+未稅額16進位(8)+總計額16進位(8)+買方統編(8)+賣方統編(8)
            "AA000000001100101123400000000000002251234567887654321",
            "AA000000011090101123400000000000002241234567887654321",
            "AA000000021091231123400000000000002231234567887654321",
            "AA000000021090101123400000000000002231234567887654321", // 發票已存在
            "AA000000031090101123400000000000002230000000087654321", // 發票無買方統編
            "AA000000031090101123400000000000002232345678987654321", // 發票統編不符合
            "AA00000003109010112340000000000002AF81234567887654321", // 稅額500元以上
            "AA000000041090601123400000000000003E81234567887654321",
            "AA000000051090601123400000000000003E81234567887654321",
            "AA000000061090601123400000000000003E81234567887654321",
            "AA000000071090601123400000000000003E81234567887654321", // 稅額差2元以上
        };

        public struct ResultStruct
        {
            public ResultStruct(ResultType type, string value)
            {
                Type = type;
                Value = value;
            }
            public ResultType Type { get; }
            public string Value { get; }
        }

        public enum ResultType
        {
            Default,
            LeaveApp,
            ScanSuccess,
            ScanFailed,
            Clear,
            ClearAll,
            ClearSuccess,
            ClearFailed,
            ClearBeforeEdit,
            UuidExist, // 發票已存在
            BuyerIdUnvalid, // 無效的統編
            BuyerIdEmpty, // 發票無買方統編
            BuyerIdNotMatch, // 發票統編不符合
            TaxOffsetExceed2, // 稅額差2元以上
            TaxExceed500, // 稅額500元以上
        }

        public enum MessageType
        {
            Toast,
            Dialog,
        }

        public enum RequestCode
        {
            Camera = 1,
        }

        public static bool CheckIdValid(string id)
        {
            // 買方統編規則：長度須為8個字元、不能為空、不能為負數、不能是00000000
            if (id.Length != 8 || id == "" || id[0] == '-' || id == EmptyId)
            {
                return false;
            }
            return true;
        }
    }
}