using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("CastleScene", LoadSceneMode.Single);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
}
