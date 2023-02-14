using UnityEngine;
using UnityEngine.UI;
using TMPro;

using BreakInfinity;

public class Upgrades : MonoBehaviour
{
    public int UpgradeID;
    public Image UpgradeButton;
    public TMP_Text NameText;
    public TMP_Text CostText;
    public TMP_Text LevelText;
    public TMP_Text BasePowerText;

    public void BuyClickUpgrade()
    {
        UpgradesController.instance.BuyUpgrade("click", UpgradeID);
    }

    public void BuyProductionUpgrade()
    {
        UpgradesController.instance.BuyUpgrade("idle", UpgradeID);
    }
}
