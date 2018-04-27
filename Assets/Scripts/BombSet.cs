using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSet : MonoBehaviour {

    public GameObject bomb;
    int maxNumberOfBombs = 1;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Jump") && maxNumberOfBombs >= 1)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            maxNumberOfBombs--;
            Invoke("AddBomb", 2);
        }
	}
    public void AddBomb()
    {
        maxNumberOfBombs++;
    }
}
