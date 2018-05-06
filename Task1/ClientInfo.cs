using System;

namespace Task1
{
    public class ClientInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public ClientAddress HomeAddress { get; set; }
        public ClientAddress WorkAddress { get; set; }
    }
}