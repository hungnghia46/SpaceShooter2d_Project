using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(2 * Time.deltaTime * Vector2.down);
    }
    private void LateUpdate()
    {
        Destroy(this.gameObject, 5f);
    }
}
