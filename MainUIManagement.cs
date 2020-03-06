using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManagement : MonoBehaviour
{

    public GameObject mainMenu, buildingMenu;

    // Start is called before the first frame update
    void Start()
    {
        OpenMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBuildingMenu()
    {
        buildingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        buildingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
