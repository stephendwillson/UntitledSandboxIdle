using System.Collections;
using System.Collections.Generic;

using BreakInfinity;

public class GameData
{
    public BigDouble uacCredits;

    public List<int> clickUpgradeLevels;
    public List<int> productionUpgradeLevels;

    // currently number of available weapons, 7...fist + chainsaw maybe coming later
    public int numClickUpgrades = 7;

    // placeholder, no clue what I'm doing with production upgrades
    public int numProductionUpgrades = 5;

    public GameData()
    {
        uacCredits = 10000;

        clickUpgradeLevels = Utils.CreateList<int>(numClickUpgrades);
        productionUpgradeLevels = Utils.CreateList<int>(numProductionUpgrades);
    }

}
