using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public float speed = 1f;
    private bool outOfBounds;

    UnityEngine.Camera cam;

    // Start is called before the first frame update
    void Start()
    {

        cam = UnityEngine.Camera.main;
        outOfBounds = false;

    }

    public void Setup()
    {

        //changes the sprite that is shown to the one assigned
        spriteRenderer.sprite = sprite;

    }

    // Update is called once per frame
    void Update()
    {

        //Enemy moving right to left
        transform.position -= transform.up * Time.deltaTime * speed;

        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x <= 0 && viewPos.x >= 1 && viewPos.y <= 0 && viewPos.y >= 1 && viewPos.z < 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            outOfBounds = false;
        }
        else
            outOfBounds = true;

        if (outOfBounds)

            //EnemyManager.Instance.DespawnEnemy(gameObject); < -- caused enemies to not spawn at all.
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Checks if the enemy collides with a player ship, and if true deals damage
        if(collision.gameObject.tag == "Player")
        {

            Ship ship = collision.GetComponent<Ship>();
            ship.Damage(1);

        }

    }
}
