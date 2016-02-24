using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{
    GameObject scoreUITextGo;//reference to text UI game object
    public GameObject Explosion;
    float speed;
	// Use this for initialization
	void Start ()
    {
        speed = 2f;//set speed

        scoreUITextGo = GameObject.FindGameObjectWithTag("ScoreTextTag");
	}

    // Update is called once per frame
    void Update()
    {
       
    //get the enemy current position
    Vector2 position = transform.position;

        //compte enemy new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //update the enemy position
        transform.position = position;

        //this is the lower left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //destroy the enemy when it passes the bottom
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            //add 100 points to the score
            scoreUITextGo.GetComponent<GameScore>().Score += 100;

            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        //pos
        explosion.transform.position = transform.position;
    }
}
