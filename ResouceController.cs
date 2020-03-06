using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResouceController : MonoBehaviour
{

    float cash = 300;
    float mats = 300;
    float food = 300;
    float watt = 0;

    float maxWatt = 1000;

    public Text txt_cash;
    public Text txt_mats;
    public Text txt_food;

    public Button btn_powerSurge;
    public Button btn_overload;

    public float powerSurgeCost;
    public float overloadCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt_cash.text = cash.ToString();
        txt_mats.text = mats.ToString();
        txt_food.text = food.ToString();

        if(btn_powerSurge != null)
        {
            if (watt >= powerSurgeCost)
            {
                btn_powerSurge.interactable = true;
            }
            else
            {
                btn_powerSurge.interactable = false;
            }

            if (watt >= overloadCost)
            {
                btn_overload.interactable = true;
            }
            else
            {
                btn_overload.interactable = false;
            }
        }
        
    }

    public void incrementResource(float amount, string resource)
    {
        switch(resource){
            case("cash"):
                {
                    cash += amount;
                    break;
                }
            case ("mats"):
                {
                    mats += amount;
                    break;
                }
            case ("food"):
                {
                    food += amount;
                    break;
                }
            case ("watt"):
                {
                    if(watt >= maxWatt)
                    {
                        watt = maxWatt;
                    }
                    else
                    {
                        watt += amount;
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public float GetCash()
    {
        return cash;
    }

    public float GetMats()
    {
        return mats;
    }

    public float GetFood()
    {
        return food;
    }

    public float GetWatt()
    {
        return watt;
    }

    public void PowerSurge()
    {
        btn_powerSurge.interactable = false;
        incrementResource(-300, "watt");
        incrementResource(10 * GameManager.instance.GetTotalBldgLevel(), "cash");
        incrementResource(10 * GameManager.instance.GetTotalBldgLevel(), "mats");
        incrementResource(10 * GameManager.instance.GetTotalBldgLevel(), "food");
        return;
    }
}
