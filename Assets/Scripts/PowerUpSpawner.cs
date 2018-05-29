using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PowerUpSpawner : NetworkBehaviour {
    public GameObject[] powerUps;
    public static int[] maxNumberOfPowerUps = { 5, 5, 5, 5, 2};
    static float randNumber = 0.4f;
    public float additionalBonus;
    PowerUpController powerUpController;

    public void SpawnPowerUp()
    {
        if (!isServer)
        {
            return;
        }
        if (Random.Range(0f, 1f) < randNumber + additionalBonus)
        {
            powerUpController = FindObjectOfType<PowerUpController>();
            int randomIndex = Random.Range(0, powerUps.Length);
            if(maxNumberOfPowerUps[randomIndex] > 0)
            {
                randNumber += 0.02f;
                powerUpController.CmdSpawnPowerUp(transform.position, powerUps[randomIndex]);
                maxNumberOfPowerUps[randomIndex]--;
            }

        }
    }
}