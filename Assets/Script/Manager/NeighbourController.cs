using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Team7.Nature.Plant.Controller;
public class NeighbourController : MonoBehaviour
{
    public GameObject currentHit;
    [SerializeField] int distance;
    [SerializeField] PlantController plantController;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        RaycastHit hitLeft;
        RaycastHit hitRight;
        RaycastHit hitForward;
        RaycastHit hitBackward;
        RaycastHit snappingLeft;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitLeft, 50))
        {
            var selectionObjectLeft = hitLeft.transform;
            if (selectionObjectLeft != null)
            {
                currentHit = hitLeft.transform.gameObject;
            }
            else
            {
                
                plantController.isDamaged = true;
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitLeft.distance, Color.blue);
        }
        else
        {
            if(currentHit != null)
            {
                currentHit = null;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitRight, 100))
        {
            var selectionObjectRight = hitRight.transform;
            if (selectionObjectRight != null)
            {
                currentHit = hitRight.transform.gameObject;
            }
            else
            {
                
                plantController.isDamaged = true;
            }
        }
        else
        {
            if (currentHit != null)
            {
                currentHit = null;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitForward, 100))
        {
            var selectionObjectForward = hitForward.transform;
            if (selectionObjectForward != null)
            {
                currentHit = hitForward.transform.gameObject;
            }
            else
            {

                plantController.isDamaged = true;
            }
        }
        else
        {
            if (currentHit != null)
            {
                currentHit = null;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitBackward, 100)) 
        {
            var selectionObjectBackward = hitBackward.transform;
            if (selectionObjectBackward != null)
            {
                currentHit = hitBackward.transform.gameObject;
            }
            else
            {
                
                plantController.isDamaged = true;
            }
        }
        else
        {
            if (currentHit != null)
            {
                currentHit = null;
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out snappingLeft, 10))
        {
            if(snappingLeft.transform.tag == "LeftSnap")
            {
                transform.position = snappingLeft.transform.position;
            }
        }



    }
}
