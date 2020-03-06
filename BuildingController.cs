using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingController : MonoBehaviour
{

    int bldg_Level;
    int bldg_UpCost;
    public float bldg_CashPerSec;
    public float bldg_MatsPerSec;
    public float bldg_FoodPerSec;
    public float bldg_WattPerSec;

    public float bldg_growthRate;
    public int bldg_Requirement;

    float currentTime = 0f;
    float period = 1f;

    GameManager gm;
    ResouceController resources;

    public GameObject menu_panel;
    public GameObject btn_upgrade;
    public GameObject txt_resPerSec;
    public GameObject txt_upCost;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        resources = FindObjectOfType<ResouceController>();

        float level = bldg_Level * 1f;
        float growth = 1 + (level * bldg_growthRate);
        bldg_UpCost = (int)Mathf.Pow(10, growth) + (int)(level * 10);

        btn_upgrade.GetComponent<Button>().onClick.AddListener(BuildUpgradeBuilding);

        if (bldg_Level == 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            btn_upgrade.GetComponentInChildren<Text>().text = "Build";
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            btn_upgrade.GetComponentInChildren<Text>().text = "Upgrade";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(bldg_Requirement > gm.GetTotalBldgLevel())
        {
            menu_panel.SetActive(false);
        }
        else
        {
            menu_panel.SetActive(true);
        }


        currentTime += Time.deltaTime;
        if(currentTime >= period)
        {
            currentTime = 0f;

            resources.incrementResource(bldg_CashPerSec* bldg_Level, "cash");
            resources.incrementResource(bldg_MatsPerSec* bldg_Level, "mats");
            resources.incrementResource(bldg_FoodPerSec* bldg_Level, "food");
            resources.incrementResource(bldg_WattPerSec * bldg_Level, "watt");
        }

        int production;
        production = (int)Mathf.Max(bldg_CashPerSec, bldg_MatsPerSec, bldg_FoodPerSec, bldg_WattPerSec)*bldg_Level;

        txt_resPerSec.GetComponent<Text>().text = "Production: " + production + "/Sec";

        

        if(resources.GetCash() < bldg_UpCost || resources.GetMats() < bldg_UpCost || resources.GetFood() < bldg_UpCost)
        {
            btn_upgrade.GetComponent<Button>().interactable = false;
        }
        else
        {
            btn_upgrade.GetComponent<Button>().interactable = true;
        }

        int cost;
        cost = (int)bldg_UpCost;

        txt_upCost.GetComponent<Text>().text = cost.ToString();
    }

    void BuildUpgradeBuilding()
    {
        btn_upgrade.GetComponent<Button>().interactable = false;
        if (resources.GetCash() < bldg_UpCost || resources.GetMats() < bldg_UpCost || resources.GetFood() < bldg_UpCost)
        {
            return;
        }
        resources.incrementResource(bldg_UpCost * -1, "cash");
        resources.incrementResource(bldg_UpCost * -1, "mats");
        resources.incrementResource(bldg_UpCost * -1, "food");

        bldg_Level++;
        gm.AddTotalBldgLevel();

        if (bldg_Level == 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            btn_upgrade.GetComponentInChildren<Text>().text = "Build";
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            btn_upgrade.GetComponentInChildren<Text>().text = "Upgrade";
        }

        float level = bldg_Level * 1f;
        float growth = 1 + (level * bldg_growthRate);
        bldg_UpCost = (int)Mathf.Pow(10, growth)+(int)(level*10);
    }
}
