using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poleo.Objects
{
    public class DOT_Inventory
    {
        private string description;
        private string itemCategory;
        private string count_Unit;
        private Single unitPrice;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string ItemCategory
        {
            get { return itemCategory; }
            set { itemCategory = value; }
        }

        public string Count_Unit
        {
            get { return count_Unit; }
            set { count_Unit = value; }
        }

        public Single UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
    }
}