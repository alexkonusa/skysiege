using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public string playSceneName;
    public string creditsSceneName;
    public AudioClip audioSource;

    SoundManager soundManager;

    private void Start()
    {
        soundManager = GetComponent<SoundManager>();
    }

    public void PlayButton()
    {

        soundManager.PlaySound(audioSource);
        SceneManager.LoadScene(playSceneName);

    }

    public void CreditsButton()
    {

        soundManager.PlaySound(audioSource);
        SceneManager.LoadScene(creditsSceneName);

    }

    public void CloseApplication()
    {

        soundManager.PlaySound(audioSource);
        Application.Quit();

    }

}
