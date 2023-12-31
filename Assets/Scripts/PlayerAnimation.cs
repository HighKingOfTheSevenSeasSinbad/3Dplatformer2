using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb2;
    public LayerMask LayerMask;
    public bool grounded;
    public float ground = 0.3f;

    public GameObject ground_checker;


    void Start()
    {
        this.rb2 = GetComponent<Rigidbody>();


    }

    private void Update()
    {
        Grounded();
        Jump();
        Move();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            this.rb2.AddForce(Vector3.up * 7, ForceMode.Impulse);
        }

    }

    private void Grounded()
    {
        if (Physics.CheckSphere(ground_checker.transform.position, ground, LayerMask))
        {
            this.grounded = true;
            anim.SetBool("grounded", true);
        }
        else
        {
            this.grounded = false;
            anim.SetBool("grounded", false);
        }

        this.anim.SetBool("jump", !this.grounded);
    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();

        this.transform.position += movement * 0.015f;

        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);
    }
}