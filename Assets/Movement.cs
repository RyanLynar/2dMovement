using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {
    private float speedMult =50;
    
    Vector2 speed;
    Vector2 accel;
    GameObject tempP;
    bool isPlayer,vertAction, horizAction;
	// Use this for initialization
	void Start () {
        speed = GetComponent<Rigidbody2D>().velocity;
        tempP = GameObject.FindGameObjectsWithTag("Player")[0];
        isPlayer = tag.Equals("Player");
    }

    // Update is called once per frame
    void Update () {
        accel = new Vector3(0, 0, 0);
        if (isPlayer)
        {
            keyReleased();

            HorizMove();

            VertMove();
        }
        else
        {
               Vector3 direction = new Vector3(tempP.transform.position.x - gameObject.transform.position.x, tempP.transform.position.y - gameObject.transform.position.y, 0).normalized;
               accel =new Vector2(1.5f*direction.x,1.5f*direction.y);

            if (Mathf.Abs(accel.y) > Mathf.Abs(direction.y))
               {
                   vertAction = true;
               }
            else
               {
                   vertAction = false;                }
            
            if (Mathf.Abs(accel.x) > Mathf.Abs( direction.x))
               {
                   horizAction = true;
               }
            else
               {
                   horizAction = false;
               }
            print("vert " + vertAction + " hori " + horizAction);
        }
        speed = speed + accel;
        if (!horizAction)
        {
            print("speedx to 0");
            speed.x = Mathf.Lerp(speed.x, 0, Time.deltaTime * 10000);
        }
        if (!vertAction)
        {
            if (!isPlayer)
                print("speedy to 0");
            speed.y = Mathf.Lerp(speed.y, 0, Time.deltaTime * 10000);
        }

        GetComponent<Rigidbody2D>().velocity = speed;
       }   
    void OnCollisionEnter2D(Collision2D coll)
    {
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
