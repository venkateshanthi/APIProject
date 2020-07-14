using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpAPIConsoleApp.Model
{
    public class Posts
    {

        public string id { get; set; }
        public int cost { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string locationId { get; set; }
        public string familyId { get; set; }
    }
}
