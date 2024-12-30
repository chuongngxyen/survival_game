using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGenerator : MonoBehaviour
{
    [SerializeField] private GameObject mobObject;
    [SerializeField] private float xRandomPos;
    [SerializeField] private float zRandomPos;
    private GameObject mobSpawnFolder;
    public float mobsCount;

    private void Awake()
    {
        mobSpawnFolder = new GameObject();
        mobSpawnFolder.name = "mobSpawnFolder";
    }

    private void Start()
    {
        StartCoroutine(HandleMobSpawning());
    }

    IEnumerator HandleMobSpawning()
    {
        while (mobsCount > 0)
        {
            float xPos = Random.Range(xRandomPos * -1, xRandomPos);
            float zPos = Random.Range(xRandomPos * -1, zRandomPos);
            GameObject newMob = Instantiate(mobObject, new Vector3(xPos,0,zPos), Quaternion.identity);
            newMob.SetActive(true);
            newMob.transform.parent = mobSpawnFolder.transform;
            yield return new WaitForSeconds(1f);

        }
    }
}
