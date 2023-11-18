using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    private Transform Player;
    [SerializeField] private float speed;
    private Transform garbagePool;
    [SerializeField] GameObject EnemyBullet;
    private void Awake()
    {
        garbagePool = GameObject.FindGameObjectWithTag("Garbage Pool").GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Start() {
        InvokeRepeating(nameof(Shoot), Random.Range(0f,1f),Random.Range(1f,2f));
    }
    void Shoot()
    {
        Instantiate(EnemyBullet,this.transform.position,Quaternion.identity, garbagePool);
    }
}
