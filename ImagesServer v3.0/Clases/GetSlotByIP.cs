using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ImagesServer_v3._0
{
    class GetSlotByIP
    {
        public string IPAdress { get; set; }
        public int SlotNumber { get; set; }

        public GetSlotByIP()
        {
            this.IPAdress = string.Empty;
            this.SlotNumber = 0;
        }
       
        public void GetSlotByIPV4()
        {
            IPAdress = GetLocalIPAddress();

            string _slot1 = "10.51.170.119";
            string _slot2 = "10.51.170.61";
            string _slot3 = "10.51.170.116";
            string _slotMyPc = "10.51.42.24";

            if (IPAdress == _slot1) SlotNumber = 1; 
            if (IPAdress == _slot2) SlotNumber = 2; 
            if (IPAdress == _slot3) SlotNumber = 3; 
            
            if (IPAdress == _slotMyPc) SlotNumber = 100;    
        }

         public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {                   
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
