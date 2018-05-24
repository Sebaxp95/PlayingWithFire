using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BombSpawner : NetworkBehaviour {

    public GameObject bomb;

    public int firePower = 1;
    public int numberOfBombs = 1;
    public int fuse = 2;
	
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }

        //TODO: make sure we have moved more than 0.5 unit before we can drop another bomb
        //TODO: refactor code

        if (Input.GetButtonDown("Jump") && numberOfBombs >= 1)
        {
            CmdSpawnBomb();
        }
    }

    [Command]
    private void CmdSpawnBomb()
    {
        Vector2 spawnPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        var newBomb = Instantiate(bomb, spawnPos, Quaternion.identity) as GameObject;
        newBomb.GetComponent<Bomb>().firePower = firePower;
        newBomb.GetComponent<Bomb>().fuse = fuse;
        numberOfBombs--;
        NetworkServer.Spawn(newBomb);
        Invoke("AddBomb", fuse);
    }

    public void AddBomb()
    {
        numberOfBombs++;
    }
}
