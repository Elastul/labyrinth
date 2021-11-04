using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Disjoint : MonoBehaviour
{
    [SerializeField]
    Transform leftCylinder;
    [SerializeField]
    Transform rightCylinder;
    [SerializeField]
    GameObject leftHand;
    [SerializeField]
    GameObject rightHand;

    [SerializeField]
    float maxDistance = 1.6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(leftCylinder.position, rightCylinder.position);
        if(currentDistance >= maxDistance)
        {
            Destroy(leftHand.GetComponent<HingeJoint>());
            Destroy(rightHand.GetComponent<HingeJoint>());
        }
    }
}
