using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Jewlery:Item
    {
        protected string jewleryType;
        public Jewlery()
        {
            itemType = "jewlery";
            statIncreases = "resistance";
        }
        public void setJewleryType(string jewleryType) { this.jewleryType = jewleryType; }
        public string getJewleryType() { return this.jewleryType; }
    }
}
