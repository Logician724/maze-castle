using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWithTorch : MonoBehaviour
{

    public GameObject torch;
    // Start is called before the first frame update
    void Start()
    {
        torch.SetActive(false);
    }

    // Update is called once per frames
}
