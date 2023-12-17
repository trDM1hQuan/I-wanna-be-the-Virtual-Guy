using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int fruits = 0;
    [SerializeField] private Text fruitsText;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void CollectFruit()
    {
        fruits++;
        fruitsText.text = "Fruits: " + fruits;
    }
}
