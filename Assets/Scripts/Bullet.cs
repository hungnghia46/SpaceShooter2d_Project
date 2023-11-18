using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] SpriteRenderer spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
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
            speed = 0;
            EventManager.Instance.StartScoreCountEvent(2);
            _particleSystem.Play();
            spriteRenderer.enabled = false;
            _boxCollider2D.enabled = false;
            Destroy(other.gameObject);
            //Destroy(this.gameObject);
        }
    }
}
