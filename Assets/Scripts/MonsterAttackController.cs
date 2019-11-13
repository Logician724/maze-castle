using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackController : MonoBehaviour
{
    public Transform player;
    public Transform zombie1;
    public Transform zombie2;
    public Transform deathArea;

    Animator playerAnimator;
    Animator zombie1Animator;
    Animator zombie2Animator;

    int phase = 0;
    float speed = 0.015f;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        zombie1Animator = zombie1.GetComponent<Animator>();
        zombie2Animator = zombie2.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 0)
        {
            var heading = deathArea.transform.position - player.transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;

            player.transform.rotation = Quaternion.LookRotation(direction);
            if (distance < 0.5)
            {
                playerAnimator.SetTrigger("Idle");
                zombie1Animator.SetTrigger("WalksToPlayer");
                zombie2Animator.SetTrigger("WalksToPlayer");

                phase++;
            }
        }

        if (phase == 1)
        {
            var heading = player.transform.position - zombie1.transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;

            zombie1.transform.rotation = Quaternion.LookRotation(direction);

            var heading2 = player.transform.position - zombie2.transform.position;
            var distance2 = heading2.magnitude;
            var direction2 = heading2 / distance2;

            zombie2.transform.rotation = Quaternion.LookRotation(direction2);

            if (distance < 2 && distance2 < 2)
            {
                playerAnimator.SetTrigger("GetsHit");
                zombie1Animator.SetTrigger("AttacksPlayer");
                zombie2Animator.SetTrigger("AttacksPlayer");

                phase++;
            }
        }

        if (phase == 2 && playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 3)
        {
            playerAnimator.SetTrigger("Dies");
            zombie1Animator.SetTrigger("Idle");
            zombie2Animator.SetTrigger("Idle");

            phase++;
        }
    }
}
