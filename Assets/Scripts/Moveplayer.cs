using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplayer : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float speed = 10f;
    bool FacingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpFource = 700f;


    private void Start()
    {
        //anim = GetComponant<Animator>();

        rigidBody2D = this.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("Ground", grounded);
        //anim.SetFloat("vSpeed", rigidBody2D.velocity.y);

        float move = Input.GetAxis("Horizontal");
        //anim.SetFloat("Speed",Mathf.Abs(move));

        rigidBody2D.velocity = new Vector2(move * speed, rigidBody2D.velocity.y);
        if (move > 0 && !FacingRight)
        {
            Flip();
        }
        else if (move < 0 && FacingRight)
        {
            Flip();
        }
    }
    private void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            //anim.SetBool("Ground", false);
            this.rigidBody2D.AddForce(new Vector2(0, jumpFource));
        }

    }
    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //private void Start()
    //{
    //    rigidBody2D = this.GetComponent<Rigidbody2D>();
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        this.rigidBody2D.velocity = new Vector2(speed, this.rigidBody2D.velocity.y);
    //        Debug.Log("errorrrrrrrrr");
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))


    //    {
    //        this.rigidBody2D.velocity = new Vector2(-speed, this.rigidBody2D.velocity.y);

    //    }
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        this.rigidBody2D.AddForce(new Vector2(0, speed * 2));
    //        //this.rigidBody2D.velocity = new Vector2(this.rigidBody2D.velocity.x, speed);

    //    }
    //}
}

