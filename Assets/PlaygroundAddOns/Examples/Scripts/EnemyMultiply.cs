using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

public class EnemyMultiply : MonoBehaviour
{

    [Header("Referenc Enemy")]
    public GameObject enemy;
    [Header("Count of the Enemy")]
    public int anzEnemys;


    public float rangeMinX;
    public float rangeMaxX;

    [HideInInspector]
    public float minLimit = -60;
    [HideInInspector]
    public float maxLimit = 60;

    // Start is called before the first frame update
    void Start()
    {
        if(enemy != null)
        {
            for(int i = 0; i < anzEnemys; i++)
            {
                Vector3 newPos = new Vector3(Random.Range(rangeMinX, rangeMaxX),0,0 );
                GameObject newEnemy = Instantiate(enemy, newPos, Quaternion.identity);
                newEnemy.transform.SetParent(transform);
            }
        }
    }

}
