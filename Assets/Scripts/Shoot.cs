using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] AudioSource shootFx;
    private Transform garbagePool;
    [Range(0f,1f)][SerializeField] float shootRate;
    private void Awake()
    {
        garbagePool = GameObject.FindGameObjectWithTag("Garbage Pool").GetComponent<Transform>();
    }
    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), 1, shootRate);
    }
    void ShootBullet()
    {
        Quaternion bulletRotation = Quaternion.Euler(0, 0, transform.eulerAngles.z);
        Instantiate(bullet, this.transform.position, bulletRotation, garbagePool);
        shootFx.PlayOneShot(shootFx.clip);
    }
}
