using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Canvas currentCanvas;
    public Canvas TitleScreen;
    public Canvas Credits;
    public Canvas PilotSelect;
    public Canvas GameplayUI;
    public GameObject Gameplay;
    public Sprite TestSprite;


    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {

        if(_instance == null)
        {
            _instance = this;
        }

        currentCanvas = TitleScreen;
        currentCanvas.gameObject.SetActive(true);

        //Turn off the other canvases
        Credits.gameObject.SetActive(false);
        PilotSelect.gameObject.SetActive(false);
        GameplayUI.gameObject.SetActive(false);
        Gameplay.SetActive(false);
        /*
         * 
         * TIP: Below is the code necessary to create an enemy
         * GameObject enemy = EnemyManager.Instance.SpawnEnemy(new Vector3(10,10,0));
         * 
        */
    }

    public void GoToCredits()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = Credits;
        currentCanvas.gameObject.SetActive(true);
        Gameplay.SetActive(false);
    }

    public void GoToPilotSelect()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = PilotSelect;
        currentCanvas.gameObject.SetActive(true);
        Gameplay.SetActive(false);
    }

    public void GoToTitleScreen()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = TitleScreen;
        currentCanvas.gameObject.SetActive(true);
        Gameplay.SetActive(false);
    }
        public void GoToGameplayUI()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = GameplayUI;
        currentCanvas.gameObject.SetActive(true);
        Gameplay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
