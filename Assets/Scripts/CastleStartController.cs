using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleStartController : MonoBehaviour
{

    public Animator rightDoorAnimator;
    public Animator leftDoorAnimator;
    public Animator playerAnimator;

    public Text text;

    // if the right door is not chosen, the left door is by default
    private bool isRightDoorChosen = false;
    private bool isTurnMade = false;
    private bool isDoorOpened = false;



    // Start is called before the first frame update
    void Start()
    {
        if (text)
        {
            text.text = GameState.mainRoomFirstTime ? "You are exploring an old castle in look for " +
            "an old long-lost treasure. But now you are stuck in this room, and you have to tread carefully; " +
            "you do not know what awaits ahead." : "So, where do you wanna go now?";
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

                Debug.Log(playerAnimator.transform.position.z);
                Debug.Log(leftDoorAnimator.transform.position.z);
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
                        Invoke("LeaveRightDoor", 1);
                    }

                }
                else
                {
                    if (IsDoorCloseby(playerAnimator.gameObject, leftDoorAnimator.gameObject))
                    {
                        isDoorOpened = true;
                        leftDoorAnimator.SetBool("isDoorOpen", true);
                        Invoke("LeaveLeftDoor", 1);
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
        playerAnimator.SetTrigger("walk");
        GameState.mainRoomFirstTime = false;
    }

    public void MoveLeft()
    {
        playerAnimator.SetTrigger("walk");
        GameState.mainRoomFirstTime = false;
    }

    public void GoToTorchRoom()
    {
        SceneManager.LoadScene("TorchScene", LoadSceneMode.Single);
    }


    public void LeaveLeftDoor()
    {
        if (GameState.firstOrLastRoom)
        {
            SceneManager.LoadScene("DarkScene", LoadSceneMode.Single);
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
