using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameState : MonoBehaviour
{

    private bool hasTorch = false;
    private bool leftRoomFirstTime = true;
    private bool rightRoomFirstTime = true;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool playerHasTorch()
    {
        return hasTorch;
    }

    public void setTorch(bool val)
    {
        this.hasTorch = val;
    }

    public bool getLeftRoomFirstTime()
    {
        return leftRoomFirstTime;
    }

    public void setLeftRoom(bool value)
    {
        this.leftRoomFirstTime = value;
    }

    public bool getReftRoomFirstTime()
    {
        return rightRoomFirstTime;
    }

    public void setRightRoom(bool val)
    {
        this.rightRoomFirstTime = val;
    }
}
