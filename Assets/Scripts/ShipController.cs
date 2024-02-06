using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : Singleton<ShipController>
{
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] private float speed;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector2 screenBounds;
    private bool _isDead;

    private void Start()
    {
        _isDead = false;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        Vector2 mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouseDir - (Vector2)this.transform.position;
        float distanceToMouse = dir.magnitude;
        if (distanceToMouse < .3)
        {
            return;
        }
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        transform.Translate(speed * Time.deltaTime * Vector2.up);
        //Move player to oposite side when player reach the boder
        playerBoderCheck();

        if (_isDead)
        {
            Destroy(this.gameObject);
            loadHighScorePanel();
        }
    }

    private void loadHighScorePanel()
    {
        GameOverPanel.SetActive(true);
    }

    void playerBoderCheck()
    {
        Vector2 newPosition = transform.position;

        if (transform.position.x > screenBounds.x)
            newPosition.x = -screenBounds.x;
        else if (transform.position.x < -screenBounds.x)
            newPosition.x = screenBounds.x;

        if (transform.position.y > screenBounds.y)
            newPosition.y = -screenBounds.y;
        else if (transform.position.y < -screenBounds.y)
            newPosition.y = screenBounds.y;

        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            _isDead = true;
            _particleSystem.Play();
            _boxCollider2D.enabled = false;
            _spriteRenderer.enabled = false;
        }
    }
}
