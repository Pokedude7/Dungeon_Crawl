namespace Dungeon_Crawl
{
    internal class Player:Stats
    {
        double weaponAdd;
        double armorAdd;
        double staffAdd;
        double jewleryAdd;

        public Player()
        {
            strength = 0;
            defense = 0;
            magic = 0;
            resistance = 0;
            health = 10;
            maxHealth = 10;
            money = 0;
            level = 1;
            exp = 0;
        }

        public void setArmorAdd(double armorAdd)
        {
            this.armorAdd = armorAdd;
        }
        public void setWeaponAdd(double weaponAdd)
        {
            this.weaponAdd = weaponAdd;
        }
        public void setStaffAdd(double staffAdd)
        {
            this.staffAdd = staffAdd;
        }
        public void setJewleryAdd(double jewleryAdd)
        {
            this.jewleryAdd = jewleryAdd;
        }

        public override double getStrength()
        {
            return strength + weaponAdd;
        }
        public override double getDefense()
        {
            return defense + armorAdd;
        }
        public override double getMagic()
        {
            return magic + staffAdd;
        }
        public override double getResistance()
        {
            return resistance + jewleryAdd;
        }

        public void addMoney(double money)
        {
            this.money += money;
        }
        public void addExp(double exp)
        {
            this.exp += exp;
            if (exp >= 30 * level)
            {
                levelUp();
            }
        }
        public void levelUp()
        {
            exp -= 20 * level;
            maxHealth += 5 * level;
            health = maxHealth;
            strength += 2 * level;
            defense += 1 * level;
            magic += 1 * level;
            level++;
        }
        public void checkLevelUp()
        {
            if (exp >= 20 * level)
            {
                levelUp();
            }
        }
    }
}
