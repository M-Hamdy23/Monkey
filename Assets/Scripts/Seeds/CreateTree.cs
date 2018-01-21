using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTree : MonoBehaviour
{
    public Camera cam;
    private Vector2 target;
    public Transform throwPoint;
    public GameObject ball;
    public float speed = 1;
    public float timeTillHit = 1f;
    public int MaxTreeNum = 3;
    public int Trees = 0;
    
    void Start()
    {
        if (!cam)
            cam = Camera.main;
        throwPoint = this.GetComponent<Transform>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            MouseRayCast();
            if (Trees < MaxTreeNum)
            {
                Throw();
                Trees += 1;
            }

        }

    }
    

    void Throw()
    {
        float xdistance;
        xdistance = target.x - throwPoint.position.x;

        float ydistance;
        ydistance = target.y - throwPoint.position.y;

        float throwAngle;

        throwAngle = Mathf.Atan((ydistance + 4.905f * (timeTillHit * timeTillHit)) / xdistance);

        float totalValue = xdistance / (Mathf.Cos(throwAngle) * timeTillHit);

        float xValue, yValue;
        xValue = totalValue * Mathf.Cos(throwAngle);
        yValue = totalValue * Mathf.Sin(throwAngle);

        GameObject bulletInstance = Instantiate(ball, throwPoint.position+new Vector3(0.5f,0,0), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigid;
        rigid = bulletInstance.GetComponent<Rigidbody2D>();

        rigid.velocity = new Vector2(xValue * speed, yValue * speed);
    }

    void MouseRayCast()
    {
        target = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);
    }
}
