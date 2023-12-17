using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggle : MonoBehaviour
{
    public Dialogue dialougeScript;
    private bool playerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = true;
            //dialougeScript.ToggleIndicator(playerDetected);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDetected = false;
           // dialougeScript.ToggleIndicator(playerDetected);
        }
    }
    private void Update()
    {
      if(playerDetected&&Input.GetKeyDown(KeyCode.E)) { 
            dialougeScript.StartDialogue();
        }  
    }
}
