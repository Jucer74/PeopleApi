using System;

namespace People.Api.Requests
{
    public class PersonRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public char Sex { get; set; }
    }
}