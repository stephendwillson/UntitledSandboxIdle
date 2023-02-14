using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using BreakInfinity;

public class UpgradesController : MonoBehaviour
{
    public static UpgradesController instance;
    private void Awake() => instance = this;

    public List<Upgrades> clickUpgrades;
    public Upgrades clickUpgradePrefab;

    public ScrollRect clickUpgradesScroll;
    public Transform clickUpgradesPanel;

    public string[] clickUpgradeNames;

    public BigDouble[] clickUpgradeBaseCost;
    public BigDouble[] clickUpgradesBasePower;
    public BigDouble[] clickUpgradeCostMult;

    public void StartUpgradeController()
    {
        Utils.UpgradeCheck(ref GameController.instance.gamedata.clickUpgradeLevel, 7);

        clickUpgradeNames = new[]
        {
            // Rough idea is to use Fists + Chainsaw for temporary click/idle upgrades
            // Maybe Berserker pack == stronger fists, something like that
            // "Fists",
            // "Chainsaw",
            "Pistol",
            "Shotgun",
            "Super Shotgun",
            "Chaingun",
            "Rocket Launcher",
            "Plasma Gun",
            "BFG9000",

        };

        clickUpgradeBaseCost = new BigDouble[]
        {
            10,
            50,
            100,
            500,
            1000,
            2500,
            10000,
        };

        clickUpgradeCostMult = new BigDouble[]
        {
            1.25,
            1.35,
            1.45,
            1.55,
            1.65,
            1.75,
            1.85,
        };

        clickUpgradesBasePower = new BigDouble[]
        {
            1,
            5,
            10,
            25,
            50,
            100,
            250,
        };

        for (int i = 0; i < GameController.instance.gamedata.clickUpgradeLevel.Count; i++)
        {
            Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel);
            upgrade.UpgradeID = i;
            clickUpgrades.Add(upgrade);
        }

        clickUpgradesScroll.normalizedPosition = new Vector2(0, 0);

        UpdateClickUpgradeUI();
    }

    public void UpdateClickUpgradeUI(int UpgradeID = -1)
    {
        var gamedata = GameController.instance.gamedata;

        if (UpgradeID == -1)
            for (int i = 0; i < clickUpgrades.Count; i++)
                UpdateUI(i);
        else
            UpdateUI(UpgradeID);

        void UpdateUI(int ID)
        {
            clickUpgrades[ID].LevelText.text = gamedata.clickUpgradeLevel[ID].ToString();
            clickUpgrades[ID].CostText.text = $"-{ClickUpgradeCost(ID)} Credits";
            clickUpgrades[ID].BasePowerText.text = $"+{clickUpgradesBasePower[ID]} / Shot";
            clickUpgrades[ID].NameText.text = clickUpgradeNames[ID];
        }
    }

    // Get cost for specified Upgrade ID
    public BigDouble ClickUpgradeCost(int UpgradeID)
    {
        var gamedata = GameController.instance.gamedata;

        return clickUpgradeBaseCost[UpgradeID] * BigDouble.Pow(clickUpgradeCostMult[UpgradeID], gamedata.clickUpgradeLevel[UpgradeID]);
    }

    public void BuyUpgrade(int UpgradeID)
    {
        var gamedata = GameController.instance.gamedata;

        if (gamedata.uacCredits >= ClickUpgradeCost(UpgradeID))
        {
            gamedata.uacCredits -= ClickUpgradeCost(UpgradeID);
            gamedata.clickUpgradeLevel[UpgradeID] += 1;
        }

        UpdateClickUpgradeUI(UpgradeID);
    }
}
