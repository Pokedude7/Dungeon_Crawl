using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Staff:Item
    {
        protected string staffType;
        public Staff()
        {
            itemType = "staff";
            statIncreases = "magic";
        }
        public void setStaffType(string staffType) { this.staffType = staffType; }
        public string getStaffType() { return this.staffType; }
    }
}
