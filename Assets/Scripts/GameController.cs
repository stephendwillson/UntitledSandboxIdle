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
        uacCreditsTotalText.text = "UAC Credits:\n" + gamedata.uacCredits;
        clickButtonText.text = "Shoot\n(+" + ClickPower() + " UAC Credits)";
        creditsPerSecondText.text = "Credits / s:\n" + CreditsPerSecond();
        creditsPerClickText.text = "UAC Credits / Shot:\n+" + ClickPower();
    }

    public void ClickShoot()
    {
        gamedata.uacCredits += ClickPower();
    }

    public BigDouble ClickPower()
    {
        BigDouble total = 1000;

        for (int i = 0; i < gamedata.clickUpgradeLevel.Count; i++)
            total += UpgradesController.instance.clickUpgradesBasePower[i] * gamedata.clickUpgradeLevel[i];
    
        return total;
    }

    public BigDouble CreditsPerSecond()
    {
        return 8675309;
    }
}
