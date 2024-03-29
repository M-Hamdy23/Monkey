﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ObjectPooler : MonoBehaviour {
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    void Awake()
    {
        SharedInstance = this;
    }
    // Use this for initialization
    void Start () {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
