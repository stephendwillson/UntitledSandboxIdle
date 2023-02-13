using System.Collections;
using System.Collections.Generic;

using BreakInfinity;

public class GameData
{
    public BigDouble uacCredits;

    public List<BigDouble> clickUpgradeLevel;

    public GameData()
    {
        uacCredits = 0;

        clickUpgradeLevel = Utils.CreateList<BigDouble>(3);
    }

}
