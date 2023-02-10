using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public GameController controller;

    public Upgrade clickUp;

    public string clickUpName;

    public double clickUpBaseCost;
    public double clickUpCostMult;

    public void StartUpgradeController()
    {

        clickUpName = "Click Upgrade";
        clickUpBaseCost = 10;
        clickUpCostMult = 1.5;

        UpdateClickUpgradeUI();
    }

    public void UpdateClickUpgradeUI()
    {
        clickUp.LevelText.text = "Level: " + controller.gamedata.clickUpLevel.ToString();
        clickUp.CostText.text = "Cost: " + Cost() + " Sand";
        clickUp.NameText.text = clickUpName;
    }

    public double Cost() => clickUpBaseCost * Math.Pow(clickUpCostMult, controller.gamedata.clickUpLevel);

    public void BuyUpgrade()
    {
        if (controller.gamedata.sand >= Cost())
        {
            controller.gamedata.sand -= Cost();
            controller.gamedata.clickUpLevel += 1;
        }

        UpdateClickUpgradeUI();
    }
}
