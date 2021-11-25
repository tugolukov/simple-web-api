using System;

namespace SImpleWebApplication.API.Models
{
    public class Note
    {
        public Guid Guid { get; set;  }
        public string Body { get; set; }

        public Note()
        {
        }

        public Note(string body) : this()
        {
            Guid = Guid.NewGuid();
            Body = body;
        }
    }
}