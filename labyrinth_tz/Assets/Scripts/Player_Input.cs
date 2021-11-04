using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[System.Serializable]
public class OnHeadTurn : UnityEvent<bool>
{
}
[System.Serializable]
public class OnRelease : UnityEvent
{
}
public class Player_Input : MonoBehaviour
{
    [SerializeField]
    Transform leftCylinder;
    [SerializeField]
    Transform rightCylinder;
    [SerializeField]
    OnRelease onRelease;
    [SerializeField]
    OnHeadTurn onHeadTurn;
    GameObject grabbedObject;
    float currentDistance;
    float speed;
    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(grabbedObject == null)
            {
                RaycastHit[] hit = CastRay();

                if(hit.Length > 0)
                {
                    foreach (var col in hit)
                    {
                        if(col.collider != null)
                        {
                            if(col.collider.CompareTag("grab"))
                            {
                                grabbedObject = col.collider.gameObject;
                                bool tempB = grabbedObject.GetComponent<ArmCylinder>().IsLeft ? true : false;
                                onHeadTurn.Invoke(tempB);
                            }
                        }
                    }
                }
                
            }
        }

        if(Input.GetMouseButtonUp(0) && grabbedObject != null)
        {
            grabbedObject.transform.DOKill(false);
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject = null;
            onRelease.Invoke();
        }

        if(grabbedObject != null)
        {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(grabbedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pos);
            grabbedObject.GetComponent<Rigidbody>().useGravity = false;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            currentDistance = Vector3.Distance(leftCylinder.position, rightCylinder.position);
            speed = .1f + 2f * currentDistance;
            grabbedObject.transform.DOMove(new Vector3(worldPosition.x, worldPosition.y, grabbedObject.transform.position.z), speed);
        }
    }

    private RaycastHit[] CastRay()
    {
        Vector3 screenMousePosFar = new Vector3
        (            
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
        );
        Vector3 screenMousePosNear = new Vector3
        (            
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane
        );
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit[] hit = Physics.RaycastAll(worldMousePosNear, worldMousePosFar - worldMousePosNear);
        

        return hit;
    }
}
