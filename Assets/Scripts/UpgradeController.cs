using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class UpgradeController : MonoBehaviour
{
    public static UpgradeController instance;
    private void Awake() => instance = this;

    public Upgrade shotUpgrade;

    public string shotUpgradeName;

    public BigDouble shotUpgradeBaseCost;
    public BigDouble shotUpgradeCostMult;

    public void StartUpgradeController()
    {
        shotUpgradeName = "Pistol Upgrade";
        shotUpgradeBaseCost = 10;
        shotUpgradeCostMult = 1.5;

        UpdateShotUpgradeUI();
    }

    public void UpdateShotUpgradeUI()
    {
        var gamedata = GameController.instance.gamedata;

        shotUpgrade.LevelText.text = "Level: " + gamedata.shotUpgradeLevel.ToString();
        shotUpgrade.CostText.text = "Cost: " + Cost().ToString("F2") + " Credits";
        shotUpgrade.NameText.text = shotUpgradeName;
    }

    public BigDouble Cost() => shotUpgradeBaseCost * BigDouble.Pow(shotUpgradeCostMult, GameController.instance.gamedata.shotUpgradeLevel);

    public void BuyUpgrade()
    {
        var gamedata = GameController.instance.gamedata;

        if (gamedata.uacCredits >= Cost())
        {
            gamedata.uacCredits -= Cost();
            gamedata.shotUpgradeLevel += 1;
        }

        UpdateShotUpgradeUI();
    }


}
