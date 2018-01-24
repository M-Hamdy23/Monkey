using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrajectory : MonoBehaviour {

    
    public GameObject target;
    public Transform throwPoint;
    public GameObject ball;
    public float speed = 1;
    public float timeTillHit = 1f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Throw()
    {
        float xdistance;
        xdistance = target.transform.position.x - throwPoint.position.x;

        float ydistance;
        ydistance = target.transform.position.y - throwPoint.position.y;

        float throwAngle;

        throwAngle = Mathf.Atan((ydistance + 4.905f * (timeTillHit * timeTillHit)) / xdistance);

        float totalValue = xdistance / (Mathf.Cos(throwAngle) * timeTillHit);

        float xValue, yValue;
        xValue = totalValue * Mathf.Cos(throwAngle);
        yValue = totalValue * Mathf.Sin(throwAngle);

        GameObject bulletInstance = Instantiate(ball, throwPoint.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigid;
        rigid = bulletInstance.GetComponent<Rigidbody2D>();
        //ball.GetComponent<ShurikenCollision>().hitdamage = GetComponent<MonkeyState>().hitdamage;
        rigid.velocity = new Vector2(xValue * speed, yValue * speed);
    }





}
