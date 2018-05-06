using System;
using System.Xml.Serialization;

namespace Task2
{
    [XmlRoot("operation")]
    public class BankOperation: IComparable<BankOperation>
    {
        [XmlAttribute("type")]
        public string OperationType { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public int CompareTo(BankOperation other)
        {
            return Amount.CompareTo(other.Amount);
        }

        public override string ToString()
        {
            return $"Date: {this.Date}\nOperation type: {this.OperationType}\nAmount: {this.Amount}";
        }
    }
}