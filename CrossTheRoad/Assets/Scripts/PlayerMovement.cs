using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Animacion")]
    private Animator animator;
    private Vector3 movement;
    public KeyCode[] controls;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("IsPlaying", false);
        if (!animator.GetBool("IsPlaying"))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position += Vector3.up * 0.5f;
                transform.rotation = Quaternion.Euler(0, 0, 0f);
                animator.SetBool("IsPlaying", true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position += Vector3.down * 0.5f;
                transform.rotation = Quaternion.Euler(0, 0, 180f);
                animator.SetBool("IsPlaying", true);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += Vector3.left * 0.5f;
                transform.rotation = Quaternion.Euler(0, 0, 90f);
                animator.SetBool("IsPlaying", true);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += Vector3.right * 0.5f;
                transform.rotation = Quaternion.Euler(0, 0, -90f);
                animator.SetBool("IsPlaying", true);
            }
            Debug.Log(animator.GetBool("IsPlaying"));
        }
    }
}
