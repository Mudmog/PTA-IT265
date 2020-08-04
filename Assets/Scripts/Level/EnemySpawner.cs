using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Sprite enemySprite;
    public float enemySpeed;
    public List<GameObject> spawnPoints;
    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {

        newWave();

    }

    public void newWave()
    {
        foreach (GameObject point in spawnPoints)
        {

            //Places a enemy at an arbitrary point (spawner)
            GameObject enemyObj = EnemyManager.Instance.SpawnEnemy(point.transform.position);

            //Gets the enemy script from the generated enemy and attaches it to the enemy script
            Enemy enemy = enemyObj.GetComponent<Enemy>();

            //Rotates the enemy in the same direction as the spawner
            enemyObj.transform.rotation = transform.rotation;

            //Assigns the enemy its given sprite
            enemy.sprite = enemySprite;

            //Assigns the enemy its given speed
            enemy.speed = enemySpeed;

            //Calls the Setup() method in Enemy.cs
            enemy.Setup();

        }
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            newWave();
            timer = 3f;

        }

    }
}
