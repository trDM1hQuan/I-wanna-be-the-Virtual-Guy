using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Button settingButton;

    private void Start()
    {
        settingButton.onClick.AddListener(OpenSettingScene);
    }

    private void OpenSettingScene()
    {
        SceneManager.LoadScene("Setting Screen");
    }
}
