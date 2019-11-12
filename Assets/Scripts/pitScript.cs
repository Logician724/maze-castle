using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitScript : MonoBehaviour
{
    private Animator anim;
    private AudioSource src;
    private bool isFalling = false;
    private bool soundTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] tmp = anim.GetCurrentAnimatorClipInfo(0);

        if (tmp[0].clip.name.Equals("walking"))
        {
            if (this.gameObject.transform.position.z >= -16)
            {
                anim.SetBool("AtPit", true);
                isFalling = true;
            }
        } else if(isFalling && tmp[0].clip.name.Equals("plFalling"))
        {
            anim.applyRootMotion = false;
            if (!soundTriggered)
            {
                soundTriggered = true;
                src.PlayOneShot(src.clip);
            }

            if(src.time == 4)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
