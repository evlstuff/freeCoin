using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawn : MonoBehaviour
{
    private Random random;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnGift());
    }

    IEnumerator SpawnGift()
    {
        var timeout = Random.Range(0.6f, 1.8f);
        yield return new WaitForSeconds(timeout);

        CreateGift();
    }

    void CreateGift()
    {
        var color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Renderer>().material.color = color;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
