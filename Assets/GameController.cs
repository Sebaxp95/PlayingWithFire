using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;


public class GameController : NetworkBehaviour {

    public GameObject levelHolder;
    public const int X = 23;
    public const int Y = 13;
    public GameObject[,] level = new GameObject[X, Y];

	// Use this for initialization
	void Start () {
        Text text = GameObject.Find("Text").GetComponent<Text>();
        text.enabled = false;
        text.text = "Game over";

        var objects = levelHolder.GetComponentsInChildren<Transform>();

        foreach (var child in objects)
        {
            level[(int)child.position.x, (int)child.position.y] = child.gameObject;
        }

        level[0, 0] = null;
	}

    public void SetLevel()
    {
        var objects = levelHolder.GetComponentsInChildren<Transform>();

        foreach (var child in objects)
        {
            level[(int)child.position.x, (int)child.position.y] = child.gameObject;
        }

        level[0, 0] = null;
    }
	

}
