using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {

	void _die()
    {
        Destroy(GetComponentInParent<BoxCollider2D>().gameObject,2);
    }
}
