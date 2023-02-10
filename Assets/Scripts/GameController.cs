using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour 
{    
    // public float timer = 0f;
    // public float tickrate = 1.0f;

    // // Currencies + gain rates
    // public double sandTotal;
    // public double sandPerSec;
    // public double clickVal;
    // public TMP_Text sandTotalText;
    // public TMP_Text sandPerSecText;
    // public TMP_Text clickValText;
    
    // // Click upgrades
    // public int clickUpTier;
    // public double clickUpVal;
    // public double clickUpCost;
    // public double clickUpCostMult;
    // public TMP_Text clickUpText;

    // public int clickUp2Tier;
    // public double clickUp2Val;
    // public double clickUp2CostMult;
    // public double clickUp2Cost;
    // public TMP_Text clickUp2Text;

    // // Idle production upgrades
    // public int prodUpTier;
    // public double prodUpVal;
    // public double prodUpCostMult;
    // public double prodUpCost;
    // public TMP_Text prodUpText;

    // public int prodUp2Tier;
    // public double prodUp2Val;
    // public double prodUp2CostMult;
    // public double prodUp2Cost;
    // public TMP_Text prodUp2Text;



    public GameData gamedata;
    public UpgradeController upgradeController;

    [SerializeField] private TMP_Text sandTotalText;
    [SerializeField] private TMP_Text sandClickValText;
    
    public double ClickVal() => 1 + gamedata.clickUpLevel;

    private void Start()
    {
        // clickVal = 100;
        // sandPerSec = 0;
        // sandTotal = 0;
    
        // // Click upgrades init
        // clickUpCost = 10;
        // clickUpTier = 1;
        // clickUpVal = 1;
        // clickUpCostMult = 1.07;

        // clickUp2Cost = 100;
        // clickUp2Tier = 1;
        // clickUp2Val = 5;
        // clickUp2CostMult = 1.09;

        // // Idle production upgrades init
        // prodUpCost = 25;
        // prodUpTier = 1;
        // prodUpVal = 1;
        // prodUpCostMult = 1.07;

        // prodUp2Cost = 250;
        // prodUp2Tier = 1;
        // prodUp2Val = 5;
        // prodUp2CostMult = 1.09;






        gamedata = new GameData();

        upgradeController.StartUpgradeController();
    }

    private void Update()
    {
        sandTotalText.text = gamedata.sand + " Sand";
        sandClickValText.text = "+" + ClickVal() + " Sand";
        // timer += Time.deltaTime;
        // if (timer >= tickrate)
        // {
        //     timer = 0f;
        //     sandTotal += sandPerSec;
        // }

        // // Text for currencies + gain rate buttons
        // sandTotalText.text = "Sand: " + sandTotal.ToString("F0");
        // sandPerSecText.text = "Sand / s: " + sandPerSec.ToString("F0");
        // clickValText.text = "Sand / click: " + clickVal;

        // // Text for click upgrade buttons
        // clickUpText.text = "Click Upgrade\n+" + clickUpVal + " Sand / click\n\nCost: " + clickUpCost.ToString("F0") + "\nTier: " + clickUpTier;
        // clickUp2Text.text = "Click Upgrade II\n+" + clickUp2Val + " Sand / click\n\nCost: " + clickUp2Cost.ToString("F0") + "\nTier: " + clickUp2Tier;

        // // Text for idle production upgrade buttons
        // prodUpText.text = "Idle Production Upgrade\n+" + prodUpVal + " Sand / s\n\nCost: " + prodUpCost.ToString("F0") + "\nTier: " + prodUpTier;
        // prodUp2Text.text = "Idle Production Upgrade II\n+" + prodUp2Val + " Sand / s\n\nCost: " + prodUp2Cost.ToString("F0") + "\nTier: " + prodUp2Tier;
    }

    public void ClickSift()
    {
        // sandTotal += clickVal;
        gamedata.sand += ClickVal();
    }

    // public void ClickClickUpgrade()
    // {
    //     if (sandTotal >= clickUpCost)
    //     {
    //         sandTotal -= clickUpCost;
    //         clickUpTier++;
    //         clickUpCost *= clickUpCostMult;
    //         clickVal += clickUpVal;
    //     }
    // }

    // public void ClickClickUpgrade2()
    // {
    //     if (sandTotal >= clickUp2Cost)
    //     {
    //         sandTotal -= clickUp2Cost;
    //         clickUp2Tier++;
    //         clickUp2Cost *= clickUp2CostMult;
    //         clickVal += clickUp2Val;
    //     }
    // }

    // public void ClickProdUpgrade()
    // {
    //     if (sandTotal >= prodUpCost)
    //     {
    //         sandTotal -= prodUpCost;
    //         prodUpTier++;
    //         prodUpCost *= prodUpCostMult;
    //         sandPerSec += prodUpVal;
    //     }
    // }

    // public void ClickProdUpgrade2()
    // {
    //     if (sandTotal >= prodUp2Cost)
    //     {
    //         sandTotal -= prodUp2Cost;
    //         prodUp2Tier++;
    //         prodUp2Cost *= prodUp2CostMult;
    //         sandPerSec += prodUp2Val;
    //     }
    // }
}
