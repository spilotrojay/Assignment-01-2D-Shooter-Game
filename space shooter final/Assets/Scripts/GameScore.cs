using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;
    int score;
    
    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

	// Use this for initialization
	void Start ()
    {
        //get the text ui component of this gameobject
        scoreTextUI = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        //get the text ui component of this game object
        scoreTextUI = GetComponent<Text>();
    }

    //function to update text ui component of this gameobject
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        scoreTextUI.text = scoreStr;
    }
	
	
}
