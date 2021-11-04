using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin_Spinner : MonoBehaviour
{
    [SerializeField]
    CoinStats coinStats;
    [SerializeField]
    bool gotCollected = false;

    private void Start() 
    {
        transform.DORotate(new Vector3(-90f, 180f, 0), 1f).SetLoops(-1, LoopType.Incremental);    
    }

    public int GetCoinValue()
    {
        return coinStats.CoinValue;
    }

    public void CollectCoin()
    {
        gotCollected = true;
    }

    public bool IsCollected()
    {
        return gotCollected;
    }
}
