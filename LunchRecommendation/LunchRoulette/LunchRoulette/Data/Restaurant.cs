using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchRoulette.Data
{
    //r.name as restname, r.signature, r.category, u.name as username, t1.lastdate, t1.cnt
    internal class Restaurant
    {
        private int id;
        private string name;
        private string signature;
        private string category;
        private string userName;
        private string lastDate;
        private int count;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Signature { get => signature; set => signature = value; }
        public string Category { get => category; set => category = value; }
        public string UserName { get => userName; set => userName = value; }
        public string LastDate { get => lastDate; set => lastDate = value; }
        public int Count { get => count; set => count = value; }
    }
}
