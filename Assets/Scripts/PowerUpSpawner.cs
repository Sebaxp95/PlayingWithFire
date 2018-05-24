using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
    public GameObject[] powerUps;
    //public int numberOfFirePowerUps;

    public void SpawnPowerUp()
    {
        //TODO: keep track of spawned powerups

        if(Random.Range(0f, 1f) > 0.5)
        {
            int randomIndex = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomIndex], transform.position, Quaternion.identity);
        }
    }
}