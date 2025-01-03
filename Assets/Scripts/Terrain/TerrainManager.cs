using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    [SerializeField] private Terrain _terrain;
    [SerializeField] private GameObject rock;
    [SerializeField] private float rockAmount;
    [SerializeField] private GameObject rockManager;
    protected float terrainWidth;
    protected float terrainHeight;
    protected float terrainLength;

    protected virtual void Start()
    {
        if(_terrain != null)
        {
            terrainHeight = _terrain.terrainData.size.y;
            terrainWidth = _terrain.terrainData.size.x;
            terrainLength = _terrain.terrainData.size.z;
        }
        GenerateRockObject();
    }

    protected virtual void GenerateRockObject() {
        while (rockAmount > 0)
        {
            float xPos = Random.Range(0, terrainWidth);
            float zPos = Random.Range(0, terrainLength);
            Vector3 terrainPosition = _terrain.transform.position;

            //lay bề mặt terrain
            float yPos = _terrain.SampleHeight(new Vector3(xPos + terrainPosition.x, 0, zPos + terrainPosition.z));

            GameObject newRock = Instantiate(rock, new Vector3(xPos + terrainPosition.x, yPos, zPos + terrainPosition.z), Quaternion.identity);
            newRock.SetActive(true);
            newRock.transform.parent = rockManager.transform;
            rockAmount -= 1;

        }
    }
}
