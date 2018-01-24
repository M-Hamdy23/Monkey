using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public  class GameManager : MonoBehaviour {

    // Use this for initialization
    public List<Tree> allTrees;
    
    public int men = 0;
    
    public Text _banana;
    public Text _health;
    public Text _men;
    public MonkeyState player;
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
        _men.text = "0";
        _health.text = ((int)(player.hp)).ToString();
        _banana.text = player.banana.ToString();
	}

    public int randomTree()
    {
        if (allTrees.Count <= 0)
            return -1;

        var num = Random.Range(0, allTrees.Count);
        return num;
    }
    private void Update()
    {
        if (allTrees.Count <= 0 || player.hp<=0)
        {
            enemyManger.gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }

        _health.text = ((int)(player.hp)).ToString();
        _men.text = enemyManger.enemeyNumber.ToString();
        _banana.text = player.banana.ToString();
    }
}
