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
        if (collision.gameObject.GetComponent<PowerUpSpawner>() != null)
        {
            // Make sure that the fire does not destroy the power up
            GetComponent<CircleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<PowerUpSpawner>().SpawnPowerUp();
        }
        // Don't destroy other fires
        else if (collision.gameObject.GetComponent<Fire>() != null)
        {
            return;
        }
        // If we have found a bomb, trigger it
        else if (collision.gameObject.GetComponent<Bomb>() != null)
        {
            collision.gameObject.GetComponent<Bomb>().Explode();
        }
        // If we have found a bomb, trigger it
        else if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().LoseLife();
            return;
        }
        // Remove the thing we collided with
        Destroy(collision.gameObject);
    }
}
