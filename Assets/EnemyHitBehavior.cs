using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBehavior : MonoBehaviour {

    public GameObject target;
    public float hitDamage = 0;
    public float speed = 1;
    public Rigidbody2D rigid;
    
    
    public bool isWork;
    public float coolDown;
    public float maxDis = 1.2f;
    Animator anim;
    public float hp = 100;

    
    
    
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        
        if (target)
        {
            
            float dis = transform.position.x - target.transform.position.x;

            Vector3 theScale = transform.localScale;
            theScale.x *= (dis / Mathf.Abs(dis));
            transform.localScale = theScale;

            float dir = target.transform.position.x - transform.position.x;
            rigid.velocity = new Vector2(dir / Mathf.Abs(dir) * speed, 0);
            isWork = true;


        }
        

        
    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {



            float dir = target.transform.position.x - transform.position.x;
            if (Mathf.Abs(dir) > maxDis)
            {

                rigid.velocity = new Vector2(dir / Mathf.Abs(dir) * speed, 0);
                anim.SetTrigger("walk");
                float dis = transform.position.x - target.transform.position.x;
                Vector3 theScale = transform.localScale;
                theScale.x = (dis / Mathf.Abs(dis));
                transform.localScale = theScale;
            }
            else
            {
                rigid.velocity = Vector2.zero;
                anim.SetTrigger("idle");
                if (isWork)
                {
                    anim.SetTrigger("cut");
                    //StopCoroutine(CoolDown());
                    StartCoroutine(CoolDown());
                }

            }
        }
        else
        {
            rigid.velocity = Vector2.zero;
            anim.SetTrigger("idle");
        }

        isDie();


    }

    void isDie()
    {
        if (hp <= 0)
        {
            anim.SetTrigger("die");
            
        }

    }



    

    IEnumerator CoolDown()
    {
        isWork = false;
        yield return new WaitForSeconds(coolDown);
        isWork = true;
    }


}
