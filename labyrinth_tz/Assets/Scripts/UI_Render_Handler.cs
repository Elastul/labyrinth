using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Render_Handler : MonoBehaviour
{
    [SerializeField]
    PlayerStats playerStats;
    [SerializeField]
    Text upgradeText;
    [SerializeField]
    Button upgradeButton = null;
    [SerializeField]
    TextMeshProUGUI coinsText;
    [SerializeField]
    TextMeshProUGUI levelText;

    [SerializeField]
    GameObject completePanel;
    [SerializeField]
    GameObject failPanel;
    int levelCounter = 1;

    private void Start() 
    {
        ChangeCoinsText(playerStats.coins, false);
    }

    public void ChangeCoinsText(int count, bool buttonSwitch)
    {
        coinsText.text = "Coins: " + count;
        if(buttonSwitch)
        {
            SwitchUpgradeButton();
        }
    }

    void SwitchUpgradeButton()
    {
        upgradeButton.GetComponent<Button>().interactable = upgradeButton.GetComponent<Button>().interactable == true ? false : true;
        ChangeUpgradeButtonText(playerStats.nextUpgradeCost);
    }

    public void ChangeLevelText(int level)
    {
        levelText.text = "Level: " + level;
    }

    public void ChangeUpgradeButtonText(int cost)
    {
        upgradeText.text = "Upgrade for " + cost;
    }

    public void SwitchCompletePanelState()
    {
        completePanel.SetActive(true);
        levelCounter++;
        levelText.text = "Level: " + levelCounter;
    }

    public void SwitchFailPanelState()
    {
        failPanel.SetActive(true);
    }
}
