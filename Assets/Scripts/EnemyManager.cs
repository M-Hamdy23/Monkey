using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public GameObject EnemyType1;
    public GameObject EnemyType2;
    public GameObject spawnPos;
    public float respawnTime = 5;

    public int enemeyNumber=0;

    // Use this for initialization
    void Start () {
        StartCoroutine(Respawn());
        
    }
	
	// Update is called once per frame
	void Update () {
        
        
    }
    IEnumerator Respawn()
    {
        while (true)
        {
            int num = Random.Range(0, 3);
            if (num == 0 || num == 1)
            {
               var obj= Instantiate(EnemyType1);
                Vector3 pos = spawnPos.transform.position;
                pos.z = 0;
                pos.y = -3.158f;
                obj.transform.position = pos;
                obj.SetActive(true);
                enemeyNumber += 1;
               
            }
            else 
            {
                var obj = Instantiate(EnemyType2);
                Vector3 pos = spawnPos.transform.position;
                pos.z = 0;
                pos.y = -3.158f;
                obj.transform.position = pos;
                obj.SetActive(true);
                enemeyNumber += 1;

            }


            yield return new WaitForSeconds(respawnTime);
        }
    }


}
