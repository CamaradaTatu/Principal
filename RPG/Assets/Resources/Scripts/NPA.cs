using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPA : MonoBehaviour
{
    private Collider2D collider;
    public Animator animator;

    private void Start()
    {
        collider = GameObject.Find("MC").GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.Play("NPAentry");
    }

}
