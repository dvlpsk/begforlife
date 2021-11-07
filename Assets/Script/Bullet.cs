using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject death_par;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hi)
    {
        if (hi.gameObject.tag == "Player")
        {
            Instantiate(death_par, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
