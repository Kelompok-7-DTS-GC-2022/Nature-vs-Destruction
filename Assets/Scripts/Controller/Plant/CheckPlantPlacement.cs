using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class CheckPlantPlacement : MonoBehaviour
{
    public bool planted = false;
    public bool canPlant;
    public bool hasNeighbour;
    public LayerMask layer;
    private Bounds boxSize;
    private Vector3 boxPos;

    void checkIfTheresAnyPlantOnPlanting()
    {
        if (Physics.CheckBox(boxPos, boxSize.size * .5f, transform.rotation, layer))
        {
            canPlant = false;
        }
        else
        {
            canPlant = true;
        }
    }
    void checkIfTheresAnyPlantOnTerrain()
    {
        var plantOverlap = Physics.OverlapBox(boxPos, boxSize.size, transform.rotation, layer);
        var neighbour = plantOverlap.Where(plant => plant.transform != transform);
        print(neighbour.Count());
        if (neighbour.Count() > 0)
        {
            hasNeighbour = true;
        }
        else
        {
            hasNeighbour = false;
        }
    }

    private void FixedUpdate()
    {
        boxSize = GetComponent<Collider>().bounds;
        boxPos = boxSize.center;
        if (planted)
        {
            checkIfTheresAnyPlantOnTerrain();
        }
        else
        {
            checkIfTheresAnyPlantOnPlanting();
        }
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        var boxSize = GetComponent<Collider>().bounds;
        var boxPos = boxSize.center;
        Gizmos.DrawCube(boxPos, boxSize.size);
    }

    #region Unused

    // public GameObject plantTanah;
    // private float maxX;
    // private float maxZ;
    // private float minX;
    // private float minZ;
    // private Vector3 posXZMax;
    // private Vector3 posXZmin;
    // private Vector3 posZXMin;
    // private Vector3 posZXmax;
    // private Vector3 posXMax;
    // private Vector3 posZMax;
    // private Vector3 posXMin;
    // private Vector3 posZMin;
    // private void OnDrawGizmos()
    // {
    //     setPointer();
    //     Gizmos.color = Color.yellow;
    //     //     var pointerPosition = new Vector3[] { posXZMax, posXZmin, posZXmax, posZXMin, posXMax, posXMin, posZMax, posZMin };
    //     //     foreach (var positionpoint in pointerPosition)
    //     //     {
    //     //         Gizmos.DrawCube(positionpoint, Vector3.one);
    //     //     }
    //     var boxSize = GetComponent<Collider>().bounds;
    //     var boxPos = boxSize.center;
    //     Gizmos.DrawCube(boxPos, boxSize.size);
    // }

    // // public void turnOnPlantSnapPointer()
    // // {
    // //     setPointer();
    // //     var pointerPosition = new Vector3[] { posXZMax, posXZmin, posZXmax, posZXMin, posXMax, posXMin, posZMax, posZMin };
    // //     foreach (var positionpoint in pointerPosition)
    // //     {
    // //         var pointer = Instantiate(plantSnapPointerPrefab, positionpoint, Quaternion.identity);
    // //         pointer.transform.parent = this.transform;
    // //         pointer.checkPlantPlacement = this;
    // //         snapPointers.Add(pointer);
    // //     }
    // // }
    // private void setPointer()
    // {
    //     var terrainBound = plantTanah.GetComponent<Renderer>().bounds;
    //     var terrainXLengthRadius = terrainBound.size.x / 2;
    //     var terrainZLengthRadius = terrainBound.size.z / 2;

    //     maxX = transform.position.x + terrainXLengthRadius;
    //     maxZ = transform.position.z + terrainZLengthRadius;
    //     minX = transform.position.x - terrainXLengthRadius;
    //     minZ = transform.position.z - terrainZLengthRadius;
    //     var nol = 0.55f;
    //     posXZMax = new Vector3(maxX, transform.position.y + nol, maxZ);
    //     posXZmin = new Vector3(maxX, transform.position.y + nol, minZ);
    //     posZXMin = new Vector3(minX, transform.position.y + nol, minZ);
    //     posZXmax = new Vector3(minX, transform.position.y + nol, maxZ);
    //     posXMax = new Vector3(maxX, transform.position.y + nol, transform.position.z);
    //     posZMax = new Vector3(transform.position.x, transform.position.y + nol, maxZ);
    //     posXMin = new Vector3(minX, transform.position.y + nol, transform.position.z);
    //     posZMin = new Vector3(transform.position.x, transform.position.y + nol, minZ);

    // }
    // private bool nieghbourCheck() =>
    //         dragonArea(Vector3.forward)
    //         || dragonArea(Vector3.back)
    //         || dragonArea(Vector3.left)
    //         || dragonArea(Vector3.right)
    //         || dragonArea((Vector3.forward + Vector3.right).normalized)//45degree to right
    //         || dragonArea((Vector3.forward - Vector3.right).normalized)//45degree to left
    //         || dragonArea((Vector3.back + Vector3.right).normalized)//so on
    //         || dragonArea((Vector3.back - Vector3.right).normalized);

    // private bool dragonArea(Vector3 direction)
    // {
    //     var isSafe = false;
    //     var rayPosition = new Vector3(plantTanah.transform.position.x, plantTanah.transform.position.y + .5f, plantTanah.transform.position.z);
    //     RaycastHit hit;
    //     // , LayerMask.NameToLayer("Plant")
    //     if (Physics.Raycast(rayPosition, direction, out hit, 3, layer))
    //     {
    //         if (hit.collider == null) return true;
    //         if (hit.collider.CompareTag("PlantPointer") && hit.collider.transform.parent != transform)
    //         {
    //             Debug.DrawRay(rayPosition, direction * hit.distance, Color.red);
    //             print(hit.collider.name);
    //             isSafe = true;
    //             var pointerSize = hit.collider.bounds.size;
    //             transform.position = transform.position - pointerSize;
    //         }
    //         else
    //         {
    //             isSafe = false;
    //         }
    //     }

    //     return isSafe;
    // }
    #endregion

}
