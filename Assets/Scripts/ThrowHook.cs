﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHook : MonoBehaviour
{

    public GameObject hook;


    public bool ropeActive;

    GameObject curHook;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButtonDown(1))
        {


            if (ropeActive == false)
            {
                Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

                curHook.GetComponent<RopeScript>().destiny = destiny;

                gameObject.GetComponent<Moveplayer>().enabled = false;
                gameObject.GetComponent<PlayerScript>().enabled = true;

                ropeActive = true;
            }
            else
            {

                //delete rope
                
                Destroy(curHook);

                gameObject.GetComponent<Moveplayer>().enabled = true;
                gameObject.GetComponent<PlayerScript>().enabled = false;
                ropeActive = false;

            }
        }


    }
}