using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    //private float posX, posY;

    private Vector2 screenBounds;
    private float holeWidth;
    private float holeHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        holeWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        holeHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        transform.position = randomHolePos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ball"))
        {
            transform.position = randomHolePos();
            //increment score
        }
    }

    private Vector3 randomHolePos()
    {
        float posX = Random.Range(-screenBounds.x + holeWidth, screenBounds.x - holeWidth);
        float posY = Random.Range(-screenBounds.y + holeHeight, screenBounds.y - holeHeight);

        //duplicate location prevention later

        return new Vector3(posX, posY, 0);
    }
}
