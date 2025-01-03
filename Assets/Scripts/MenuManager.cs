using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public virtual void Play()
    {
        SceneManager.LoadScene(1);
    }

    public virtual void Quit()
    {
        Application.Quit();
    }
}
