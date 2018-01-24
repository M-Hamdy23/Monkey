using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitCollision : MonoBehaviour {

    public float hitdamage;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        collision.gameObject.GetComponent<Tree>().hp -= hitdamage;

    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<MonkeyState>())
            {
                collision.gameObject.GetComponent<MonkeyState>().hp -= hitdamage;
            }

        }else if(collision.gameObject.tag !="Enemy" )
            Destroy(gameObject);
    }
}
