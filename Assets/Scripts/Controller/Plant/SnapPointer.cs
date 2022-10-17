using UnityEngine;

public class SnapPointer : MonoBehaviour
{
    public CheckPlantPlacement checkPlantPlacement;


    void snapThePlant(Collider collider)
    {
        if (collider.transform != null)
        {
            print("Masuk " + collider.name);
            var pointerSize = this.GetComponent<Collider>().bounds.size;
            collider.transform.position = collider.transform.position - pointerSize;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plant"))
        {
            snapThePlant(other);
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Plant"))
    //     {
    //         canPlant = true;
    //     }
    // }
}