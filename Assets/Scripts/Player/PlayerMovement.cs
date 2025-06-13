using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlaterMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rb;

    // Animation
    private Animator anim;
    private SpriteRenderer sprite;

    private bool _isWalking;
    private bool _isWalkingSoundsActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (PauseMenu.instance.activeOption != PauseMenu.ACTIVE_OPTION.NONE || !Player.instance.canWalk)
        {
            return;
        }

        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rb.linearVelocity = direction.normalized * speed;

        // Walking sound
        _isWalking = direction != new Vector2(0, 0);
        if (_isWalking)
        {
            Dictionary<int, AudioClip> walkingSounds = new()
            {
                {1, AudioManager.instance.grass},
                {2, AudioManager.instance.wood},
                {4, AudioManager.instance.stone},
            };

            if (!_isWalkingSoundsActive)
            {
                StartCoroutine(walkingSound(walkingSounds[SceneManager.GetActiveScene().buildIndex]));
            }
        }

        if (direction.x != 0)
        {
            // Walk sides
            ResetLayers();
            anim.SetLayerWeight(2, 1);
            sprite.flipX = !(direction.x > 0);
        }
        else if (direction.y != 0)
        {
            ResetLayers();
            anim.SetLayerWeight(direction.y > 0 ? 1 : 0, 1);
        }

        // Is walking or not
        anim.SetBool("walking", direction != Vector2.zero);
    }

    private IEnumerator walkingSound(AudioClip clip)
    {
        _isWalkingSoundsActive = true;
        AudioManager.instance.walkingSfx.clip = clip;
        AudioManager.instance.walkingSfx.Play();
        yield return new WaitUntil(() => !_isWalking);
        AudioManager.instance.walkingSfx.Stop();
        _isWalkingSoundsActive = false;
    } 

    private void ResetLayers()
    {
        for (int i = 0; i < 3; i++)
        {
            anim.SetLayerWeight(i, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // SFX
        // if (_rb.linearVelocity != new Vector2(0, 0))
        // {
        //     Debug.Log("Entrou direction");
        //     switch (SceneManager.GetActiveScene().buildIndex)
        //     {
        //         case 1:
        //             Debug.Log("case 1");
        //             AudioManager.instance.PlaySFXLoop(AudioManager.instance.grass, AudioManager.instance.walkingSfx);
        //             break;
        //         case 2:
        //             Debug.Log("case 2");
        //             AudioManager.instance.PlaySFXLoop(AudioManager.instance.stone, AudioManager.instance.walkingSfx);
        //             break;
        //     }
        // }
        // else
        // {
        //     AudioManager.instance.walkingSfx.Stop();
        // }

    }
}
