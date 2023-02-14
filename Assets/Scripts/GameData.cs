using System.Collections;
using System.Collections.Generic;

using BreakInfinity;

public class GameData
{
    public BigDouble uacCredits;

    public List<BigDouble> clickUpgradeLevel;

    // currently number of available weapons, 7...fist + chainsaw maybe coming later
    public int numUpgrades = 7;

    public GameData()
    {
        uacCredits = 0;

        clickUpgradeLevel = Utils.CreateList<BigDouble>(numUpgrades);
    }

}
