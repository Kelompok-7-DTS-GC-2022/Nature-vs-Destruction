using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour
{
    public GameObject currentHit;
    public Vector3 targetPosition;
    public Collider targetCollider;
    public Collider myCollider;
    public float snapDistance = 1;
    void Update()
    {
        RaycastHit hitLeft;
        RaycastHit hitRight;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitLeft, 20))
        {
            if (hitLeft.transform.CompareTag("LeftSnap"))
            {
                transform.position = hitLeft.transform.position;
                

            }
            
        }
        else
        {
            if (currentHit != null)
            {
                currentHit = null;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitRight, 20))
        {
            if (hitRight.transform.CompareTag("RightSnap"))
            {
                transform.position = hitRight.transform.position;
                

            }

        }
        else
        {
            if (currentHit != null)
            {
                currentHit = null;
            }
        }

    }
}
