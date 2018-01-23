using System.Collections;
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
        ropeActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //if (hit.collider)
        {
            //if (hit.collider.gameObject.tag == "bush" || ropeActive == true)
            {
                if (Input.GetMouseButtonDown(1))
                {


                    if (ropeActive == false &&hit.collider&& hit.collider.gameObject.tag == "bush")
                    {
                        Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                        curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

                        curHook.GetComponent<RopeScript>().destiny = destiny;

                        gameObject.GetComponent<MonkeyController>().enabled = false;
                        gameObject.GetComponent<PlayerScript>().enabled = true;

                        ropeActive = true;
                    }
                    else 
                    {

                        {

                            //delete rope

                            Destroy(curHook);

                            gameObject.GetComponent<MonkeyController>().enabled = true;
                            gameObject.GetComponent<PlayerScript>().enabled = false;
                            ropeActive = false;

                        }
                    }

                }

            }


        }
        /*else if (ropeActive)
        {
            
            {

                //delete rope

                Destroy(curHook);

                gameObject.GetComponent<MonkeyController>().enabled = true;
                gameObject.GetComponent<PlayerScript>().enabled = false;
                ropeActive = false;

            }
        }
        /*if (Input.GetMouseButtonDown(1))
        {

            //delete rope

            Destroy(curHook);

            gameObject.GetComponent<MonkeyController>().enabled = true;
            gameObject.GetComponent<PlayerScript>().enabled = false;
            ropeActive = false;

        }*/
    }
}