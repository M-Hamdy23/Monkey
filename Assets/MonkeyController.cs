using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour
{

    public float topSpeed;
    bool FaceRight = true;
    Animator anim;
    /// <summary>
    /// for ground
    /// </summary>
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700f;

    bool firstJump =true;
    private void Start()
    {
        grounded = true;

        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (!firstJump) { 
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            
        }
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));


        if (move > 0 && !FaceRight)
        {
            Flip();
            //anim;
        }
        else if (move < 0 && FaceRight)
        {
            Flip();
        }
    }
    private void Update()
    {
       
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
           firstJump = false;
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
    void Flip()
    {
        FaceRight = !FaceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
