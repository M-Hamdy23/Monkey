using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    public float hp = 100;
    public List<EnemyTreeBehavior> myEnemy ;
    EnemyTreeBehavior target;
	// Use this for initialization
	void Start () {
        



	}
	
	// Update is called once per frame
	void Update () {
        check();
    }


    void check()
    {
        if (hp<=0)
        {
            
            target = myEnemy[0];
            

            for (int i = 0; i < myEnemy.Count; i++)
            {
                
                myEnemy[i].target = null;
                
            }
            target.removeTree();
            for (int i = 0; i < myEnemy.Count; i++)
            {
                
                myEnemy[i].RandomTarget();
               
            }

            Destroy(this.gameObject);
        }
    }



    /*
     gameManger.allTrees.RemoveAt(index);
            Destroy(target.gameObject);
            target = null;

            index = gameManger.randomTree();
            target = gameManger.allTrees[index];
     */

}
