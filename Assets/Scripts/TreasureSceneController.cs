using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureSceneController : MonoBehaviour
{
    public Transform player;
    public Transform chest;
    public Transform collectibles;
    public Transform shinyCoin;
    public Transform shinyDiamond;
    public Transform exit;

    public GameObject door;
    Animator playerAnimator;

    private int count = 300;

    private int phase = 0;

    private bool openedDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        GameState.goodGameOver = true;
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 3)
        {
            var heading = exit.transform.position - player.transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;

            player.transform.rotation = Quaternion.LookRotation(direction);

            if (distance < 0.5)
            {
                SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
            }
        }

        if (phase == 2 && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pick") && playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
        {
            Destroy(chest.gameObject);
            Destroy(collectibles.gameObject);
            playerAnimator.SetTrigger("Walk");

            phase++;
        }

        if (phase == 1)
        {
            var heading = chest.transform.position - player.transform.position;
            heading.x -= 2.5f; heading.z -= 2.5f;
            var distance = heading.magnitude;
            var direction = heading / distance;

            player.transform.rotation = Quaternion.LookRotation(direction);

            if (distance < 2)
            {
                playerAnimator.SetTrigger("Pick");

                phase++;
            }
        }

        if (count > 0 && phase == 0)
        {
            Vector2 positon = Random.insideUnitCircle * 2;

            Transform obj;
            if (count % 2 == 0)
                obj = Instantiate(shinyCoin, new Vector3(chest.position.x + positon.x - 2.5f, 0, chest.position.z + positon.y - 3f), Quaternion.identity);
            else
                obj = Instantiate(shinyDiamond, new Vector3(chest.position.x + positon.x - 2.5f, 0, chest.position.z + positon.y - 3f), Quaternion.identity);
            obj.SetParent(collectibles.transform);

            count--;

            if (count == 0)
            {
                playerAnimator.SetTrigger("Walk");

                phase++;
            }
        }
        if ( !openedDoor && Vector2.Distance(player.position, door.transform.position) <= 6.5)
        {
            door.GetComponent<Animator>().SetBool("isDoorOpen", true);
            openedDoor = true;
        }
    }


}
