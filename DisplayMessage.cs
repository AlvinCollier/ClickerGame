
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Written by Alvin Lee Collier, Dragoon Domain
//Free for commercial/non-commercial use with credit given
//This script is designed to be attatched to a panel with a text object as a child
//

public class DisplayMessage : MonoBehaviour
{

    // Variables for Opening and Closing Message Box
    int dir = 0;
    float speed = 0.05f;
    float fullSize = 1;
    float currentSize = 0;

    // Set variables for timing
    public float charDisplayTimer = .05f;
    private float charCurrentTime;

    // Set variables for typing message into box
    private char[] letters;
    private int currentLetter = 0;
    private string currentMsg;

    // Sound Effect
    public AudioSource txtNoise;


    // Message that gets passed in from controller
    string Msg;

    List<string> msgToDisplay = new List<string>();

    bool goNextMsg = false;

    // Use this for initialization
    void Start()
    {

    }

    // When object becomes visible
    void Awake()
    {

        this.transform.localScale = new Vector3(1, 0, 1);
        charDisplayTimer = .05f;
    }

    // Update is called once per frame
    void Update()
    {

        if (dir != 0)
        {
            currentSize += speed * dir;
        }

        if (currentSize > fullSize)
        {
            currentSize = fullSize;
            dir = 0;
        }
        else if (currentSize < 0)
        {
            currentSize = 0;
            dir = 0;
            this.gameObject.SetActive(false);
        }
        this.transform.localScale = new Vector3(1, currentSize, 1);

        if (letters == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            charDisplayTimer = .01f;
            if(currentLetter >= letters.Length)
            {
                goNextMsg = true;
                closeMessageBox();
            }
        }

        if (charCurrentTime <= 0)
        {
            currentMsg += letters[currentLetter];
            this.gameObject.GetComponentInChildren<Text>().text = currentMsg;
            charCurrentTime = charDisplayTimer;
            if (currentLetter < letters.Length)
            {
                //Play sound effect
                if (letters[currentLetter].Equals(" ") || currentLetter % 3 == 0)
                {

                }
                else if (txtNoise != null)
                {
                    txtNoise.Play();
                }
                currentLetter++;
            }



        }
        if (currentLetter == letters.Length)
        {
            currentMsg = "";
        }
        else
        {
            charCurrentTime = charCurrentTime - Time.deltaTime;
        }

    }



    public void openMessageBox()
    {
        dir = 1;
    }

    public void closeMessageBox()
    {
        this.gameObject.GetComponentInChildren<Text>().text = "";
        dir = -1;
    }

    public void SetMessage(string msg)
    {
        letters = msg.ToCharArray();
        currentLetter = 0;
    }

    public void SetMessagesAndOpen(string[] msg)
    {
        openMessageBox();
        for(int i = 0; i < msg.Length; i++)
        {
            msgToDisplay.Add(msg[i]);
            letters = msg[i].ToCharArray();
            currentLetter = 0;
            while(currentLetter < letters.Length && goNextMsg == true)
            {
                //insert check to verify moving to the next message is okay.
            }
            GetComponentInChildren<Text>().text = "";
            goNextMsg = false;
        }
    }

}