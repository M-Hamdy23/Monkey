using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTreeBehavior : MonoBehaviour {

    
    public Tree target;
    public float speed=1;
    public Rigidbody2D rigid;
    private GameManager gameManger;
    private int index;
    // Use this for initialization
    void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");
        rigid = gameObject.GetComponent<Rigidbody2D>();
        gameManger = FindObjectOfType<GameManager>();
        index = gameManger.randomTree();
        target = gameManger.allTrees[index];
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(player.transform);
        if (target) {
            Debug.Log(target.gameObject.name);
            float dir = target.gameObject.transform.position.x - transform.position.x;
            if (Mathf.Abs(dir) >= 1.2f)
            {
                rigid.velocity = new Vector2(dir / Mathf.Abs(dir) * speed, 0);
                Debug.Log(rigid.velocity);
            }
            else
                rigid.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameManger.allTrees.RemoveAt(index);
            Destroy(target.gameObject);
            target = null;
        }
            
        
    }
    
    bool HpIsDone()
    {
        if (target.hp <= 0)
            return true;
        return false;
    }
}
