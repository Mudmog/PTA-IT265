using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f;
    public float inactiveTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp += transform.right * speed * Time.deltaTime;
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {

            EnemyManager.Instance.DespawnEnemy(other.gameObject);
            Destroy(gameObject);

        }

    }
    
    // Update is called once per frame
    void Update()
    {

        Move();

    }
}