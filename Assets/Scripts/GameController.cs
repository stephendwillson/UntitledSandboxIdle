using UnityEngine;
using TMPro;
using BreakInfinity;

public class GameController : MonoBehaviour 
{    
    public static GameController instance;
    private void Awake() => instance = this;

    public GameData gamedata;

    [SerializeField] private TMP_Text uacCreditsTotalText;
    [SerializeField] private TMP_Text creditsPerShotText;
    [SerializeField] private TMP_Text shootButtonText;
    
    private void Start()
    {
        gamedata = new GameData();

        UpgradeController.instance.StartUpgradeController();
    }

    private void Update()
    {
        uacCreditsTotalText.text = gamedata.uacCredits + " UAC Credits";
        creditsPerShotText.text = "+" + UACCreditsPerClick() + " UAC Credits / Shot";
        shootButtonText.text = "Shoot\n(+" + UACCreditsPerClick() + " UAC Credits)";
    }

    public void ClickShoot()
    {
        gamedata.uacCredits += UACCreditsPerClick();
    }

    public BigDouble UACCreditsPerClick()
    {
        return 1 + gamedata.shotUpgradeLevel;
    }
}
