using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//adds UnityEvent to this script
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public float minY, minX, maxY, maxX;

    //creates a reference to a UnityEvent called shootEvent
    public UnityEvent shootEvent;
    private static PlayerMovement _instance;

    public static PlayerMovement Instance
    {
        get { return _instance; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if (_instance == null){

            _instance = this;

        }

        //instantiate the shootEvent
        shootEvent = new UnityEvent();


    }

    // Update is called once per frame
    void Update()
    {


        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            move.y += 0.025f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x += -0.025f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.y += -0.025f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x += 0.025f;
        }
        transform.position += move;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //.Invoke() calls all functions in the shootEvent list
            shootEvent.Invoke();
        }

    }
}
