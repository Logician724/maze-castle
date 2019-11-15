using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSceneController : MonoBehaviour
{
    public Transform chest;
    public Transform shinyCoin;

    private int coinCount = 300;

    // Update is called once per frame
    void Update()
    {
        if (coinCount > 0)
        {
            Vector2 positon = Random.insideUnitCircle * 2;
            Instantiate(shinyCoin, new Vector3(chest.position.x + positon.x - 2.5f, 0, chest.position.z + positon.y - 3f), Quaternion.identity);

            coinCount--;
        }
    }
}
