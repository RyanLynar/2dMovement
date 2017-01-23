using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            coll.transform.localPosition = new Vector3(-10, 0, 1);
        }
        if(coll.gameObject.tag == "enemy")
        {
            coll.transform.localPosition = new Vector3(10, 0, 1);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
    }
}
