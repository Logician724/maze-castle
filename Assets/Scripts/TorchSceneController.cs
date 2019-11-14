using UnityEngine;

public class TorchSceneController : MonoBehaviour
{

    public GameObject player;
    public GameObject torch;
    public GameObject door;
    private Animator playerAnimator;
    private PlayerWithTorch playerScript;

    private string sceneState = "idle";
    private bool isTorchPickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        playerScript = player.GetComponent<PlayerWithTorch>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sceneState)
        {
            case "walkToTorch":
                playerAnimator.SetTrigger("walkToTorch");
                sceneState = "pickUpTorch";
                break;
            case "pickUpTorch":
                if (Mathf.Abs(player.transform.position.z - torch.transform.position.z) <= 0.1)
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
        playerScript.torch.SetActive(true);
        sceneState = "walkToDoor";
    }



    public void PickUpTorch()
    {
        sceneState = "walkToTorch";
    }

    public void GoBack()
    {
        
    }

}
