using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] GameObject roundObject;
    private float planeWidth;
    private float planeHeight;
    private void Start()
    {
        MeshCollider collider = GetComponent<MeshCollider>();
        if (collider == null)
        {
            Debug.LogError("Dont have Collider in this object");
        }
        else
        {
            Bounds bounds = collider.bounds;
            planeWidth = bounds.size.x;
            planeHeight = bounds.size.z;
        }
        GroundSpawner();


    }
    private void GroundSpawner()
    {
        float xPos = Random.Range(-planeWidth/2, planeWidth/2);
        float zPos = Random.Range(-planeHeight/2, planeHeight/2);
        Instantiate(roundObject, new Vector3(xPos,transform.position.y,zPos), Quaternion.identity);
    }


}
