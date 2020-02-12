using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SSRS_RDLC_Reports.Common
{
    public static class CommonFormat
    {

        public static string PhoneNumberFormat(string extension, string phone)
        {
            if (!(string.IsNullOrEmpty(extension) || string.IsNullOrEmpty(phone)))
            {
                if (phone.Length >= 7)
                    return "(" + extension + ") " + phone.Substring(0, 3) + "-" + phone.Substring(3);
                else
                    return string.Empty;

            }
            else
                return string.Empty;

        }
        public static string PhoneFormat(string Phone)
        {
            try
            {
                if (Phone.Length >= 10)
                {
                    return "(" + Phone.Substring(0, 3) + ") " + Phone.Substring(3, 3) + "-" + Phone.Substring(6, 4);
                }
                else
                    return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }
        public static string SSNFormat(string ssn)
        {
            try
            {
                if (ssn.Length >= 9)
                {
                    return ssn.Substring(0, 3) + "-" + ssn.Substring(3, 2) + "-" + ssn.Substring(5, 4);
                }
                else
                    return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }

        public static string DOBFormat(string dob)
        {
            if (!(string.IsNullOrEmpty(dob)))
            {
                if (dob.Length >= 8)
                    return dob.Substring(0, 2) + "/" + dob.Substring(2, 2) + "/" + dob.Substring(4);
                else
                    return string.Empty;


            }
            else
                return string.Empty;
        }

     
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            if (str != null)
            {
                foreach (char c in str)
                {
                    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                    {
                        sb.Append(c);
                    }
                }

                return sb.ToString();
            }
            else
                return string.Empty;
        }

        public static string GetPayeeLastName(string PayeeName)
        {
            var payeeLastName = string.Empty;
            if (PayeeName != null && PayeeName != "")
            {
                if (PayeeName.Split(',').Length > 0)
                {
                    payeeLastName = PayeeName.Split(',')[0];
                }
            }
            return payeeLastName;
        }
        public static string GetPayeeFirstName(string PayeeName)
        {
            var payeeFirstName = string.Empty;
            if (PayeeName != null && PayeeName != "")
            {
                if (PayeeName.Split(',').Length > 1)
                {
                    payeeFirstName = PayeeName.Split(',')[1];
                }
            }
            return payeeFirstName;
        }
      
    }

}