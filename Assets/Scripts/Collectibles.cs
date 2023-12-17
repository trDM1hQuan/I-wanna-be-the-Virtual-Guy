using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    private int fruits = 0;
    [SerializeField] private Text fruitsText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameManager gm = collision.GetComponent<GameManager>();
        if (collision.gameObject.CompareTag("Fruits"))
        {

            fruits++;
            fruitsText.text = "Fruits: " + fruits;
        }
    }
}

