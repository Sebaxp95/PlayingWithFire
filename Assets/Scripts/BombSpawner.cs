using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {

    public GameObject bomb;

    public int firePower = 1;
    public int numberOfBombs = 1;
    public int fuse = 2;
	
	void Update () {

        //TODO: make sure we have moved more than 0.5 unit before we can drop another bomb
        //TODO: refactor code

		if(Input.GetButtonDown("Jump") && numberOfBombs >= 1)
        {
            Vector2 spawnPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
            var newBomb = Instantiate(bomb, spawnPos, Quaternion.identity) as GameObject;
            newBomb.GetComponent<Bomb>().firePower = firePower;
            newBomb.GetComponent<Bomb>().fuse = fuse;
            numberOfBombs--;
            Invoke("AddBomb", fuse);
        }
	}

    public void AddBomb()
    {
        numberOfBombs++;
    }
}
