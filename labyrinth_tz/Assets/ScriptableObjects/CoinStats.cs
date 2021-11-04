using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CoinStats", menuName = "labyrinth_tz/CoinStats", order = 0)]
public class CoinStats : ScriptableObject {
    [SerializeField]
    private int coinValue;
    public int CoinValue => coinValue;
}
