using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{

    GameController gc;
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        gc.level[(int)transform.position.x, (int)transform.position.y] = gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().speed++;
            Destroy(gameObject);
        }
    }
}
