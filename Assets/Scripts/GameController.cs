using UnityEngine;
using TMPro;

using BreakInfinity;

public class GameController : MonoBehaviour 
{    
    public static GameController instance;
    private void Awake() => instance = this;

    public GameData gamedata;

    [SerializeField] private TMP_Text uacCreditsTotalText;
    [SerializeField] private TMP_Text creditsPerClickText;
    [SerializeField] private TMP_Text clickButtonText;
    [SerializeField] private TMP_Text creditsPerSecondText;

    public string[] nameString;
    
    private void Start()
    {
        gamedata = new GameData();

        UpgradesController.instance.StartUpgradeController();
    }

    private void Update()
    {
        uacCreditsTotalText.text = "UAC Credits:\n" + gamedata.uacCredits.ToString("F0");
        clickButtonText.text = "Shoot\n(+" + ClickPower() + " UAC Credits)";
        creditsPerSecondText.text = "Credits / s:\n" + CreditsPerSecond().ToString("F2");
        creditsPerClickText.text = "UAC Credits / Shot:\n+" + ClickPower();

        gamedata.uacCredits += CreditsPerSecond() * Time.deltaTime;
    }

    public void ClickShoot()
    {
        gamedata.uacCredits += ClickPower();
    }

    public BigDouble ClickPower()
    {
        BigDouble total = 1;

        for (int i = 0; i < gamedata.clickUpgradeLevels.Count; i++)
            total += UpgradesController.instance.clickUpgradesBasePower[i] * gamedata.clickUpgradeLevels[i];
    
        return total;
    }

    public BigDouble CreditsPerSecond()
    {
        BigDouble total = 0;

        for (int i = 0; i < gamedata.productionUpgradeLevels.Count; i++)
            total += UpgradesController.instance.productionUpgradesBasePower[i] * gamedata.productionUpgradeLevels[i];
    
        return total;
    }
}
