using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

public class Navigation : MonoBehaviour
{
    public GameObject ClickUpgradesSelected;
    public GameObject ProductionUpgradesSelected;

    public TMP_Text ClickUpgradesTitleText;
    public TMP_Text ProductionUpgradesTitleText;
    
    public Color doom_red;
    public Color doom_red_unselected;

    public void SwitchUpgrades(string location)
    {
        UpgradesController.instance.clickUpgradesPanel.gameObject.SetActive(false);
        UpgradesController.instance.productionUpgradesPanel.gameObject.SetActive(false);

        ClickUpgradesSelected.SetActive(false);
        ProductionUpgradesSelected.SetActive(false);

        ClickUpgradesTitleText.color = doom_red;
        ProductionUpgradesTitleText.color = doom_red_unselected;

        switch (location)
        {
            case "Click":
                ClickUpgradesTitleText.color = doom_red;
                ProductionUpgradesTitleText.color = doom_red_unselected;
                UpgradesController.instance.clickUpgradesPanel.gameObject.SetActive(true);
                ClickUpgradesSelected.SetActive(true);
                break;
            case "Production":
                ProductionUpgradesTitleText.color = doom_red;
                ClickUpgradesTitleText.color = doom_red_unselected;
                UpgradesController.instance.productionUpgradesPanel.gameObject.SetActive(true);
                ProductionUpgradesSelected.SetActive(true);
                break;
        }
    }
}