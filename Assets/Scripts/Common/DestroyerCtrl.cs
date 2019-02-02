using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerCtrl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        Destroy(collision.collider.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Destroy(other.gameObject);
    }
}
