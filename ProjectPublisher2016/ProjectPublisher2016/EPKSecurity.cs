using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPublisher2016
{
    public class EPKSecurity
    {
        public static string BuildAuthString(string sRequest, string sSessionInfo)
        {
            string s = sRequest + sSessionInfo;
            //s1 = EPK_Auth(s, "D8D06337-9C12-466D-84BF-57767FEDF8AD")
            // New auth string for v5
            string s1 = EPK_Auth(s, "6CED4158-9EEC-CFDC-87DD-54035E673B46");
            string s2 = EPK_Auth(s, s1);
            return (s2.Substring(0, 8) + "-" + s2.Substring(8, 4) + "-" + s2.Substring(12, 4) + "-" + s2.Substring(16, 4) + "-" + s2.Substring(20, 12));
        }

        private static string EPK_Auth(string sInput, string sKey)
        {

            byte[] bytArr1 = new byte[256];
            byte[] bytArr2 = new byte[256];
            string sVal = "0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"
                        + "0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"
                        + "0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"
                        + "0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF";

            for (int i = 0; i <= 255; i++) { bytArr1[i] = (byte)i; }

            int nKey = sKey.Length;

            char[] charKeyArr = sKey.ToCharArray();
            char[] charInputArr = sInput.ToCharArray();

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                if (j >= nKey) j = 0;
                bytArr2[i] = (byte)charKeyArr[j++];
            }

            j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + bytArr1[i] + bytArr2[i]) % 256; // % is vb Mod operator
                byte m = bytArr1[i];
                bytArr1[i] = bytArr1[j];
                bytArr1[j] = m;
            }


            int nInput = sInput.Length;
            string sResult = "";
            int i1 = 0;
            int j1 = 0;
            for (int k = 0; k < nInput; k++)
            {
                i1 = (i1 + 1) % 256;
                j1 = (j1 + bytArr1[i1]) % 256;
                int m = bytArr1[i1];
                bytArr1[i1] = bytArr1[j1];
                bytArr1[j1] = (byte)m;
                byte n1 = bytArr1[i1];
                byte n2 = bytArr1[j1];
                byte n3 = (byte)((n1 + n2) % 256);
                byte n4 = bytArr1[n3];
                int nVal = (int)(charInputArr[k] ^ n4); // ^ is Xor
                sResult += sVal.Substring(nVal, 1);
            }
            return sResult;
        }
    }
}
