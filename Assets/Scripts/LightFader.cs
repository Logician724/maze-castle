using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFader : MonoBehaviour
{
    private Torchelight torchelight;
    // Start is called before the first frame update
    void Start()
    {
        torchelight = GetComponent<Torchelight>();
        InvokeRepeating("FadeTorch", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void FadeTorch()
    {
        torchelight.IntensityLight --;
    }
}
