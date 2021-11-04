using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnLevelComplete : UnityEvent
{
}
[System.Serializable]
public class OnCoinValueChange : UnityEvent<int, bool>
{
}
public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    OnLevelComplete onLevelComplete;
    [SerializeField]
    OnCoinValueChange onCoinValueChange;

    [SerializeField]
    List<Coin_Spinner> coinsList;

    [SerializeField]
    GameObject player;
    [SerializeField]
    PlayerStats playerStats;
    [SerializeField]
    GameObject leftPlayerHand;
    [SerializeField]
    GameObject rightPlayerHand;

    [SerializeField]
    GameObject leftCylinder;
    [SerializeField]
    GameObject rightCylinder;
    [SerializeField]
    GameObject leftCylinderSpawnPoint;
    [SerializeField]
    GameObject rightCylinderSpawnPoint;
    [SerializeField]
    GameObject leftCylinderFinishPoint;
    [SerializeField]
    GameObject rightCylinderFinishPoint;


    // Start is called before the first frame update
    void Start()
    {
        //LevelStart();
    }

    void LevelStart()
    {
        Instantiate(leftCylinder, leftCylinderSpawnPoint.transform.position, Quaternion.Euler(Vector3.zero));
        Instantiate(rightCylinder, rightCylinderSpawnPoint.transform.position, Quaternion.Euler(Vector3.zero));

        foreach (var coin in coinsList)
        {
            if(!coin.IsCollected())
            {
                coin.gameObject.SetActive(true);
            }
        }
    }

    public void CheckFinishPoints()
    {
        if(leftCylinder.GetComponent<ArmCylinder>().OnFinishPoint && rightCylinder.GetComponent<ArmCylinder>().OnFinishPoint)
        {
            LevelComplete();
        }
    }

    void LevelComplete()
    {
        onLevelComplete.Invoke();
    }

    public void AddCoin(int value)
    {
        playerStats.coins += value;
        onCoinValueChange.Invoke(playerStats.coins, false);
    }
}
