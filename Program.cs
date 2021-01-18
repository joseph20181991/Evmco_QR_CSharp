using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Evmco
{
    class Program
    {
        static void Main(string[] args)
        {

            string qr = "000201010211153125000344000203444733984437611235204490053030505802BD5919Bangladesh currency6004XXYY62600120000000000000000000000520000000000000000000000708000000016304F7D1";

            var result = DecodeRQString(qr);
            var merchantAdditionalFields = result.Where(x => x.Key == "Merchant Additional Fields").Select(x => x.Value).FirstOrDefault();

            var result1 = DecodeRQSixtyTwoIndexString(merchantAdditionalFields);
            var unionPayFieldsInfoFiveTeenIndex = result.Where(x => x.Key == "UNIONPay0").Select(x => x.Value).FirstOrDefault();

            var unionPayInfo = DecodeUnionPayRQPart(unionPayFieldsInfoFiveTeenIndex);

            var TrxCurrency = result.Where(x => x.Key == "Transaction Currency").Select(x => x.Value).FirstOrDefault();
            var MerchantName = result.Where(x => x.Key == "Merchant Name").Select(x => x.Value).FirstOrDefault();
            var MCC = result.Where(x => x.Key == "Merchant Category Code").Select(x => x.Value).FirstOrDefault();
            var AcquirerIIN = unionPayInfo.Where(x => x.Key == "Acquirer IIN").Select(x => x.Value).FirstOrDefault();
            var FwdIIN = unionPayInfo.Where(x => x.Key == "Forwarding IIN").Select(x => x.Value).FirstOrDefault();
            var Mid = unionPayInfo.Where(x => x.Key == "Merchant ID").Select(x => x.Value).FirstOrDefault();

            Console.WriteLine("Hello World!");
        }
        static IDictionary<string, string> DecodeRQString(string rq)
        {

            IDictionary<string, string> QRIndexName = new Dictionary<string, string>();
            QRIndexName.Add("00", "Payload Format Indicator");
            QRIndexName.Add("01", "Point of Initiation Method");
            QRIndexName.Add("02", "VISA0");
            QRIndexName.Add("03", "VISA1");
            QRIndexName.Add("04", "Master0");
            QRIndexName.Add("05", "Master1");
            QRIndexName.Add("06", "EMVCo0");
            QRIndexName.Add("07", "EMVCo1");
            QRIndexName.Add("08", "EMVCo2");
            QRIndexName.Add("09", "Discover0");
            QRIndexName.Add("10", "Discover1");
            QRIndexName.Add("11", "Amex0");
            QRIndexName.Add("12", "Amex1");


            QRIndexName.Add("13", "JCB0");
            QRIndexName.Add("14", "JCB1");
            QRIndexName.Add("15", "UNIONPay0");
            QRIndexName.Add("16", "UNIONPay1");
            QRIndexName.Add("17", "EMVCo3");
            QRIndexName.Add("18", "EMVCo4");
            QRIndexName.Add("19", "EMVCo5");
            QRIndexName.Add("20", "EMVCo6");
            QRIndexName.Add("21", "EMVCo7");

            QRIndexName.Add("22", "EMVCo8");
            QRIndexName.Add("23", "EMVCo9");
            QRIndexName.Add("24", "EMVCo10");
            QRIndexName.Add("25", "EMVCo11");
            QRIndexName.Add("26", "NPSB 0");


            QRIndexName.Add("27", "NPSB 1");
            QRIndexName.Add("28", "RFU 0");
            QRIndexName.Add("29", "RFU 1");
            QRIndexName.Add("30", "RFU 2");
            QRIndexName.Add("31", "RFU 3");
            QRIndexName.Add("32", "RFU 4");
            QRIndexName.Add("33", "RFU 5");

            QRIndexName.Add("34", "RFU 6");
            QRIndexName.Add("35", "RFU 7");
            QRIndexName.Add("36", "RFU 8");
            QRIndexName.Add("37", "RFU 9");
            QRIndexName.Add("38", "RFU 10");
            QRIndexName.Add("39", "RFU 11");
            QRIndexName.Add("40", "RFU 12");
            QRIndexName.Add("41", "RFU 13");

            QRIndexName.Add("42", "RFU 14");
            QRIndexName.Add("43", "RFU 15");
            QRIndexName.Add("44", "RFU 16");
            QRIndexName.Add("45", "RFU 17");
            QRIndexName.Add("46", "RFU 18");
            QRIndexName.Add("47", "RFU 19");
            QRIndexName.Add("48", "RFU 20");
            QRIndexName.Add("49", "RFU 21");
            QRIndexName.Add("50", "RFU 22");
            QRIndexName.Add("51", "RFU 23");

            QRIndexName.Add("52", "Merchant Category Code");
            QRIndexName.Add("53", "Transaction Currency");
            QRIndexName.Add("54", "Transaction Amount");
            QRIndexName.Add("55", "Tip convenience indicator");
            QRIndexName.Add("56", "Value of convenience fixed");
            QRIndexName.Add("57", "Value of Percentage Tip");
            QRIndexName.Add("58", "Country Code");
            QRIndexName.Add("59", "Merchant Name");
            QRIndexName.Add("60", "Merchant City");
            QRIndexName.Add("61", "Merchant Postal Code");
            QRIndexName.Add("62", "Merchant Additional Fields");
            QRIndexName.Add("63", "Cyclic Redundancy Check");

            QRIndexName.Add("64", "Language Preference");
            QRIndexName.Add("80", "Date and Time");
            QRIndexName.Add("82", "Geographical Location");


            IDictionary<string, string> indexNameValue = new Dictionary<string, string>();

            while (rq != "")
            {

                var index = rq.Substring(0, 2);
                var lenth = rq.Substring(2, 2);
                var value = rq.Substring(4, Convert.ToInt32(lenth));
                rq = rq.Substring(4 + Convert.ToInt32(lenth));

                var name = QRIndexName[index];


                indexNameValue.Add(name, value);
            }

            var ddddd = indexNameValue;
            string[,] Tablero = new string[2, 2];


            return indexNameValue;

        }


        static IDictionary<string, string> DecodeRQSixtyTwoIndexString(string rq)
        {


            IDictionary<string, string> optionalSixtyTwo = new Dictionary<string, string>();
            optionalSixtyTwo.Add("01", "Bill Number");
            optionalSixtyTwo.Add("02", "Mobile Number");
            optionalSixtyTwo.Add("03", "Store Label");
            optionalSixtyTwo.Add("04", "Loyalty Number");
            optionalSixtyTwo.Add("05", "Reference Label");
            optionalSixtyTwo.Add("06", "Customer Label");
            optionalSixtyTwo.Add("07", "Terminal Label");
            optionalSixtyTwo.Add("08", "Purpose of transaction");
            optionalSixtyTwo.Add("09", "Additional Consumer Data");
            optionalSixtyTwo.Add("10", "'Merchant Tax ID");
            optionalSixtyTwo.Add("11", "Merchant Channel");
            var dd = optionalSixtyTwo.ElementAt(2).Key;
            IDictionary<string, string> indexNameValue = new Dictionary<string, string>();

            while (rq != "")
            {
                var index = rq.Substring(0, 2);
                var lenth = rq.Substring(2, 2);
                var value = rq.Substring(4, Convert.ToInt32(lenth));
                rq = rq.Substring(4 + Convert.ToInt32(lenth));
                var name = optionalSixtyTwo[index];
                indexNameValue.Add(name, value);
            }

            var ddddd = indexNameValue;
            string[,] Tablero = new string[2, 2];


            return indexNameValue;

        }


        static IDictionary<string, string> DecodeUnionPayRQPart(string UnionPayRQPartString)
        {
            IDictionary<string, string> UnionPayRQPart = new Dictionary<string, string>();

            var acquirer = UnionPayRQPartString.Substring(0, 8);
            var forwarding = UnionPayRQPartString.Substring(8, 8);
            var merchantId = UnionPayRQPartString.Substring(16, 15);

            UnionPayRQPart.Add("Acquirer IIN", acquirer);
            UnionPayRQPart.Add("Forwarding IIN", forwarding);
            UnionPayRQPart.Add("Merchant ID", merchantId);
            return UnionPayRQPart;
        }




    }
}

