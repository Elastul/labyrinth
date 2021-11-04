using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class OnUpgrade : UnityEvent<int>
{
}
[System.Serializable]
public class OnCoinsValueChange : UnityEvent<int, bool>
{
}
public class Upgrade_Controller : MonoBehaviour
{
    [SerializeField]
    OnUpgrade onUpgrade;
    [SerializeField]
    OnCoinsValueChange onCoinsValueChange;


    [SerializeField]
    TextMeshProUGUI coinsText;
    [SerializeField]
    GameObject upgradeButton;
    [SerializeField]
    PlayerStats playerStats;
    [SerializeField]
    int upgradeValue = 10;
    [SerializeField]
    int upgradeCostIncrement = 1;


    private void Start() 
    {
        onUpgrade.Invoke(playerStats.nextUpgradeCost);

        isEnoughCoins();
    }

    private void isEnoughCoins()
    {
        if(playerStats.coins < playerStats.nextUpgradeCost)
        {
            onCoinsValueChange.Invoke(playerStats.coins, true);
        }
        else
        {           
            onCoinsValueChange.Invoke(playerStats.coins, false);
        }
    }

    public void Upgrade()
    {
        playerStats.coins -= playerStats.nextUpgradeCost;
        playerStats.someStatToUpgrade += upgradeValue;
        playerStats.nextUpgradeCost += upgradeCostIncrement;

        onUpgrade.Invoke(playerStats.nextUpgradeCost);

        isEnoughCoins();
    }
}
