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
    private Rigidbody RB; 

    [Header("Direction Props")]
    public Vector3 Direction = Vector3.left;

    [Header("Jump To Position Props")]
    public Vector3 direction;
    public float JumpDistance = 0;
    public Vector3 JumpTargetPosition;
    public Vector3 JumpDirection;
    private Vector3 StartJumpPosition;
    public bool OnGround = false;
    public bool OnJump = false;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    void UodateDirectionalMovement()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        OnGround = false;
    }

    void UpdateJumpToPositionMovement()
    {
        if (OnGround && Input.GetKeyDown(KeyCode.Space)) {
            //OnJump = true;
            //StartJumpPosition = transform.position;
            //JumpTargetPosition = transform.position + (transform.right * JumpDistance);

            float angle = Vector3.Angle(transform.right, transform.up);
            Vector3 direction = Vector3.Lerp(transform.up, transform.right, .4f);

            RB.AddForce(direction * JumpForce * Speed, ForceMode.Impulse);
        }



        

        if (!OnJump || StartJumpPosition == null || JumpTargetPosition == null)
        {
            return;
        }
        /*
        Vector3 pos = transform.position;
        float dist = StartJumpPosition.x - JumpTargetPosition.x;

        float nextX = Mathf.MoveTowards(pos.x, JumpTargetPosition.x, Speed * Time.deltaTime);
        float baseY = Mathf.Lerp(transform.position.y, JumpTargetPosition.y, (nextX - StartJumpPosition.x) / dist);
        float arc = JumpForce * (nextX - StartJumpPosition.x) * (nextX - JumpTargetPosition.x) / (-0.25f * dist * dist);
        Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

        // Rotate to face the next position, and then move there
        Quaternion rotation = LookAt2D(nextPos - transform.position);
        transform.position = nextPos;

        // Do something when we reach the target
        if (transform.position == JumpTargetPosition)
        {
            OnJump = false;
        }; 
        */
    }

    static Vector3 GetArcPosition(Vector3 start, Vector3 end, float speed)
    {
        float dist = end.x - start.x;
        float nextX = dist * speed * Time.deltaTime;
        float baseY = Mathf.Lerp(start.y, end.y, (nextX - start.x) / dist);

        return new Vector3(nextX, baseY, start.z);
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

    static Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}
