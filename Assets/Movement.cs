using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
    Vector3 speed;
    Vector3 accel;
	// Use this for initialization
	void Start () {
        speed = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        accel = new Vector3(0, 0, 0);
        //Collision Check

       if (checkCollision(gameObject)) {
            speed = Vector3.zero;
       }

        accel = slowDown(accel, speed);
        //Accleration
        if (Input.GetKey("a"))
        {
            if(speed.x >= -1) {
                accel.x -= 0.25f;
            }else { accel.x = 0; }
        }
        else if(Input.GetKey("d")){
            if (speed.x <= 1)
            {
                accel.x += 0.25f;
            }
            else { accel.x = 0; }
        }
        //Vert Movement
        if (Input.GetKey("s"))
        {
            if (speed.y >= -1)
            {
                accel.y -= 0.25f;
            }
            else { accel.y = -0; }
        }
        else if (Input.GetKey("w"))
        {
            if (speed.y <= 1)
            {
                accel.y+= 0.25f;
            }
            else { accel.y = 0; }
        }
        speed = speed + accel;
        if (speed.x > 0.1 || speed.x < -0.1) 
                    speed.x = 0;
        transform.Translate(speed);

    }
    public Vector3 slowDown(Vector3 accel, Vector3 speed)
    {
        //Accel Decay
        
        //Horizontal
        if (speed.x > 0) {
            accel.x -= 0.05f;
            if (speed.x - accel.x < 0)
                speed.x = 0;
        }
        else if (speed.x < 0) {
            accel.x += 0.05f;
            if (speed.x - accel.x > 0)
                speed.x = 0;
        }

        //Vert
        if (speed.y > 0) {
            accel.y -= 0.05f;
            if (speed.y - accel.y > 0)
                speed.y = 0;
        }
        else if (speed.y < 0) {
            accel.y += 0.05f;
        }
        
        return accel;
    }
    public bool checkCollision(GameObject mover)
    {
        GameObject wall = GameObject.Find("Wall1");
        if (wall.GetComponent<Collider2D>().IsTouching(mover.GetComponent<Collider2D>()))
        {
            return true;
        }
        return false;
    }
}