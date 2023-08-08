using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetBrain : MonoBehaviour
{
    void Update()
    {
        if(this.transform.childCount.Equals(0))
        {
            Destroy(this.gameObject);   
        }
    }
}
