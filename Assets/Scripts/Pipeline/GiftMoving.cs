using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            transform.SetParent(collision.collider.transform.parent);
        }
    }
}
