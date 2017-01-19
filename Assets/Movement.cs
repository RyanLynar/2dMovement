using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {
    public float speedMult;
    Vector2 speed;
    Vector2 accel;
    bool vertAction, horizAction;
	// Use this for initialization
	void Start () {
        speed = GetComponent<Rigidbody2D>().velocity;
        
    }

    // Update is called once per frame
    void Update () {
        keyReleased();
        accel = new Vector3(0, 0, 0);
        
        HorizMove();
        
        VertMove();

        speed = speed + accel;
        if (!horizAction)
        {
            speed.x = Mathf.Lerp(speed.x, 0, Time.deltaTime * 10000);
        }
        if (!vertAction)
        {
            speed.y = Mathf.Lerp(speed.y, 0, Time.deltaTime * 10000);
        }
        GetComponent<Rigidbody2D>().velocity = speed;
    }   
    void OnCollisionEnter2D(Collision2D coll)
    {
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (gameObject.tag =="Player")
        {
            gameObject.transform.localPosition = new Vector3(0, 0, 1);
        }
    }
    public void keyReleased()
    {
        if(Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            horizAction = false;
        }
        if (Input.GetKeyUp("s")|| Input.GetKeyUp("w"))
        {
            vertAction = false;
        }
    }
    public void HorizMove() {
        if (Input.GetKey("a"))
        {
            horizAction = true;
            if (speed.x >= speedMult*-1)
            {
                accel.x -= speedMult * 0.25f;
            }
            else { accel.x = 0; }
        }
        else if (Input.GetKey("d"))
        {
            horizAction = true;
            if (speed.x <= speedMult * 1)
            {
                accel.x += speedMult * 0.25f;
            }
            else { accel.x = 0; }
        }
    }
    public void VertMove() {

        if (Input.GetKey("s"))
        {
            vertAction = true;
            if (speed.y >= speedMult * -1)
            {
                accel.y -= speedMult * 0.25f;
            }
            else { accel.y = 0; }
        }
        else if (Input.GetKey("w"))
        {
            vertAction = true; 
            if (speed.y <= speedMult * 1)
            {
                accel.y += speedMult * 0.25f;
            }
            else { accel.y = 0; }
        }
    }
}
