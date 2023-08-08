using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> EnemySet;

    [System.Obsolete]
    void Update()
    {
        if(this.transform.childCount.Equals(0))
        {
            Instantiate(EnemySet[Random.RandomRange(0, EnemySet.Count)],this.transform.position,Quaternion.identity,this.transform);
        }
    }
}
