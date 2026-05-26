namespace Dungeon_Crawl
{
    internal class Player:Stats
    {
        double weaponAdd;
        double armorAdd;
        double staffAdd;
        double jewleryAdd;
        double healAdd;

        public Player()
        {
            strength = 1;
            defense = 0;
            magic = 0;
            resistance = 0;
            health = 17;
            maxHealth = 17;
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
        public void setHealAdd(double healAdd)
        {
            this.healAdd = healAdd;
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
        public double getHeal()
        {
            return healAdd;
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
            exp -= 30 * level;
            maxHealth += 3 * level;
            health = maxHealth;
            strength = level;
            defense = level;
            if (level % 4 == 0 && level != 1)
            {
                magic = level;
            }
            level++;
        }
        public void checkLevelUp()
        {
            if (exp >= 30 * level)
            {
                levelUp();
            }
        }
    }
}
