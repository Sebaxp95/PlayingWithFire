using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	void Start () {
        // Remove fire after specified time
        Destroy(gameObject, 0.3f);
	}

    void Update()
    {
        // Rotate effect
        transform.Rotate(0, 0, -45);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // If we have found a bomb trigger it
        if (collision.gameObject.GetComponent<Bomb>() != null)
        {
            collision.gameObject.GetComponent<Bomb>().Explode();
        }

        // Don't destroy other fires, destroy everything else
        if (collision.gameObject.GetComponent<Fire>() == null)
        {
            Destroy(collision.gameObject);
        }
    }
}
