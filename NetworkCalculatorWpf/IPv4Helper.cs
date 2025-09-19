using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkCalculatorWpf;

public class IPv4Helper
{

   
    static public long GetDez(string strDezOctet)
    { 
        long ip4 = 0;

        string[] strParts = strDezOctet.Split(new string[] {"."}, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < strParts.Length; i++) 
        {
            string strDez = strParts[i];
            strDez = strDez.Trim();
            byte byteOctet = 0;
            if (Byte.TryParse(strDez, out byteOctet))
            {
                ip4 = ip4 * 256 + byteOctet;
            }
        }
        return ip4;
    }

    static public string GetBinOctet(long ip4)
    {
        string strBin = "";
        long lMod = 0;
        long lDiv = ip4;

        for (int i = 0; i < 32; i++)
        {
            lMod = lDiv % 2;
            lDiv = lDiv / 2;
            strBin = lMod.ToString() + strBin;

            if(i % 8 == 7 && i > 0 && i < 31)
                strBin = "." + strBin;

        }
        return strBin;
    }

    static public string GetDezOctet(long ip4)
    {
        string strDezOctet = "";
        long lMod = 0;
        long lDiv = ip4;

        for (int i = 0; i < 4; i++)
        {
            lMod = lDiv % 256;
            lDiv = lDiv / 256;
            strDezOctet = lMod.ToString() + strDezOctet;
            if(i < 3)
                strDezOctet += "." + strDezOctet;
        }
        return strDezOctet;
    }

    static public long GetHosts(int cidr)
    { 
        long lhosts = 0;
        if (cidr < 32)
            lhosts = Convert.ToInt64(Math.Pow(2, 32 - cidr) - 2);
        return lhosts;
    }

    static public long GetNetmaskDez(int cidr) 
    {
        long lDez = 0;
        for (int i = 0; i < 32; i++)
        {
            if (i < cidr)
            {
                lDez = lDez * 2 + 1;
            }
            else
            {
                lDez = lDez * 2;
            }
        }
        return lDez;
    }

    static public long GetWildcardDez(int cidr)
    {
        long lDez = 0;
        for (int i = 0; i < (32 - cidr); i++)
        {
            lDez = lDez * 2 + 1;
        }
        return lDez;
    }


}
