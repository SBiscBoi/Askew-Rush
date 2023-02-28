using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //movement implementation inspired by https://www.youtube.com/watch?v=wpSm2O2LIRM

    public float speed;

    private Rigidbody2D rb;
    private Vector2 dir;

    //on-screen enforcement inspired by https://www.youtube.com/watch?v=ailbszpt_AI&t=165s

    private Vector2 screenBounds;
    private float ballWidth;
    private float ballHeight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        ballWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        ballHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector2(Input.acceleration.x * speed, Input.acceleration.y * speed);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounds.x + ballWidth, screenBounds.x - ballWidth), Mathf.Clamp(transform.position.y, -screenBounds.y + ballHeight, screenBounds.y - ballHeight));
    }

    private void FixedUpdate()
    {
        rb.velocity = dir;
    }
}
