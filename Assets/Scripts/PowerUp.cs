using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerUp : NetworkBehaviour
{
    public int bombs;
    public int firePower;
    public float speed;
    public bool addLife;
    public bool lostLife;

    GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.level[(int)transform.position.x, (int)transform.position.y] = gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // See if we have collided with the player
        if (collision.gameObject.tag == "Player")
        {
            // Gather references to components
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            BombSpawner BombSpawner = collision.gameObject.GetComponent<BombSpawner>();

            // Adjust the values
            playerController.speed += speed;
            if (addLife) playerController.AddLife();
            if (lostLife) playerController.LoseLife(); 
            BombSpawner.numberOfBombs += bombs;
            BombSpawner.firePower += firePower;

            // Remove the powerup
            Destroy(gameObject);
        }
    }
}
