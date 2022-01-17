using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 playerPos = new Vector2(2, 3);
        playerPos += new Vector2(8, 5);
        Debug.Log(playerPos);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
