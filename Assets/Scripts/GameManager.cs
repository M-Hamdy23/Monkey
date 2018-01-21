using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameManager : MonoBehaviour {

    // Use this for initialization
    public Tree []allTrees;
	void Start () {
        allTrees = FindObjectsOfType<Tree>() ;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
