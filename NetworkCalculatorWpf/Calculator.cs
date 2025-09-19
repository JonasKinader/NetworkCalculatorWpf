using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkCalculatorWpf;

public class Calculator
{
    public string Address { get; private set; }
    public long AddressDez {  get; private set; }
    public string Cidr { get; private set; }
    public int CidrDez { get; private set; }
    public long NetmaskDez { get; private set; }
    public long WildcardDez { get; private set; }
    public long BroadcastDez { get; private set; }
    public long NetAddressDez { get; private set; }


    public Calculator(string adress, string cidr) 
    {
        Address = adress.Trim();
        Cidr = cidr.Trim();
    }

    public List<NetworkDetail> Calculate() 
    {
        List<NetworkDetail> networkDetails = new List<NetworkDetail>();
        networkDetails.Add(AdresseBestimmen());
        networkDetails.Add(NetzmaskeBestimmen());
        networkDetails.Add(WildcardBestimmen());
        networkDetails.Add(NetzAdresseBestimmen());
        networkDetails.Add(BroadcastAdresseBestimmen());
        networkDetails.Add(HostMinBestimmen());
        networkDetails.Add(HostMaxBestimmen());
        networkDetails.Add(AnzahlHostsBestimmen());
        return networkDetails;

    }

    private NetworkDetail AdresseBestimmen()
    {
        try
        {
            AddressDez = IPv4Helper.GetDez(Address);
            string AdressBin = IPv4Helper.GetBinOctet(AddressDez);
            return new NetworkDetail("Adress", AddressDez, Address, AdressBin);
        }
        catch (Exception ex)
        {
            return new NetworkDetail("Address", false, ex.ToString());
        }
    }

    private NetworkDetail NetzmaskeBestimmen()
    {
        try
        {
            CidrDez = Convert.ToInt32(Cidr);
            NetmaskDez = IPv4Helper.GetNetmaskDez(CidrDez);
            string NetmaskBin = IPv4Helper.GetBinOctet(NetmaskDez);
            string Netmask = IPv4Helper.GetDezOctet(NetmaskDez);
            return new NetworkDetail("Netmask", NetmaskDez, Netmask, NetmaskBin);
        }
        catch (Exception ex)
        {
            return new NetworkDetail("Netmask", false, ex.ToString());
        }
    }

    private NetworkDetail WildcardBestimmen()
    {
        try
        {
            WildcardDez = IPv4Helper.GetWildcardDez(CidrDez);
            string WildcardBin = IPv4Helper.GetBinOctet(WildcardDez);
            string Wildcard = IPv4Helper.GetDezOctet(WildcardDez);
            return new NetworkDetail("Wildcard", WildcardDez, Wildcard, WildcardBin);
        }
        catch (Exception ex)
        {
            return new NetworkDetail("Wildcard", false, ex.ToString());
           
        }
    }

    private NetworkDetail NetzAdresseBestimmen()
    {
        try
        {
            NetAddressDez = AddressDez & NetmaskDez;
            string NetAddressBin = IPv4Helper.GetBinOctet(NetAddressDez);
            string NetAddress = IPv4Helper.GetDezOctet(NetAddressDez);
            return new NetworkDetail("Network", NetAddressDez, NetAddress, NetAddressBin);

        }
        catch(Exception ex)
        { 
            return new NetworkDetail("Network", false, ex.ToString());
        }
    }

    private NetworkDetail BroadcastAdresseBestimmen() 
    {
        try
        {
            BroadcastDez = AddressDez | WildcardDez;
            string BroadcastBin = IPv4Helper.GetBinOctet(BroadcastDez);
            string Broadcast = IPv4Helper.GetDezOctet(BroadcastDez);
            return new NetworkDetail("Network", BroadcastDez, Broadcast, BroadcastBin);
        }
        catch (Exception ex)
        {

            return new NetworkDetail("Network", false, ex.ToString());
        }
    }

    private NetworkDetail HostMinBestimmen() 
    {
        try
        {
            long HostMinDez = NetAddressDez + 1;
            string HostMinBin = IPv4Helper.GetBinOctet(HostMinDez);
            string HostMin = IPv4Helper.GetDezOctet(HostMinDez);
            return new NetworkDetail("HostMin", HostMinDez, HostMin, HostMinBin);
        }
        catch (Exception ex)
        {

           return new NetworkDetail("HostMin", false, ex.ToString());
        }
    }

    private NetworkDetail HostMaxBestimmen()
    {
        try
        {
            long HostMaxDez = BroadcastDez - 1;
            string HostMaxBin = IPv4Helper.GetBinOctet(HostMaxDez);
            string HostMax = IPv4Helper.GetBinOctet(HostMaxDez);
            return new NetworkDetail("HostMax", HostMaxDez, HostMax, HostMaxBin);
        }
        catch (Exception ex)
        {

            return new NetworkDetail("HostMax", false, ex.ToString());
        }
    }

    private NetworkDetail AnzahlHostsBestimmen() 
    {
        try
        {
            
            long anzHostsDez = IPv4Helper.GetHosts(CidrDez);
            string anzHostsBin = IPv4Helper.GetBinOctet(anzHostsDez);
            string Hosts = IPv4Helper.GetBinOctet(anzHostsDez);
            return new NetworkDetail("AnzahlHosts", anzHostsDez, Hosts, anzHostsBin );
        }
        catch (Exception ex)
        {

            return new NetworkDetail("AnzahlHosts", false, ex.ToString());
        }
    }
}
