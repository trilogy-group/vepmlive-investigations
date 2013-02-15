using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace WorkEnginePPM
{
    internal class Security
    {
	    public enum vars : int
        {
		    v_toDt = 0,
		    v_fromDt = 1,
		    v_client = 2,
		    v_users = 3,
		    v_products = 4,
		    v_license = 5,
		    v_crc = 6,
		    v_evusers = 7
	    }

        public enum ProductFlag : uint
        {
            pfTS_Obsolete_Bit0 = 0x1,
            pfSuite = 0x2,
            pfSPWorkEngine = 0x4,
            pfBit3 = 0x8,
            pfBit4 = 0x10,
            pfCountIsUsers = 0x20,  // was MPPlus flag chaged for PE 4.2
            pfEV = 0x40,
            pfCost = 0x80
        }

        public enum LicenseType : int
        {
            ltEvaluation = 1,
            ltFull = 2
        }


        private static char[] keyArr1 = {'F', 'T', 'B', 'E', 'C', 'P', 'Z', 'N', 'X', 'L', 'J', 'S', 'H', 'M', 'W', 'G'};
        private static char[] keyArr2 = {'X', 'V', 'A', 'C', 'B', 'F', 'Y', 'N', 'U', 'H', 'M', 'E', 'I', 'O', 'Q', 'Z'};

        private const int stringLen = 34; //Only used as an initial check in 'validateString'

        private static DateTime epoch
        {
            get
            {
                DateTime dt;
                bool b = DateTime.TryParse("01/01/2000", out dt);
                return dt;
            }
        }


        public static bool ValidatePID(string sPID)
        {
		    if (sPID.Length != stringLen)
			    return false;
            
            string sCRC = sPID.Substring(sPID.Length - 4, 4);
            string s = sPID.Substring(0, 6) + sPID.Substring(7, 6) + sPID.Substring(14, 6) + sPID.Substring(21, 6) + sPID.Substring(28, 2);

            char[] arr = s.ToCharArray();
            int properCRC = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                properCRC = ((int)arr[i]) * (1 + ((i+1) % 17)) ^ properCRC;
            }
            return (sCRC == encipher(properCRC, 4, whichArr(vars.v_crc), whichDir(vars.v_crc)));
        }

        private static int getCRC(string s)
        {
            int crc = 0;
            char[] arr = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                crc = ((int)arr[i]) * (1 + ((i+1) % 17)) ^ crc;
            }
            return crc;
        }
        
        //Which of the two cipher arrays to use
        private static int whichArr(vars v)
        {
            switch (v)
            {
                case vars.v_toDt:
                case vars.v_license:
                case vars.v_crc:
                case vars.v_users:
                    return 1;
                default:
                    return 0;
            }
        }

        //True  = reverse direction (start from end of array)
        private static bool whichDir(vars v)
        {
            switch (v)
            {
                case vars.v_toDt:
                case vars.v_products:
                case vars.v_client:
                    return false;
                default:
                    return true;
            }
        }

        private static string encipher(int p, int size, int a, bool r)
        {
            string e = "";
            for (int i=0; i<size; i++)
            {
                int pHalfByte = p % 16;
                int t = pHalfByte;
                if (r)
                    pHalfByte = 15 - pHalfByte;

                if (a == 0)
                    e = keyArr1[pHalfByte] + e;
                else
                    e = keyArr2[pHalfByte] + e;

                p /= 16;

                if ((t + (i+1)) % 2 == 0) //Switch between arrays sometimes
                {
                    if (a == 1)
                        a = 0;
                    else
                        a = 1;
                }
            }
            return e;
        }

        private static int charInd(char c, int a)
        {
            char[] arr;
            if (a == 0)
                arr = keyArr1;
            else
                arr = keyArr2;
            for (int i=0; i<16; i++)
            {
                if (arr[i] == c)
                    return i;
            }
            return -1;
        }

        private static int decipher(string e, int a, bool r)
        {
            int p = 0;
            char[] arr = e.ToCharArray();
            int size = arr.Length;
            for (int i=0; i<size; i++)
            {
                int part = charInd(arr[size - i - 1], a);

                if (r)
                    part = 15 - part;
                if ((part + i + 1) % 2 == 0)
                {
                    if (a == 1)
                        a = 0;
                    else
                        a = 1;
                }
                part *= (int)(Math.Pow(16,i));
                p += part;
            }
            return p;
        }

        public static string GetData(string sPID, vars eItem)
        {
            string sRet = "";
            string s = "";
            int t = 0;
            switch (eItem)
            {
                case vars.v_toDt:
                    s = sPID.Substring(0, 4);
                    t = decipher(s, whichArr(vars.v_toDt), whichDir(vars.v_toDt));
                    sRet = epoch.AddDays((double)t).ToShortDateString();
                    break;
                case vars.v_fromDt:
                    s = sPID.Substring(7, 4);
                    t = decipher(s, whichArr(vars.v_fromDt), whichDir(vars.v_fromDt));
                    sRet = epoch.AddDays((double)t).ToShortDateString();
                    break;
                case vars.v_license:
                    s = sPID.Substring(11, 2);
                    sRet = decipher(s, whichArr(vars.v_license), whichDir(vars.v_license)).ToString();
                    break;
                case vars.v_products:
                    s = sPID.Substring(4, 2);
                    sRet = decipher(s, whichArr(vars.v_products), whichDir(vars.v_products)).ToString();
                    break;
                case vars.v_users:
                    s = sPID.Substring(18, 2) + sPID.Substring(21, 2);
                    sRet = decipher(s, whichArr(vars.v_users), whichDir(vars.v_users)).ToString();
                    break;
                case vars.v_evusers:
                    s = sPID.Substring(23, 4);
                    sRet = decipher(s, whichArr(vars.v_evusers), whichDir(vars.v_evusers)).ToString();
                    break;

            }
            return sRet;
        }
	
        public static string encodeString(string client, int users, int products, int license, string fromDt, string toDt, int evusers)
        {
            string enc = "";
            int i = 0;

            client = client.Trim();
            fromDt = fromDt.Trim();
            DateTime dtFrom;
            bool b;
            b = DateTime.TryParse(fromDt, out dtFrom);
            DateTime dtTo;
            toDt = toDt.Trim();
            b = DateTime.TryParse(toDt, out dtTo);
            

            if (license < 0)
                license = 0;
            if (products < 0)
                products = 0;
            if (users < 0)
                users = 0;
            if (evusers < 0)
                evusers = 0;

            Random rand = new Random();

            if (toDt != "")
            {
                TimeSpan ts = dtTo.Subtract(epoch);
                i = ts.Days;
            }
            else
                i = 10000 + (int)(20000 * rand.NextDouble());

            if (i > 32767)
                i = 32767;
            if (i < 0)
                i = 0;
            enc = encipher(i, 4, whichArr(vars.v_toDt), whichDir(vars.v_toDt));

            enc += encipher(products, 2, whichArr(vars.v_products), whichDir(vars.v_products));

    //If fromDt <> "" Then i = DateDiff("d", epoch, fromDt) Else i = 0
            if (fromDt != "")
            {
                TimeSpan ts = dtFrom.Subtract(epoch);
                i = ts.Days;
            }

            if (i > 32767)
                i = 32767;
            if (i < 0)
                i = 0;
            enc += encipher(i, 4, whichArr(vars.v_fromDt), whichDir(vars.v_fromDt));
            enc += encipher(license, 2, whichArr(vars.v_license), whichDir(vars.v_license));
            enc += encipher(getCRC(client), 4, whichArr(vars.v_client), whichDir(vars.v_client));
            enc += encipher(users, 4, whichArr(vars.v_users), whichDir(vars.v_users));

            enc = enc + encipher(evusers, 4, whichArr(vars.v_evusers), whichDir(vars.v_evusers));
            int spare = 0;
            spare = (int)(512 * rand.NextDouble());
            enc += encipher(spare, 2, whichArr(vars.v_crc), whichDir(vars.v_crc));

            enc += encipher(getCRC(enc), 4, whichArr(vars.v_crc), whichDir(vars.v_crc));

            string sPID = "";
            for (int j = 0; j<5; j++)
            {
                if (sPID != "")
                    sPID += "-";
                sPID += enc.Substring(j*6, 6);
            }

            return sPID;
        }

        public static bool ValidateClient(string s, string c)
        {
            string strClt = s.Substring(14, 4);
            return (strClt == encipher(getCRC(c.Trim()), 4, whichArr(vars.v_client), whichDir(vars.v_client)));
        }



        public static string HashPassword(string user, string pwd)
        {
            string hashedPwd = HashUserPassword(user, pwd, "DA39A3EE5E6B4B0D3255BFEF95601890AFD80709");
            return hashedPwd;
        }

        public static string HashUserPassword(string userName, string password, string salt)
        {
            string s = userName.ToLower() + password + salt;
            SHA1 sha = new SHA1Managed();
            ASCIIEncoding ae = new ASCIIEncoding();
            byte[] data = ae.GetBytes(s);
            byte[] digest = sha.ComputeHash(data);
            return GetAsString(digest);
        }

        private static string GetAsString(byte[] bytes)
        {
            StringBuilder s = new StringBuilder();
            int length = bytes.Length;
            for (int n = 0; n < length; n++)
            {
                s.AppendFormat("{0:X2}", (int)bytes[n]);
            }
            return s.ToString();
        }
    }
}