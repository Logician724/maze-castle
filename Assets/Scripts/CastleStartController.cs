using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleStartController : MonoBehaviour
{

    public Animator rightDoorAnimator;
    public Animator leftDoorAnimator;
    public Animator playerAnimator;

    // if the right door is not chosen, the left door is by default
    private bool isRightDoorChosen = false;
    private bool isTurnMade = false;
    private bool isDoorOpened = false;
    // Start is called before the first frame update
    void Start()
    {

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
                    }

                }
                else
                {
                    if (IsDoorCloseby(playerAnimator.gameObject, leftDoorAnimator.gameObject))
                    {
                        isDoorOpened = true;
                        leftDoorAnimator.SetBool("isDoorOpen", true);
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
    }

    public void MoveLeft()
    {
        playerAnimator.SetTrigger("walk");
    }

    public void GoToTorchRoom()
    {
        
    }


}
