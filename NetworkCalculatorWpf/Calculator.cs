using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkCalculatorWpf;

public class Calculator
{
    public string Adress { get; private set; }
    public long AdressDez {  get; private set; }
    public string Cidr { get; private set; }
    public int CidrDez { get; private set; }
    public long NetmaskDez { get; private set; }
    public long WildcardDez { get; private set; }
    public long BroadcastDez { get; private set; }
    public long NetAdressDez { get; private set; }


    public Calculator(string adress, string cidr) 
    {
        Adress = adress.Trim();
        Cidr = cidr.Trim();
    }

}
