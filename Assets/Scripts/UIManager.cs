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
        float value = playerInput.GetSettingButton();
        if (value == 1f)
        {
            Transform settingsTransform = GameUI.transform.Find("Settings"); ;
            GameObject settingsObject = settingsTransform.gameObject;
            settingsObject.SetActive(true);
        }
    }
}
