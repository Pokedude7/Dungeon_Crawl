using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Armor: Item
    {
        protected string armorType;
        public Armor()
        {
            itemType = "armor";
            statIncreases = "def";
        }
        public void setArmorType(string armorType) { this.armorType = armorType; }
        public string getArmorType() {  return this.armorType; }
    }
}
