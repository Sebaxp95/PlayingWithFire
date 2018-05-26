using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
    public GameObject[] powerUps;
    public static int[] maxNumberOfPowerUps = { 5, 5, 5, 5, 2};
    static float randNumber = 0.3f;

    public void SpawnPowerUp()
    {
        if(Random.Range(0f, 1f) < randNumber)
        {
            int randomIndex = Random.Range(0, powerUps.Length);
            if(maxNumberOfPowerUps[randomIndex] > 0)
            {
                randNumber += 0.02f;
                Instantiate(powerUps[randomIndex], transform.position, Quaternion.identity);
                maxNumberOfPowerUps[randomIndex]--;
            }

        }
    }
}