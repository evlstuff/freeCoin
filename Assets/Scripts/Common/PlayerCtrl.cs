using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Header("Jump")]
    public float JumpForce = 2f;

    private Rigidbody RB;

    void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        if (RB == null) {
            return;
        }

        RB.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
}
