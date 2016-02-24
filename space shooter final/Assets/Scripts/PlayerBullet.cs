using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    
	// Use this for initialization
	void Start ()
    {
        speed = 8f;    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //get te bullet current position
        Vector2 position = transform.position;

        //compute the bullets new pos
        position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

        //update bullet pos
        transform.position = position;

        //this is top right pos of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));

        //if bullet goes above screen
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
     
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShipTag") 
        {
            Destroy(gameObject);
        }
    }

   
}
