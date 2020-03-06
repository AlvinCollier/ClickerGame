using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayerController : MonoBehaviour
{
    public float moveSpeed;

    bool moveVert, moveHori;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //up and down movement
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("IsWalking", true);
            moveVert = true;

        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("IsWalking", true);
            moveVert = true;
        }
        //left and right movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("IsWalking", true);
            moveHori = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("IsWalking", true);
            moveHori = true;
        }

        if (Input.GetKey(KeyCode.DownArrow ) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.W) == false)
        {
            moveVert = false;

        }

        if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.D) == false)
        {

            moveHori = false;
        }


        if ( !moveHori && !moveVert)
        {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }
    }
}
