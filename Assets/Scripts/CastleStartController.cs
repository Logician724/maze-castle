using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleStartController : MonoBehaviour
{

    public Animator rightDoorAnimator;
    public Animator leftDoorAnimator;
    public Animator playerAnimator;

    public GameObject torch1;
    public GameObject torch2;

    public Text text;
    public Text choice1;
    public Text choice2;

    public Button choice3;

    // if the right door is not chosen, the left door is by default
    private bool isRightDoorChosen = false;
    private bool isTurnMade = false;
    private bool isDoorOpened = false;



    // Start is called before the first frame update
    void Start()
    {
        if (GameState.firstOrLastRoom)
        {
            torch1.SetActive(true);
            torch2.SetActive(true);

            text.text = GameState.mainRoomFirstTime ? "You are exploring an old castle in look for " +
            "an old long-lost treasure. But now you are stuck in this room, and you have to tread carefully; " +
            "you do not know what awaits ahead." : "So, where do you wanna go now?";
            choice1.text = "Go Right";
            choice2.text = "Go Left";
        }
        else
        {
            if (GameState.hasTorch)
            {
                choice3.gameObject.SetActive(true);

                text.text = "Ah damn! Two doors again? " +
                    "You can feel a breeze coming from the left door. Could it be the way out?";
                choice1.text = "Hmm no..let's go right.";
                choice1.fontSize = 40;
                choice2.text = "Let's check it out. I am sick of this castle!";
                choice2.fontSize = 40;
            }
            else
            {
                text.text = "You can barely see anything. It is totally dark.";
                choice1.text = "Move forward. Hopefully, you will bump into a door.";
                choice1.fontSize = 40;
                choice2.text = "Turn back. Maybe try the other door.";
                choice2.fontSize = 40;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Both doors are aligned, so chose the left door for player alignment by default
        if (!isTurnMade)
        {
            if (Mathf.Abs(playerAnimator.transform.position.z - leftDoorAnimator.transform.position.z) <= 0.2)
            {

                playerAnimator.SetBool("isRight", isRightDoorChosen);
                playerAnimator.SetBool("isLeft", !isRightDoorChosen);
                isTurnMade = true;
            }
        }
        else
        {
            if (!isDoorOpened)
            {
                if (isRightDoorChosen)
                {
                    if (IsDoorCloseby(playerAnimator.gameObject, rightDoorAnimator.gameObject))
                    {
                        rightDoorAnimator.SetBool("isDoorOpen", true);
                        isDoorOpened = true;
                        Invoke("LeaveRightDoor", 1.5f);
                    }

                }
                else
                {
                    if (IsDoorCloseby(playerAnimator.gameObject, leftDoorAnimator.gameObject))
                    {
                        isDoorOpened = true;
                        leftDoorAnimator.SetBool("isDoorOpen", true);
                        Invoke("LeaveLeftDoor", 1.5f);
                    }
                }
            }

        }
    }



    private bool IsDoorCloseby(GameObject player, GameObject door)
    {
        return Vector2.Distance(player.transform.position, door.transform.position) <= 6.5;

    }

    public void MoveRight()
    {
        isRightDoorChosen = true;
        GameState.mainRoomFirstTime = false;
        playerAnimator.SetTrigger("walk");

    }

    public void MoveLeft()
    {
        GameState.mainRoomFirstTime = false;
        playerAnimator.SetTrigger("walk");
    }

    public void MoveBack()
    {
        GameState.firstOrLastRoom = true;
        SceneManager.LoadScene("CastleStartScene", LoadSceneMode.Single);
    }

    public void GoToTorchRoom()
    {
        SceneManager.LoadScene("TorchScene", LoadSceneMode.Single);
    }


    public void LeaveLeftDoor()
    {
        if (GameState.firstOrLastRoom)
        {
            GameState.firstOrLastRoom = false;
            SceneManager.LoadScene("CastleStartScene", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("PitScene", LoadSceneMode.Single);
        }

    }

    public void LeaveRightDoor()
    {

        if (GameState.firstOrLastRoom)
        {
            SceneManager.LoadScene("TorchScene", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("TreasureScene", LoadSceneMode.Single);
        }

    }

}
