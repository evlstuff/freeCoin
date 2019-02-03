using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveTypes
{
    Direction, JumpToPosition, Custom
}

public class MoveCtrl : MonoBehaviour
{
    [Header("General")]
    public MoveTypes MoveType = MoveTypes.Direction;
    public float Speed = 2f;
    public float JumpForce = 2f;

    [Header("Direction Props")]
    public Vector3 Direction = Vector3.left;

    [Header("Jump To Position Props")]
    public Transform JumpTargetTransform;
    public Vector3 JumpDirection;

    void UodateDirectionalMovement()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }

    void UpdateJumpToPositionMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //JumpDirection = Vector3.MoveTowards()
        }
    }

    void FixedUpdate()
    {
        switch(MoveType)
        {
            case MoveTypes.Direction:
                {
                    UodateDirectionalMovement();
                    break;
                }
            case MoveTypes.JumpToPosition:
                {
                    UpdateJumpToPositionMovement();
                    break;
                }
        }
    }
}
