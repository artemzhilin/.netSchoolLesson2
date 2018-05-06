using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Task1
{
    [XmlRoot("cl")]
    public class ClientInfoMalformed
    {
        [MatchTarget("FirstName")]
        public string fn { get; set; }
        
        [MatchTarget("LastName")]
        public string ln { get; set; }
        
        [MatchTarget("MiddleName")]
        public string mn { get; set; }
        
        [MatchTarget("PhoneNumber")]
        public string p { get; set; }
        
        [MatchTarget("Email")]
        public string e { get; set; }
        
        public int bd { get; set; }
        public int bm { get; set; }
        public int by { get; set; }
        public string hl1 { get; set; }
        public string hc { get; set; }
        public string hs { get; set; }
        public string hz { get; set; }
        public string wl1 { get; set; }
        public string wc { get; set; }
        public string ws { get; set; }
        public string wz { get; set; }
        
        [XmlIgnore]
        public DateTime Birthday
        {
            get
            {
                return new DateTime(by, bm, bd);
            }
            set { Birthday = value; }
        }
        
        [XmlIgnore]
        public ClientAddress HomeAddress
        {
            get
            {
                return new ClientAddress {Line1 = hl1, City = hc, State = hs, Zip = hz};
            }
            set { HomeAddress = value; }
        }
        
        [XmlIgnore]
        public ClientAddress WorkAddress
        {
            get
            {
                return new ClientAddress {Line1 = wl1, City = wc, State = ws, Zip = wz};
            }
            set { WorkAddress = value; }
        }
    }
}