using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lunch.Data
{
    public class Restaurant
    {
        private int restId;
        private string restName;
        private string signature;
        private string category;

        public int RestId { get => restId; set => restId = value; }
        public string RestName { get => restName; set => restName = value; }
        public string Signature { get => signature; set => signature = value; }
        public string Category { get => category; set => category = value; }
    }
}
