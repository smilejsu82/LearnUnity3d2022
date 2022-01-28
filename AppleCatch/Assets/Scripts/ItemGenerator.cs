using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float span = 1.0f;
    float delta = 0;
    float speed = 1.0f;
    int ratio = 2;
    
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);  //1 ~10
            if (dice <= this.ratio)
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            else {
                item = Instantiate(applePrefab) as GameObject;
            }
            //시작값인 0은 포함(inclusive)되고, 끝값은 제외(exclusive)된다.
            float x = Random.Range(-1, 2);  //-1 ~ 1 
            float z = Random.Range(-1, 2);  //-1 ~ 1 
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().speed = this.speed;
        }
    }


    public void SetParameters(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
}
