using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Vector2 playerPos = new Vector2(2, 3);
        //playerPos += new Vector2(8, 5);
        //Debug.Log(playerPos);

        Vector2 playerPos = new Vector2(2, 3);
        Vector2 monsterPos = new Vector2(5, 8);

        var dir = monsterPos - playerPos;
        var distance = dir.magnitude;
        Debug.Log(distance);

        //���� 
        //float distance = Vector2.Distance(playerPos, monsterPos);
        //Debug.Log(distance);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
