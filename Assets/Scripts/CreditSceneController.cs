﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneController : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            BackButton();
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
}
