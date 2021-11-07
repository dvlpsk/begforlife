using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject pickup_target;
    public GameObject progression_obj;
    private Transform ui_bar;
    public bool picking;
    public float speed;
    public float cur_hp;
    private float max_hp;
    public float cur_hunger;
    private float max_hunger;
    public enum mood_state {happy,angry,sad,anxity,annoying,stressedout,crazy };
    public mood_state emotion;
    public Transform progression_bar;
    Coroutine pickuper = null;
    float lerpTime;
    // Start is called before the first frame update
    #region ¡¹Enumerators
    IEnumerator PickingUp(float p_wait)
    {
        //FindObjectOfType<AudioManager>().Play("cocked");
        yield return new WaitForSeconds(p_wait);
        //  ReloadTime.GetComponent<Image>().color = Color.white;

        //weapon_bullet[weaponindex] = maxAmmo[weaponindex];
        if (pickup_target != null)
            Destroy(pickup_target);
        // FindObjectOfType<AudioManager>().Play("they shoot");
    }
    #endregion
    void Start()
    {
        cur_hunger = max_hunger;
        cur_hp = max_hp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-speed, 0, 0);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        this.transform.position+=new Vector3(speed,0,0);
        else if(Input.GetKey(KeyCode.UpArrow))
        this.transform.position+=new Vector3(0,speed,0);
        else if(Input.GetKey(KeyCode.DownArrow))
        this.transform.position+=new Vector3(0,-speed,0);

        if (Input.GetKey(KeyCode.Space))
            { 
        
        
        }


        cur_hunger -= Time.deltaTime*2;

    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag=="item"&& Input.GetKey(KeyCode.F))//pickup
        {
                pickup_target = coll.gameObject;
                pickuper = StartCoroutine(PickingUp(1));
                print("detected");
            lerpTime += Time.deltaTime / 0.5f;
            Vector3 pos_lerp = new Vector3(Mathf.Lerp(0, 1, lerpTime), 1, 1);
            progression_bar.localScale = pos_lerp;
            if (lerpTime >= 2f)
            {
                lerpTime = 0;
            }
        }
        else
        {
            StopCoroutine(pickuper);
        }
    }
}
