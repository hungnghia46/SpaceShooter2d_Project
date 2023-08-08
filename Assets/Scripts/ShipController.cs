using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 screenBounds;
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        Vector2 mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mouseDir - (Vector2)this.transform.position;
        float distanceToMouse = dir.magnitude;
        if(distanceToMouse < .3)
        {
           return;
        }
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        transform.Translate(speed * Time.deltaTime * Vector2.up);
        //Move player to oposite side when player reach the boder
        BoderCheck();
    }
    void BoderCheck()
    {
        if (transform.position.x > screenBounds.x)
            transform.position = new Vector2(-screenBounds.x, transform.position.y);
        else if (transform.position.x < -screenBounds.x)
            transform.position = new Vector2(screenBounds.x, transform.position.y);
        if (transform.position.y > screenBounds.y)
            transform.position = new Vector2(transform.position.x, -screenBounds.y);
        else if (transform.position.y < -screenBounds.y)
            transform.position = new Vector2(transform.position.x, screenBounds.y);
    }
}
