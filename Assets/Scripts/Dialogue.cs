using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    // Fields
    // Window
    public GameObject window;
    // Text components
    public TMP_Text dialogueText;
    // Dialogue list
    public List<string> dialogue;
    // Writing speed
    public float writingSpeed =2f;
    // Index on dialogue
    private int index;
    // Start boolean
    private bool started;

    private void Awake()
    {
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    // Start dialogue
    public void StartDialogue()
    {
        if (started)
        {
            return;
        }
        // Show the window
        ToggleWindow(true);
        // Start with the first dialogue
        index = 0;
        StartCoroutine(DisplayDialogues());
    }

    IEnumerator DisplayDialogues()
    {
        foreach (string sentence in dialogue)
        {
            dialogueText.text = sentence;
            yield return new WaitForSeconds(writingSpeed);
        }

        yield return new WaitForSeconds(10f); // Wait for 2 seconds before closing the dialogue

        // End dialogue
        ToggleWindow(false);
    }
}
