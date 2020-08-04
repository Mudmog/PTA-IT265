using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    //Our list of enemies that we create before entering a level
    private List<GameObject> enemies;

    //references an enemy prefab
    public GameObject enemyPrefab;

    //sets the maximum amount of enemies in the enemies List
    public int maxEnemies = 15;

    //Creates the EnemyManager
    private static EnemyManager _instance;
    public static EnemyManager Instance
    {
        get
        {
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        if (_instance == null)
        {
            _instance = this;
        }

        //creates a new empty list in enemies
        enemies = new List<GameObject>();


        //Populates the list with copies of enemyPrefab
        for (int i = 1; i < maxEnemies; i++)
        {
            GameObject obj = Instantiate<GameObject>(enemyPrefab);
            obj.name = "Enemy " + i;
            enemies.Add(obj);

        }

    }

    public GameObject SpawnEnemy(Vector3 position)
    {

        //if there are 0 or fewer things in the list, an error will be shown
        if (enemies.Count < 1)
        {
            Debug.LogError("EnemyManager.SpawnEnemy: No available enemies.");
            return null;
        }

        //points enemy at the first enemy in the list
        GameObject enemy = enemies[0];

        //removes that enemy from the list
        enemies.RemoveAt(0);

        //places the enemy at a spawnpoint
        enemy.transform.position = position;

        //activates the enemy in the game scene
        enemy.SetActive(true);

        return enemy;

    }

    public void DespawnEnemy(GameObject enemy)
    {

        //adds an enemy back into the list
        enemies.Add(enemy);

        //disables an enemy in the game scene
        enemy.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
