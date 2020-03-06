using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDateTime : MonoBehaviour
{

    Text dateTimeText;
    string dateTimeFinal;

    // Start is called before the first frame update
    void Start()
    {
        dateTimeText = GameObject.Find("Time and Date Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        SplitStringIntoWords();
        dateTimeText.text = dateTimeFinal;
    }

    void SplitStringIntoWords()
    {
        string dateTimeRaw = System.DateTime.Now.ToString();
        string[] dateTimeSplit = dateTimeRaw.Split('/', ':',' ');

        //Change month to text version of the month.
        switch (dateTimeSplit[0])
        {
            case "1":
                {
                    dateTimeSplit[0] = "January";
                    break;
                }
            case "2":
                {
                    dateTimeSplit[0] = "February";
                    break;
                }
            case "3":
                {
                    dateTimeSplit[0] = "March";
                    break;
                }
            case "4":
                {
                    dateTimeSplit[0] = "April";
                    break;
                }
            case "5":
                {
                    dateTimeSplit[0] = "May";
                    break;
                }
            case "6":
                {
                    dateTimeSplit[0] = "June";
                    break;
                }
            case "7":
                {
                    dateTimeSplit[0] = "July";
                    break;
                }
            case "8":
                {
                    dateTimeSplit[0] = "August";
                    break;
                }
            case "9":
                {
                    dateTimeSplit[0] = "September";
                    break;
                }
            case "10":
                {
                    dateTimeSplit[0] = "October";
                    break;
                }
            case "11":
                {
                    dateTimeSplit[0] = "November";
                    break;
                }
            case "12":
                {
                    dateTimeSplit[0] = "December";
                    break;
                }
        }

        //put a 'st, 'nd, 'rd or 'th at the end of the day number
        //define i as the index number of the character looked at to determine the ending.
        int i;
        if (dateTimeSplit[1].ToCharArray().Length < 2)
        {
            i = 0;
        }
        else
        {
            i = 1;
        }
            switch (dateTimeSplit[1].ToCharArray()[i]) 
            {
                case '1':
                    {
                        dateTimeSplit[1] += "st";
                        break;
                    }
                case '2':
                    {
                        dateTimeSplit[1] += "nd";
                        break;
                    }
                case '3':
                    {
                        dateTimeSplit[1] += "rd";
                        break;
                    }
                default:
                    {
                        dateTimeSplit[1] += "th";
                        break;
                    }
            }
        
        //dateTimeSplit[2] holds the year information, So add this in if you need it for your app.

        //put the string together into one string for the final display
        dateTimeFinal = dateTimeSplit[0] + " " + dateTimeSplit[1] + "\n" + dateTimeSplit[3] + ":" + dateTimeSplit[4] + " " + dateTimeSplit[6];

        /* Used for debugging purposes while creating code. uncomment section while modifying to quickly test results.
        foreach (string s in dateTimeSplit)
        {
            Debug.Log(s);
        }
        Debug.Log(dateTimeFinal);
        */
    }
}
