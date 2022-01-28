using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    private AudioSource aud;
    private void Start()
    {
        this.aud = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red, 10f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                //collider와 충돌 한다면 
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                this.transform.position = new Vector3(x, 0, z);
            }
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("잡았다!");

        if (other.tag.Equals("Apple"))
        {
            Debug.Log("Apple");
            this.aud.PlayOneShot(this.appleSE);
        }
        else if (other.tag.Equals("Bomb"))
        {
            Debug.Log("Bomb");
            this.aud.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }
}
