using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

	void _die()
    {
        GameObject.FindObjectOfType<EnemyManager>().enemeyNumber -= 1;
        Destroy(GetComponentInParent<BoxCollider2D>().gameObject,2);
    }
}
