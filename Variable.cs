namespace QrData
{
    public static class Variable
    {
        public static int CurFontSize = 0;
        public static string CurBuyerId = ""; // 輸入的統編
        public static string CurQrCode = "";
        public static bool Tax500Mode = false; // 稅金500元以上模式
        readonly public static string EmptyId = "00000000"; // 空白統編
        readonly public static int MaxTax = 500; // 最大稅額
        readonly public static int MaxTaxOffset = 2; // 最大稅額差
        readonly public static bool FakeMode = false;
        readonly public static string[] FakeData = {
            // 編號(8)+日期(7)+隨機碼(4)+未稅額16進位(8)+總計額16進位(8)+買方統編(8)+賣方統編(8)+加密驗證資訊(24)
            "AA0000000011001011234000000000000022512345678876543218PylsDDtS2GpKgUPejUtTQ==:",
            "AA0000000110901011234000000000000022512345678876543218PylsDDtS2GpKgUPejUtTQ==:",
            "AA0000000210912311234000000000000022412345678876543218PylsDDtS2GpKgUPejUtTQ==:",
            "AA0000000210912311234000000000000022312345678876543218PylsDDtS2GpKgUPejUtTQ==:",  // 發票已存在
            "AA0000000310901011234000000000000022300000000876543218PylsDDtS2GpKgUPejUtTQ==:",  // 發票無買方統編
            "AA0000000310901011234000000000000022323456789876543218PylsDDtS2GpKgUPejUtTQ==:",  // 發票統編不符合
            "AA00000003109010112340000000000002AF812345678876543218PylsDDtS2GpKgUPejUtTQ==:",  // 稅額500元以上
            "AA000000041090601123400000000000003E812345678876543218PylsDDtS2GpKgUPejUtTQ==:",
            "AA000000051090601123400000000000003E812345678876543218PylsDDtS2GpKgUPejUtTQ==:",
            "AA000000061090601123400000000000003E812345678876543218PylsDDtS2GpKgUPejUtTQ==:",
            "AA000000071090601123400000000000003E812345678876543218PylsDDtS2GpKgUPejUtTQ==:",  // 稅額差2元以上
            "AA0000000820200701123400000000000003E812345678876543218PylsDDtS2GpKgUPejUtTQ==:", // 年份為西元
            "AA0000000910907011234000000010000000112345678876543218PylsDDtS2GpKgUPejUtTQ==:",  // 稅額為0
            "AA000000101100201000000000000066612345678876543218PylsDDtS2GpKgUPejUtTQ==:",      // 無隨機碼
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
            TaxBelow500, // 稅額500元以下
            TaxEqual0, // 稅額為0
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
            if (id.Length != 8 || id == "" || id[0] == '-' || id[0] == '+' || id == EmptyId)
                return false;
            return true;
        }

        public enum FontSize
        {
            Big = 0,
            Medium = 1,
            Small = 2
        }
        readonly public static int FontSizeBig = 20;
        readonly public static int FontSizeMedium = 17;
        readonly public static int FontSizeSmall = 14;
    }
}