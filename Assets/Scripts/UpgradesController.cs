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

    // idle production upgrades
    public string[] productionUpgradeNames;

    public List<Upgrades> productionUpgrades;
    public Upgrades productionUpgradePrefab;

    public ScrollRect productionUpgradesScroll;
    public Transform productionUpgradesPanel;

    public BigDouble[] productionUpgradeBaseCost;
    public BigDouble[] productionUpgradesBasePower;
    public BigDouble[] productionUpgradeCostMult;

    // clicky shooty upgrades
    public string[] clickUpgradeNames;

    public List<Upgrades> clickUpgrades;
    public Upgrades clickUpgradePrefab;

    public ScrollRect clickUpgradesScroll;
    public Transform clickUpgradesPanel;

    public BigDouble[] clickUpgradeBaseCost;
    public BigDouble[] clickUpgradesBasePower;
    public BigDouble[] clickUpgradeCostMult;

   

    public void StartUpgradeController()
    {

        // pile of click upgrade init + control values
        Utils.UpgradeCheck(GameController.instance.gamedata.clickUpgradeLevels, 7);

        clickUpgradeNames = new[]
        {
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

        for (int i = 0; i < GameController.instance.gamedata.clickUpgradeLevels.Count; i++)
        {
            Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel);
            upgrade.UpgradeID = i;
            clickUpgrades.Add(upgrade);
        }

        // slap the upgrades into the scroll rect starting from bottom left, not center
        clickUpgradesScroll.normalizedPosition = new Vector2(0, 0);


        // bunch of idle production upgrade init + control values
        Utils.UpgradeCheck(GameController.instance.gamedata.productionUpgradeLevels, 5);

        productionUpgradeNames = new[]
        {
            "Production 1",
            "Production 2",
            "Production Longer Name 1",
            "Prod 1",
            "Production 3",
        };

        productionUpgradeBaseCost = new BigDouble[]
        {
            25,
            100,
            1000,
            10000,
            50000,
        };

        productionUpgradeCostMult = new BigDouble[]
        {
            1.5,
            1.75,
            2,
            3,
            5,
        };

        productionUpgradesBasePower = new BigDouble[]
        {
            1,
            2,
            10,
            100,
            500,
        };

        for (int i = 0; i < GameController.instance.gamedata.productionUpgradeLevels.Count; i++)
        {
            Upgrades upgrade = Instantiate(productionUpgradePrefab, productionUpgradesPanel);
            upgrade.UpgradeID = i;
            productionUpgrades.Add(upgrade);
        }

        // slap the upgrades into the scroll rect starting from bottom left, not center
        productionUpgradesScroll.normalizedPosition = new Vector2(0, 0);


        UpdateUpgradeUI("click");
        UpdateUpgradeUI("idle");
    }

    public void UpdateUpgradeUI(string type, int UpgradeID = -1)
    {
        var gamedata = GameController.instance.gamedata;

        switch (type)
        {
            case "click":
                if (UpgradeID == -1)
                    for (int i = 0; i < clickUpgrades.Count; i++)
                        UpdateUI(clickUpgrades, gamedata.clickUpgradeLevels, clickUpgradeNames, i);
                else
                    UpdateUI(clickUpgrades, gamedata.clickUpgradeLevels, clickUpgradeNames, UpgradeID);
                break;
            case "idle":
                if (UpgradeID == -1)
                    for (int i = 0; i < productionUpgrades.Count; i++)
                        UpdateUI(productionUpgrades, gamedata.productionUpgradeLevels, productionUpgradeNames, i);
                else
                    UpdateUI(productionUpgrades, gamedata.productionUpgradeLevels, productionUpgradeNames, UpgradeID);
                break;
        }



        void UpdateUI(List<Upgrades> upgrades, List<int> upgradeLevels, string[] upgradeNames, int ID)
        {
            upgrades[ID].LevelText.text = "Tier: " + upgradeLevels[ID].ToString();
            upgrades[ID].CostText.text = "-" + UpgradeCost(type, ID).ToString("F0") + " Credits";
            upgrades[ID].NameText.text = upgradeNames[ID];

            switch (type)
            {
                case "click":
                    upgrades[ID].BasePowerText.text = $"+{clickUpgradesBasePower[ID]} / Shot";
                    break;
                case "idle":
                    upgrades[ID].BasePowerText.text = $"+{productionUpgradesBasePower[ID]} / s";
                    break;
            }
        }
    }

    // Get cost for specified Upgrade ID
    public BigDouble UpgradeCost(string type, int UpgradeID)
    {
        var gamedata = GameController.instance.gamedata;

        switch (type)
        {
            case "click":
                return clickUpgradeBaseCost[UpgradeID] 
                       * BigDouble.Pow(
                            clickUpgradeCostMult[UpgradeID], 
                            (BigDouble)gamedata.clickUpgradeLevels[UpgradeID]
                       );

            case "idle":
                return productionUpgradeBaseCost[UpgradeID] 
                       * BigDouble.Pow(
                            productionUpgradeCostMult[UpgradeID],
                            (BigDouble)gamedata.productionUpgradeLevels[UpgradeID]
                        );
        }
        return -1;
    }

    public void BuyUpgrade(string type, int UpgradeID)
    {
        var gamedata = GameController.instance.gamedata;

        switch (type)
        {
            case "click":
                Buy(gamedata.clickUpgradeLevels);
                break;
            case "idle":
                Buy(gamedata.productionUpgradeLevels);
                break;
        }

        void Buy(List<int> upgradeButtonList)
        {
            if (gamedata.uacCredits >= UpgradeCost(type, UpgradeID))
            {
                gamedata.uacCredits -= UpgradeCost(type, UpgradeID);
                upgradeButtonList[UpgradeID] += 1;
            }
        }

        UpdateUpgradeUI(type, UpgradeID);
    }
}
