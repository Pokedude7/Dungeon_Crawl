namespace Dungeon_Crawl
{
    internal class Weapon : Item
    {
        protected string weaponType;
        public Weapon()
        {
            itemType = "weapon";
            statIncreases = "str";
        }
        public void setWeaponType(string weaponType) { this.weaponType = weaponType; }
        public string getWeaponType() { return this.weaponType; }
    }
}
