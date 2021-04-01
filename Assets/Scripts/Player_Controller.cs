using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public float GroundDis = .03f;
    public float JumpHeight = 500f;
    public LayerMask Grounded;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));
        if (h < 0.0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h > 0.0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsJump", true);
            anim.SetBool("grounded", false);
            rb.AddForce(Vector3.up * JumpHeight);
            anim.SetTrigger("Jump");
        }
        else if (Physics2D.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, GroundDis, Grounded))
        {
            anim.SetBool("IsJump", false);
            anim.SetBool("grounded", true);
            anim.applyRootMotion = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("IsAttack", true);
            anim.SetTrigger("Attack");
        }
    }
}
