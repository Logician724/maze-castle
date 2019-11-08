using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("CastleScene", LoadSceneMode.Single);
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScene", LoadSceneMode.Single);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
