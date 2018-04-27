using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public int firePower;
    public int timeToExplode;

	// Use this for initialization
	void Start () {
        Invoke("Explode", timeToExplode);
	}

    void Explode()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
