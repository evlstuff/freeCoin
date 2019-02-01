using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public float Speed = 2f;

    public Transform Player;

    void Awake()
    {
        GameObject P = GameObject.Find("Player");

        if (P != null) {
            Player = GameObject.Find("Player").transform;
        }
    }

    private void Start()
    {
        //transform.LookAt(Player);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground") {
            transform.SetParent(collision.collider.transform);
        }
    }


    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //transform.position += transform.forward * Speed * Time.deltaTime;
    }
}
