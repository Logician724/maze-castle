using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneController : MonoBehaviour
{
    public Text gameOver;

    private void Start()
    {
        if (GameState.goodGameOver)
        {
            gameOver.text = "You won!";
        }
    }

    public void RestartButton()
    {
        GameState.reset();
        SceneManager.LoadScene("CastleStartScene", LoadSceneMode.Single);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
}
