using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "labyrinth_tz/PlayerStats", order = 0)]
public class PlayerStats : ScriptableObject 
{
    [SerializeField]
    public int coins;
    [SerializeField]
    public int nextUpgradeCost;
    [SerializeField]
    public int someStatToUpgrade;
}
