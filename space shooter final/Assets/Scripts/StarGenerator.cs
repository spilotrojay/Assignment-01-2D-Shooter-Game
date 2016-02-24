using UnityEngine;
using System.Collections;

public class StarGenerator : MonoBehaviour
{
    public GameObject StarGo;
    public int MaxStars;// the maximum number of stars 

    //array of colours 
    Color[] starColours =
        {
            new Color(0.5f,0.5f,1f),//blue
            new Color(0,1f,1f),//green
            new Color(1f,1f,0),//yellow
            new Color(1f,0,0),//red

        };

	// Use this for initialization
	void Start ()
    {
        //this is the bottom-left point of the screen 
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        //loop to creat the stars
        for (int i = 0; i < MaxStars; i++)
        {
            GameObject star = (GameObject)Instantiate(StarGo);

            //set the star colour
            star.GetComponent<SpriteRenderer>().color = starColours[i % starColours.Length];

            //set the pos of the star(random x and y)
            star.transform.position = new Vector2(Random.Range(min.x,max.x), Random.Range(min.y,max.y));

            //set a random speedfor the star
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            //make the star a child of StarGeneratorGo
            star.transform.parent = transform;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
