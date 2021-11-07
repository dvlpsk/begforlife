using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodgefire : MonoBehaviour
{
    public GameObject fire;
    public float spawn_time;
    private float fireball_spawn_time;
    public float min_spawn_time;
    private GameObject shooted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn_time>min_spawn_time)
        spawn_time -= Time.deltaTime / 60;
        fireball_spawn_time -= Time.deltaTime;
        if (fireball_spawn_time <= 0)
        {
            fireball_spawn_time = 0.1f;
            shooted = Instantiate(fire, new Vector3(-10f,Random.Range(-5,5),0), Quaternion.identity);
            shooted.GetComponent<Rigidbody2D>().AddForce(new Vector2 (10,0), ForceMode2D.Impulse);
        }
    }
}
