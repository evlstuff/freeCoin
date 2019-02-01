using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : MonoBehaviour
{
    [Header("General")]
    public Transform SpawnPoint;
    public GameObject SpawnObject; 

    [Header("Timer")]
    public float SpawnDelay = 2f;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        if (SpawnObject == null) {
            return;
        }

        GameObject enemy = Instantiate(SpawnObject, SpawnPoint);
        enemy.transform.rotation = Quaternion.identity;

        StartCoroutine("SpawnTimer");
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(SpawnDelay);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
