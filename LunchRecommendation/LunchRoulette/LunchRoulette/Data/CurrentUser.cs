using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchRoulette.Data
{
    internal class CurrentUser
    {
        private static CurrentUser currentUser = null;
        private int id;

        private CurrentUser()
        {
        }
        public int Id { get => id; set => id = value; }

        public static CurrentUser getInstance()
        {
            if(currentUser == null)
            {
                currentUser = new CurrentUser();
            }
            return currentUser;
        }
    }
}
