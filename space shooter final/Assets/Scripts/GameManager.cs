using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    /// <comment>
    /// Reference to our game objects
    /// </comment>
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner; // reference to our enemy spawner
    public GameObject GameOverGo;//ref to game over img
    public GameObject scoreUITextGo;//ref to the tect ui object
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;
    // Use this for initialization
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    //function to update manager state 

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                //hide game over 
                GameOverGo.SetActive(false);

                //set play button visible (active)
                playButton.SetActive(true);
            break;

            case GameManagerState.Gameplay:

                //reset the score
                scoreUITextGo.GetComponent<GameScore>().Score = 0;

                //hide play button on gameplay screen
                playButton.SetActive(false);

                //set the player visible (active) and init the player live 
                playerShip.GetComponent<PlayerControl>().Init();

                //start the enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
            break;

            case GameManagerState.GameOver:
                //stop enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                //display game over
                GameOverGo.SetActive(true);
                //change game manager state to Opening state after 4 sec
                Invoke("ChangeToOpeningState", 4f);

            break;
        }

    }

    //function to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //our Play button cill call this func when the 
    //user clicks the play button
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();


    }
  
    
    //func to change game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

}