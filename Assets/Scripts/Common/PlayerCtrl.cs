using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Header("Jump")]
    public float JumpForce = 2f;

    [Header("Collision Effects")]
    public ParticleSystem OnGroundEffect;
    public float OnGroundEffectDelay;

    private Rigidbody RB;

    void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider && !OnGroundEffect.isPlaying) {
            OnGroundEffect.Play();
        }
    }

    void Jump()
    {
        if (RB == null) {
            return;
        }
        OnGroundEffect.Stop();
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
