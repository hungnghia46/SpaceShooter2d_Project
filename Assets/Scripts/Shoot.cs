using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] AudioSource shootFx;
    [SerializeField] Transform bulletPool;
    [Range(0f,1f)][SerializeField] float shootRate;
    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), 1, shootRate);
    }
    void ShootBullet()
    {
        Quaternion bulletRotation = Quaternion.Euler(0, 0, transform.eulerAngles.z);
        Instantiate(bullet, this.transform.position, bulletRotation, bulletPool);
        shootFx.PlayOneShot(shootFx.clip);
    }
}
