using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CreateWrestlers : MonoBehaviour {
    public GameObject Sumo;
	// Use this for initialization
	void Start () {
        initPlayer();
        initEnemy();}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void initPlayer()
    {

        GameObject player = Instantiate(Sumo, Vector3.zero, Quaternion.identity);
        player.tag = "Player";
        SpriteRenderer pr = player.GetComponent<SpriteRenderer>();
        player.AddComponent<Rigidbody2D>();
        Texture2D temp = new Texture2D(1, 1);
        temp.LoadImage(System.IO.File.ReadAllBytes("Assets/Resources/Wall.png"));
        pr.sprite = Sprite.Create(temp, new Rect(0, 0, 10, 10), new Vector2(1, 1));
        player.transform.localPosition = new Vector3(-10, 0, 1);
        player.transform.localScale = new Vector3(50, 50, 1);
        player.AddComponent<PolygonCollider2D>();
        pr.sortingOrder = 1;
        
    }
    private void initEnemy()
    {
        GameObject enemy = Instantiate(Sumo, Vector3.zero, Quaternion.identity);
        enemy.tag = "enemy";
        SpriteRenderer er = enemy.GetComponent<SpriteRenderer>();
        Texture2D temp = new Texture2D(1, 1);
        temp.LoadImage(System.IO.File.ReadAllBytes("Assets/Resources/Triangle.png"));
        er.sprite = Sprite.Create(temp, new Rect(0, 0, 10, 10), new Vector2(1, 1));
        enemy.transform.localPosition =(new Vector3(10, 0, 1));
        enemy.transform.localScale = new Vector3(50, 50, 1);
        enemy.AddComponent<Rigidbody2D>();
        enemy.AddComponent<PolygonCollider2D>();
        er.sortingOrder = 1;
    }
}
