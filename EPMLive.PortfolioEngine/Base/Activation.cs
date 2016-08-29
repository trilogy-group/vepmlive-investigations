using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace PortfolioEngineCore
{
    internal class Activation : AllCore
    {
        private string _pid;
        private string _company;
        private char[] keyArr1 = { 'F', 'T', 'B', 'E', 'C', 'P', 'Z', 'N', 'X', 'L', 'J', 'S', 'H', 'M', 'W', 'G' };
        private char[] keyArr2 = { 'X', 'V', 'A', 'C', 'B', 'F', 'Y', 'N', 'U', 'H', 'M', 'E', 'I', 'O', 'Q', 'Z' };

        private const int stringLen = 34; //Only used as an initial check in 'validateString'

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

        public Activation(Debugger debug)
            : base(debug)
        {

        }

        public void checkActivation(string basepath, string pid, string company)
        {
            _pid = pid;
            _company = company;
            if(basepath != "")
            {
                debug.AddMessage("Activation: Using Basepath (" + basepath + ")");
                getpid(basepath);
            }
            else
            {
                debug.AddMessage("Activation: Using PID (" + pid + ") (" + company + ")");
                if(_pid == "")
                {
                    throw new PFEException((int) PFEError.ActivationNoPId, "No PID Specified.");
                }
                if(_company == "")
                {
                    throw new PFEException((int) PFEError.ActivationNoCompany, "No Company Specified.");
                }
                bool bValidSecurityString = ValidatePID(_pid);
                bool bValidClientName = ValidateClient(_pid, _company);

                if(!bValidSecurityString)
                {
                    throw new PFEException((int) PFEError.ActivationInvalidPId, "Invalid PID");
                }
                if(!bValidClientName)
                {
                    throw new PFEException((int) PFEError.ActivationInvalidCompany, "Invalid Company PID Combination");
                }
            }
        }

        //EPML-4761: Store PFE SQL ConnectionString encrypted
        private void getpid(string basepath)
        {
            try
            {
                RegistryKey key = Utilities.GetRegistryKey(basepath);
                if (key != null)
                {
                    var pid = key.GetValue("PID");
                    var company = key.GetValue("CN");

                    _pid = (pid != null ? pid.ToString() : string.Empty);
                    _company = (company != null ? company.ToString() : string.Empty);
                }
            }
            catch
            {
                throw new PFEException((int)PFEError.ActivationCantLoadPId, message: "Could not load product PID");
            }
        }
        //END EPML-4761
    
        public bool ValidateClient(string s, string c)
        {
            try
            {
                string strClt = s.Substring(14, 4);
                return (strClt == encipher(getCRC(c.Trim()), 4, whichArr(vars.v_client), whichDir(vars.v_client)));
            }
            catch { }
            return false;
        }

        public bool ValidatePID(string sPID)
        {
            if(sPID.Length != stringLen)
                return false;

            string sCRC = sPID.Substring(sPID.Length - 4, 4);
            string s = sPID.Substring(0, 6) + sPID.Substring(7, 6) + sPID.Substring(14, 6) + sPID.Substring(21, 6) + sPID.Substring(28, 2);

            char[] arr = s.ToCharArray();
            int properCRC = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                properCRC = ((int)arr[i]) * (1 + ((i + 1) % 17)) ^ properCRC;
            }
            return (sCRC == encipher(properCRC, 4, whichArr(vars.v_crc), whichDir(vars.v_crc)));
        }
        
        private int getCRC(string s)
        {
            int crc = 0;
            char[] arr = s.ToCharArray();
            for(int i = 0; i < s.Length; i++)
            {
                crc = ((int)arr[i]) * (1 + ((i + 1) % 17)) ^ crc;
            }
            return crc;
        }

        //Which of the two cipher arrays to use
        private int whichArr(vars v)
        {
            switch(v)
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
        private bool whichDir(vars v)
        {
            switch(v)
            {
                case vars.v_toDt:
                case vars.v_products:
                case vars.v_client:
                    return false;
                default:
                    return true;
            }
        }

        private string encipher(int p, int size, int a, bool r)
        {
            string e = "";
            for(int i = 0; i < size; i++)
            {
                int pHalfByte = p % 16;
                int t = pHalfByte;
                if(r)
                    pHalfByte = 15 - pHalfByte;

                if(a == 0)
                    e = keyArr1[pHalfByte] + e;
                else
                    e = keyArr2[pHalfByte] + e;

                p /= 16;

                if((t + (i + 1)) % 2 == 0) //Switch between arrays sometimes
                {
                    if(a == 1)
                        a = 0;
                    else
                        a = 1;
                }
            }
            return e;
        }
    }
}
