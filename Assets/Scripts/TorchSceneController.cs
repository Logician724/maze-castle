using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TorchSceneController : MonoBehaviour
{

    public GameObject player;
    public GameObject torch;
    public GameObject door;
    public GameObject canvas;

    public Text text;
    public Text choice1;
    public Text choice2;

    private Animator playerAnimator;
    private PlayerWithTorch playerScript;

    private string sceneState = "pickUpTorch";

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        playerAnimator = player.GetComponent<Animator>();
        playerScript = player.GetComponent<PlayerWithTorch>();

        text.text = "You found a torch, and a locked door lies on your left, " +
            "but you can smell a filthy stench from the right one. Do you wanna find out its source?";
        choice1.text = "Check the source of the stench.";
        choice2.text = "Turn back. It may be dangerous.";

        choice1.fontSize = 40;
        choice2.fontSize = 40;
    }

    // Update is called once per frame
    void Update()
    {
        switch (sceneState)
        {
            case "pickUpTorch":
                if (Mathf.Abs(player.transform.position.z - torch.transform.position.z) <= 0.3)
                {
                    playerAnimator.SetTrigger("pickUpTorch");
                    Invoke("AddTorchToPlayer", 1);
                    sceneState = "temp";
                    GameState.hasTorch = true;
                }
                break;
            case "walkToDoor":
                player.GetComponent<AudioSource>().pitch = 1.5f;
                playerAnimator.SetTrigger("walkToDoor");
                sceneState = "walkingToDoor";
                break;
            case "walkingToDoor":
                if (Vector2.Distance(player.transform.position, door.transform.position) <= 6.5)
                {
                    door.GetComponent<Animator>().SetBool("isDoorOpen", true);
                    sceneState = "final";
                    Invoke("GoToMonsterScene", 1.5f);
                }
                break;
            default: break;
        }
    }

    public void AddTorchToPlayer()
    {
        Destroy(torch);
        canvas.SetActive(true);
        GameState.hasTorch = true;
        playerScript.torch.SetActive(true);
    }

    public void GoToMonsterScene()
    {
        SceneManager.LoadScene("MonsterAttackScene", LoadSceneMode.Single);
    }

    public void GoRight()
    {
        sceneState = "walkToDoor";
    }

    public void GoBack()
    {
        GameState.isTorchRoom = false;
        GameState.isFirstRoom = true;
        SceneManager.LoadScene("CastleStartScene", LoadSceneMode.Single);
    }

}
