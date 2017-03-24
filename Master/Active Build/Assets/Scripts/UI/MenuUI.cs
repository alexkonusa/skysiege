using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public string playSceneName;
    public string creditsSceneName;

    public void PlayButton()
    {

        SceneManager.LoadScene(playSceneName);

    }

    public void CreditsButton()
    {

        SceneManager.LoadScene(creditsSceneName);

    }

    public void CloseApplication()
    {

        Application.Quit();

    }

}
