﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public Camera cam;
    public Vector2 target;
    public Transform throwPoint;
    public GameObject ball;
    public float speed = 1;
    public float timeTillHit = 1f;
    public int bananaCost=1;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("throw");
            MouseRayCast();
            //Throw();
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

        GameObject bulletInstance = Instantiate(ball, throwPoint.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        gameObject.GetComponent<MonkeyState>().banana-=bananaCost;
        Rigidbody2D rigid;
        rigid = bulletInstance.GetComponent<Rigidbody2D>();
        ball.GetComponent<ShurikenCollision>().hitdamage=GetComponent<MonkeyState>().hitdamage;
        rigid.velocity = new Vector2(xValue*speed, yValue*speed);
    }

    void MouseRayCast()
    {
        target = new Vector2(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y);
    }

    
}