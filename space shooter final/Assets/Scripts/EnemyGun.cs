using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGo;

	// Use this for initialization
	void Start ()
    {
        Invoke("FireEnemyBullet",1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("PlayerGo");

        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGo);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

        }
    }

}
