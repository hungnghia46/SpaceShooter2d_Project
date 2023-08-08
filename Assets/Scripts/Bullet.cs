using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    void Update()
    {
        MoveFoward(speed);
    }
    void MoveFoward(float speed)
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
    private void LateUpdate()
    {
        Destroy(this.gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EventManager.Instance.StartScoreCountEvent(2);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
