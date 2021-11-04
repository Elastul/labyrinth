using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnFail : UnityEvent
{

}
public class Player_Fail_Trigger : MonoBehaviour
{
    [SerializeField]
    OnFail onFail;    
    bool gotTriggered = false;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player") && !gotTriggered)
        {
            gotTriggered = true;
            onFail.Invoke();
        }    
    }
}
