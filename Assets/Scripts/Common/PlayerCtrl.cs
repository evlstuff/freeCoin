using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    [Header("Jump")]
    public float JumpForce = 2f;

    [Header("UI")]
    public MenuPanelCtrl MenuPanel;

    [Header("Collision Effects")]
    public ParticleSystem OnGroundEffect;
    public float OnGroundEffectDelay;

    private Rigidbody RB;

    void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    void OnDeath()
    {
        Time.timeScale = 0;

        if (MenuPanel != null) {
            MenuPanel.Show();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == null) {
            return;
        }

        switch(collision.collider.tag)
        {
            case "Ground":
                {
                    if(!OnGroundEffect.isPlaying) OnGroundEffect.Play();
                    break;
                }
            case "Enemy":
                {
                    OnDeath();
                    break;
                }
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
