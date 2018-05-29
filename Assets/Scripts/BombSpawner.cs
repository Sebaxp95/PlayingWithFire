using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BombSpawner : NetworkBehaviour {

    public GameObject bomb;

    public int defaultFirePower = 2;
    public int defaulfNumberOfBombs = 1;
    [SyncVar]
    public int firePower = 2;
    [SyncVar]
    public int numberOfBombs = 1;
    [SyncVar]
    public int fuse = 2;

    public void SetDefaultValues()
    {
        firePower = defaultFirePower;
        numberOfBombs = defaulfNumberOfBombs;
    }

    void Update () {

        if (!isLocalPlayer)
        {
            return;
        }

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
        NetworkServer.Spawn(newBomb);
        numberOfBombs--;
        Invoke("AddBomb", fuse);
    }

    public void AddBomb()
    {
        numberOfBombs++;
    }
}
