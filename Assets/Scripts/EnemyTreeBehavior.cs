﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTreeBehavior : MonoBehaviour {

    
    public Tree target;
    public float hitDamage=0;
    public float speed=1;
    public Rigidbody2D rigid;
    private GameManager gameManger;
    public int index;
    public bool isWork;
    public float coolDown;
    public float maxDis = 1.2f;
    // Use this for initialization
    void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");
        rigid = gameObject.GetComponent<Rigidbody2D>();
        gameManger = FindObjectOfType<GameManager>();
        index = gameManger.randomTree();
        if (index != -1)
        {
            target = gameManger.allTrees[index];
            target.myEnemy.Add(this);

            float dis = transform.position.x - target.gameObject.transform.position.x;

            Vector3 theScale = transform.localScale;
            theScale.x *= (dis / Mathf.Abs(dis));
            transform.localScale = theScale;


        }
        else
            target = null;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (target) {
            
            float dir = target.gameObject.transform.position.x - transform.position.x;
            if (Mathf.Abs(dir) >= maxDis)
            {
                rigid.velocity = new Vector2(dir / Mathf.Abs(dir) * speed, 0);

            }
            else
            {
                rigid.velocity = Vector2.zero;
                HitTree();
            }
        }

        
            
        
    }
    
    void HitTree()
    {
         
        
    }

    bool HpIsDone()
    {
        if (target.hp <= 0)
            return true;
        return false;
    }

    public void RandomTarget()
    {
        if (gameManger.allTrees.Count>0) {
            index = gameManger.randomTree();
            if (index != -1)
            {
                target = gameManger.allTrees[index];
                target.myEnemy.Add(this);
            } else
                target = null;
        }
    }
    public void removeTree()
    {
        if (index != gameManger.allTrees.Count-1)
        {
            //gameManger.allTrees[index+1].
            for (int i = 0; i < gameManger.allTrees[index + 1].myEnemy.Count; i++)
            {
                gameManger.allTrees[index + 1].myEnemy[i].index = index;
            }
        }
        
        gameManger.allTrees.RemoveAt(index);
    }
    IEnumerator CoolDown()
    {
        isWork = false;
        yield return new WaitForSeconds(coolDown);
        isWork = true;
    }
}
