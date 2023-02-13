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

    public string[] nameString;
    
    private void Start()
    {
        gamedata = new GameData();

        UpgradesController.instance.StartUpgradeController();
    }

    private void Update()
    {
        uacCreditsTotalText.text = gamedata.uacCredits + " UAC Credits";
        creditsPerClickText.text = "+" + ClickPower() + " UAC Credits / Shot";
        clickButtonText.text = "Shoot\n(+" + ClickPower() + " UAC Credits)";
    }

    public void ClickShoot()
    {
        gamedata.uacCredits += ClickPower();
    }

    public BigDouble ClickPower()
    {
        BigDouble total = 1;

        for (int i = 0; i < gamedata.clickUpgradeLevel.Count; i++)
            total += UpgradesController.instance.clickUpgradesBasePower[i] * gamedata.clickUpgradeLevel[i];
    
        return total;
    }
}
