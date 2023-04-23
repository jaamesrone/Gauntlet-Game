using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneTransition : MonoBehaviour
{
    public void GoToControls()
    {
        SceneManager.LoadScene(1);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
