using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameManager : MonoBehaviour {

    // Use this for initialization
    public List<Tree> allTrees;
    private void Awake()
    {
        var trees = FindObjectsOfType<Tree>();
        for (int i = 0; i < trees.Length; i++)
        {
            allTrees.Add(trees[i]);
        }
    }
    void Start () {
        
	}

    public int randomTree()
    {
        if (allTrees.Count <= 0)
            return -1;

        var num = Random.Range(0, allTrees.Count);
        return num;
    }
}
