namespace Dungeon_Crawl
{
    internal class CastleBoss_Dragon : Boss
    {
        public CastleBoss_Dragon()
        {
            enemyType = "dragon";
            numOfPhases = 1;
            currentPhase = 0;
            phaseStats = new double[numOfPhases, 6];

            setPhases();
            startPhase();

            exp = 300;
            money = 200;
        }

        public override void setPhases()
        {
            phaseStats[0, 0] = 200;
            phaseStats[0, 1] = 200;
            phaseStats[0, 2] = 20;
            phaseStats[0, 3] = 10;
            phaseStats[0, 4] = 15;
            phaseStats[0, 5] = 9;
        }
        public override void startPhase()
        {
            setMaxHealth(phaseStats[currentPhase, 0]);
            setHealth(phaseStats[currentPhase, 1]);
            setStrength(phaseStats[currentPhase, 2]);
            setMagic(phaseStats[currentPhase, 3]);
            setDefense(phaseStats[currentPhase, 4]);
            setResistance(phaseStats[currentPhase, 5]);
        }
    }
}
