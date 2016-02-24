using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour
    {
    public GameManager GameManageGo;//ref game manager 

    public GameObject PlayerBulletGo;
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;
    public GameObject Explosion;

    //renference to the lives ui text
    public Text LivesUIText;

    const int MaxLives = 3; //max player lives
    int lives;//current player lives


    public float speed;

    public void Init()
    {
        lives = MaxLives;

        //update the lives UI text
        LivesUIText.text = lives.ToString();

        //reset player position to the center of the screen
        transform.position = new Vector2(0,0);

        //set this player game object to active
        gameObject.SetActive(true);
    }
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //fire bullest when the space bar is pressed
        if (Input.GetKeyDown("space"))
        {
            //playsound effect
            GetComponent<AudioSource>().Play();

            //instntate the first bullet
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGo);
            bullet01.transform.position = bulletPosition01.transform.position;//set initial bullet position

            //Instante the second bullet
            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGo);
            bullet02.transform.position = bulletPosition02.transform.position;//set the initial bullet position for bullet 2
        }

        float x = Input.GetAxisRaw ("Horizontal");//the value will be -1,0,1 fro left ,noinput, right
        float y = Input.GetAxisRaw ("Vertical");

        //compute a direction vector, amd we normmalise it to get a unit vector
        Vector2 direction = new Vector2(x,y).normalized;

        //call the function that conputes and sets the players position
        Move (direction);
    }
    void Move(Vector2 direction)
    {
        //find the screen liits the player movement
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//bottom left of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y - 0.285f;

        //get the palyers current pos
        Vector2 pos = transform.position;

        //calculate the new positiion
        pos += direction * speed * Time.deltaTime;

        //make sure the new positio n is outside the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //update the players position
        transform.position = pos;


    }
      void OnTriggerEnter2D(Collider2D col)
      {
          //detect collision 
         if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
          {
            PlayExplosion();

            lives--;//subtract one life

            LivesUIText.text = lives.ToString ();//update lives UI text

            if (lives == 0)//if our player is dead
                
            {
                //change game mananger state to game over state
                GameManageGo.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                //hide player ship
                gameObject.SetActive(false);
   
            }

          }
      }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);
        //pos
        explosion.transform.position = transform.position;
    }

      
}
