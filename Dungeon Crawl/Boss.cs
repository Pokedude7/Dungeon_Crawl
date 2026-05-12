namespace Dungeon_Crawl
{
    internal class Boss : Enemy
    {
        protected int numOfPhases;
        protected int currentPhase;
        protected double[,] phaseStats;
        public Boss()
        {
            //enemyType = "boss";
            //setMaxHealth();
            //setHealth();
            //setStrength();
            //setMagic(0);
            //setDefense();
            //setResistance();
            //exp = ran.Next();
            //money = ran.Next();

            //randomItem = ran.Next(1, 4);
        }

        public virtual void setPhases() { }
        public virtual void startPhase() { }

        public void setNumOfPhases(int numOfPhases)
        {
            this.numOfPhases = numOfPhases;
        }
        public void setCurrentPhase(int currentPhase)
        {
            this.currentPhase = currentPhase;
        }
        public void setPhaseStats(double[,] phaseStats)
        {
            this.phaseStats = phaseStats;
        }

        public int getNumOfPhases()
        {
            return this.numOfPhases;
        }
        public int getCurrentPhase()
        {
            return this.currentPhase;
        }
        public double[,] getPhaseStats()
        {
            return this.phaseStats;
        }
    }
}