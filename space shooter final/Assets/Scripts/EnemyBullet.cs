using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    float speed;//bullet speed
    Vector2 _direction; //the direction of the bullet
    bool isReady;//to know bullet direction

    void Awake()
    {
        speed = 5f;
        isReady = false;

    }

	// Use this for initialization
	void Start ()
    {
        //fire an enemy bullet
        Invoke("FireEnemyBullet",1f);
	}

    //function to set bullet direction
    public void SetDirection(Vector2 direction)
    {
        //set the direction normalised to get a ub=nit vector
        _direction = direction.normalized;

        isReady = true;//set flag to true

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isReady)
        {
            //get the bullets current position
            Vector2 position = transform.position;

            //compute the bullet new position
            position += _direction * speed * Time.deltaTime;

            //update bullet pos
            transform.position = position;

            //remove bullet when it leaves screen
            //this is bottom left 
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            //this is top right
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            //if the bullet goes out of the screen destroy it
            if( (transform.position.x < min.x) || (transform.position.x > max.x )||
                    (transform.position.y < min.y) || (transform.position.y < min.y))
            {
                Destroy(gameObject);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShipTag") 
        {
            Destroy(gameObject);
        }
    }
}
