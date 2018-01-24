using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenCollision : MonoBehaviour {
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
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<EnemyTreeBehavior>())
            {

                collision.gameObject.GetComponent<EnemyTreeBehavior>().hp -= hitdamage;
            }
            if (collision.gameObject.GetComponent<EnemyHitBehavior>())
            {
                collision.gameObject.GetComponent<EnemyHitBehavior>().hp -= hitdamage;
            }

            collision.gameObject.GetComponent<AudioSource>().Play();

        }
        if (collision.gameObject.tag != "tree")
            Destroy(gameObject);
    }
}
