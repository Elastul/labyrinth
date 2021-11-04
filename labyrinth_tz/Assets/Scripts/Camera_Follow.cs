using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField]
    Transform leftCylinder;
    [SerializeField]
    Transform rightCylinder;

    [SerializeField]
    float speed = .15f;
    [SerializeField]
    Vector3 offset;

    private void LateUpdate() 
    {
        Vector3 targetPosition = (leftCylinder.position + (.5f * (leftCylinder.position - rightCylinder.position))) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, speed);
        transform.position = smoothedPosition;    
    }
}
