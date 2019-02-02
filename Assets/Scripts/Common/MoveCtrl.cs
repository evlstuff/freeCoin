using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public Vector3 Direction = Vector3.left;
    public float Speed = 2f;

    void FixedUpdate()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }
}
