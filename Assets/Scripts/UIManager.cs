using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject GameUI;


    void Update()
    {
        OpenSettingUI();
    }

    private void OpenSettingUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Transform settingsTransform = GameUI.transform.Find("Settings"); ;
            GameObject settingsObject = settingsTransform.gameObject;
            GameManager.instance.PauseGame(!GameManager.instance.isPaused);
            settingsObject.SetActive(!settingsObject.activeSelf);
        }
    }
}
