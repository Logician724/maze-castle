using UnityEngine;
using UnityEngine.UI;

public class TorchSceneController : MonoBehaviour
{

    public GameObject player;
    public GameObject torch;
    public GameObject door;
    public GameObject canvas;

    public Text text;

    private Animator playerAnimator;
    private PlayerWithTorch playerScript;

    private string sceneState = "pickUpTorch";
    private bool isTorchPickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        playerAnimator = player.GetComponent<Animator>();
        playerScript = player.GetComponent<PlayerWithTorch>();

        text.text = GameState.rightRoomFirstTime ? "You found a torch, and a door lies ahead of you, " +
            "but you can smell a filthy stench. Do you wanna find out its source?" : "Oh, you are back again. Still curious about that stench?";
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
                }
                break;
            case "walkToDoor":
                playerAnimator.SetTrigger("walkToDoor");
                sceneState = "walkingToDoor";
                break;
            case "walkingToDoor":
                if (Vector2.Distance(player.transform.position, door.transform.position) <= 6.5)
                {
                    door.GetComponent<Animator>().SetBool("isDoorOpen", true);
                    sceneState = "final";
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



    public void GoRight()
    {
        Debug.Log("Clicked" + sceneState);
        sceneState = "walkToDoor";
        GameState.rightRoomFirstTime = false;
    }

    public void GoBack()
    {
        GameState.rightRoomFirstTime = false;
    }

}
