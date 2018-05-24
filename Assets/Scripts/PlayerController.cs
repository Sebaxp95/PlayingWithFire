using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public float speed;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        if(!isLocalPlayer)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(!isLocalPlayer)
        {
            return;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Prevent diagonal movement
        if (Mathf.Abs(x) >= Mathf.Abs(y))
            y = 0;
        else if (Mathf.Abs(x) <= Mathf.Abs(y))
            x = 0;
        
        // Calculate movement
        Vector2 movement = new Vector2(x, y) * speed;

        // Set movement 
        rb2d.velocity = movement;
    }
}
