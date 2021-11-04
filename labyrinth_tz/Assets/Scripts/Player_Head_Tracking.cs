using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Head_Tracking : MonoBehaviour
{
    [SerializeField]
    Transform leftCylinderT;
    [SerializeField]
    Transform rightCylinderT;
    Transform trackingTarget;
    bool isTracking = false;
    
    void Update()
    {
        if(isTracking)
        {
            transform.LookAt(trackingTarget);
        }
    }

    public void SetTrackTarget(bool isLeft)
    {
        Debug.Log("Looking! and " + isLeft);
        trackingTarget = isLeft ? leftCylinderT : rightCylinderT;
        isTracking = true;
    }

    public void StopTracking()
    {
        Debug.Log("NotLooking!");
        isTracking = false;
    }
}
