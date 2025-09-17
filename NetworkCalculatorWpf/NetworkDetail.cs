using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkCalculatorWpf;

public class NetworkDetail
{
    public string Bezeichnung { get; private set; }
    public long DezimalWert { get; private set; }
    public string OktettString { get; private set; }
    public string Binärstring { get; private set; }
    public bool Erfolgreich { get; private set; } = true;
    public string FehlerString { get; private set; } = "";


    public NetworkDetail( string bezeichnung, long dezimalwert, string oktett, string binär) 
    {
        Bezeichnung = bezeichnung;
        DezimalWert = dezimalwert;
        OktettString = oktett;
        Binärstring = binär;
    }

    public NetworkDetail(string bezeichnung, bool erfolgreich, string fehlerstring = "") 
    {
        Bezeichnung = bezeichnung;
        DezimalWert = 0;
        OktettString = "";
        Binärstring = "";
        Erfolgreich = erfolgreich;
        FehlerString = fehlerstring;
    }
}
