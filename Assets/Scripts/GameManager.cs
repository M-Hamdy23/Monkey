using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class GameManager : MonoBehaviour {

    // Use this for initialization
    public List<Tree> allTrees;
    public int bananaValue = 100;
    public int healthValue = 100;
    public int men = 100;
    public Text _banana;
    public Text _health;
    public Text _men;
    public GameObject player;
    public EnemyManager enemyManger;
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
