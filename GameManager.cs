using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject dm;

    int total_BldgLevels;
    int hq_level;
    int mine_level;
    int farm_level;
    int pow_level;

    GameObject powPanel;

    enum GameState { IDLE,
                   TOWN,
                   FARM
    }

    GameState gameState = new GameState();

    //Will run everytime the scene loads or object is disabled and reenabled
    void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case ("MainScene"):
                {
                    gameState = GameState.TOWN;
                    powPanel = GameObject.Find("Side Panel");
                    if (pow_level > 1)
                    {
                        powPanel.SetActive(true);
                    }
                    else
                    {
                        powPanel.SetActive(false);
                    }
                    return;
                }
            case ("AtTheFarm"):
                {
                    return;
                }
        }
        
    }


    // Start is called before the first frame update
    //On start check if GameManager already exists, destroy self if there is another game manager
    //Highlander rules
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        gameState = GameState.TOWN;
        dm.GetComponent<DisplayMessage>().SetMessage("Hello and welcome to the game, please click on the ground to scout the area for resources, then start building!");
        dm.GetComponent<DisplayMessage>().openMessageBox();

        total_BldgLevels = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTotalBldgLevel()
    {
        total_BldgLevels++;
    }

    public int GetTotalBldgLevel()
    {
        return (total_BldgLevels);
    }

    public void AddPowLevel()
    {
        pow_level++;
        if (pow_level > 1)
        {
            powPanel.SetActive(true);
        }
    }
}
