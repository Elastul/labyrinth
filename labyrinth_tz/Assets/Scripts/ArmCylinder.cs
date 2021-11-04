using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnFinishPointTrigger : UnityEvent
{
}
[System.Serializable]
public class OnCoinPickUp : UnityEvent<int>
{
}
public class ArmCylinder : MonoBehaviour
{
    [SerializeField]
    OnFinishPointTrigger onFinishPointTrigger;
    [SerializeField]
    OnCoinPickUp onCoinPickUp;
    [SerializeField]
    bool isLeft;
    public bool IsLeft => isLeft;
    bool onFinishPoint = false;
    public bool OnFinishPoint => onFinishPoint;

    private void Start() 
    {
        onFinishPoint = false;    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if((isLeft && other.gameObject.CompareTag("finishLeft")) || (!isLeft && other.gameObject.CompareTag("finishRight")))
        {
            onFinishPoint = true;
            onFinishPointTrigger.Invoke();
        }

        if(other.gameObject.CompareTag("coin"))
        {
            var coin = other.gameObject.GetComponent<Coin_Spinner>();
            onCoinPickUp.Invoke(coin.GetCoinValue());
            coin.CollectCoin();
            coin.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(isLeft && other.gameObject.CompareTag("finishLeft"))
        {
            onFinishPoint = false;
        }
        else if(!isLeft && other.gameObject.CompareTag("finishRight"))
        {
            onFinishPoint = false;
        }
    }
}
