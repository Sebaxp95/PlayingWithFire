using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour {

    public GameObject levelHolder;
    public const int X = 23;
    public const int Y = 13;
    public GameObject[,] level = new GameObject[X, Y];

	// Use this for initialization
	void Start () {

        var objects = levelHolder.GetComponentsInChildren<Transform>();

        foreach (var child in objects)
        {
           
            level[(int)child.position.x, (int)child.position.y] = child.gameObject;
            
        }

        level[0, 0] = null;
	}
	

}
