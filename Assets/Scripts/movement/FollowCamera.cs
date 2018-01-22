using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float interpVelocity;
	public GameObject target;
	float LowY;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
        LowY = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target)
		{
			Vector3 posWithNoZ = transform.position;
            posWithNoZ.z = target.transform.position.z;
			Vector3 targetDirection = (target.transform.position - posWithNoZ);
			interpVelocity = targetDirection.magnitude * 10f;
			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            
            if (targetPos.y< LowY){
                targetPos.y = LowY;
            }
            transform.position = Vector3.Lerp( transform.position, targetPos , 0.25f);
            
		}
	}
}


