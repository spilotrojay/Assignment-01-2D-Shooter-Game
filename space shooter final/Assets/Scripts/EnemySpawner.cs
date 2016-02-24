using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGo;
    float maxSpawnRateInSeconds = 5f;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    //function to spawn an enemy
    void SpawnEnemy()
    {
        //this is the botttom - left of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top right point of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //instantate the enemy
        GameObject anEnemy = (GameObject)Instantiate(EnemyGo);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //schedule next spawn
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            //pick a no btw 1 and maxspawnrate...
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);

        }
        else
            spawnInNSeconds = 1f;
        Invoke ("SpawnEnemy", spawnInNSeconds);
    }
    //Func to increase difficultuy

    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");

        }
        
    }
    //func to start enemy spawner
    public void ScheduleEnemySpawner()
    {
        //reset max spawn rate
        float maxSpawnRateInSeconds = 5f;
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //increase spawn reate every 30secs
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }
    //func to stop enemy spawner
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
        
    }
}
