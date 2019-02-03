using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawn : MonoBehaviour
{
    public Rigidbody Gift;

    private bool _isSpawnActivated = true;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GiftSpawner());
    }

    IEnumerator GiftSpawner()
    {
        while (_isSpawnActivated)
        {
            var timeout = Random.Range(0.6f, 1.8f);
            yield return new WaitForSeconds(timeout);
            CreateGift();
        }
    }

    void CreateGift()
    {
        var color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        
        var giftClone = Instantiate<Rigidbody>(Gift, transform.position, transform.rotation);
        giftClone.GetComponent<Renderer>().material.color = color;
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        _isSpawnActivated = false;
    }
}
