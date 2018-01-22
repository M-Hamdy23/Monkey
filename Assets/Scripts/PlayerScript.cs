using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float forcetoAdd = 10;
    public float forcetodown = 400;
    Rigidbody2D rig;
    RopeScript rs;
    void Start () {

        rig = GetComponent<Rigidbody2D>();
        
        rs=GetComponent<RopeScript>();
    }
	
	
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(Vector2.left * forcetoAdd);
            rig.AddForce(Vector2.down * forcetodown);
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce( Vector2.right* forcetoAdd);
            rig.AddForce(Vector2.down * forcetodown);
        }
    }
}
