using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : NetworkBehaviour {

    public float defaultSpeed = 5;
    public float speed;

    private Rigidbody2D rb2d;
    [SerializeField]
    private int numberOfLives = 3;

    [SerializeField]
    private float invulnerabilityDuration = 2;

    private bool isInvulnerable = false;

    [SerializeField]
    private GameObject heart;

    private List<GameObject> lifeImages;

    public void LoseLife()
    {
        if (!this.isInvulnerable && isLocalPlayer)
        {
            this.numberOfLives--;
            GameObject lifeImage = this.lifeImages[this.lifeImages.Count - 1];
            Destroy(lifeImage);
            this.lifeImages.RemoveAt(this.lifeImages.Count - 1);
            if (this.numberOfLives == 0)
            {
                GameObject.Find("Text").GetComponent<Text>().enabled = true;
                CmdDestroyObject(this.gameObject);
                Destroy(this.gameObject);
            }
            this.isInvulnerable = true;
            Invoke("BecomeVulnerable", this.invulnerabilityDuration);
            this.GetComponent<BombSpawner>().SetDefaultValues();
            speed = defaultSpeed;
        }

    }

    [Command]
    private void CmdDestroyObject(GameObject o)
    {
        NetworkServer.Destroy(o);
}

    private void BecomeVulnerable()
    {
        this.isInvulnerable = false;
    }

    public void AddLife()
    {
        if (isLocalPlayer)
        {
            numberOfLives++;
            GameObject playerLivesGrid = GameObject.Find("Lives");
            GameObject lifeImage = Instantiate(heart, playerLivesGrid.transform) as GameObject;
            this.lifeImages.Add(lifeImage);
        }
    }

    // Use this for initialization
    void Start () {
        if (!isLocalPlayer)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            return;
        }
    
        NetworkManagerHUD hud = GameObject.Find("GameController").GetComponent<NetworkManagerHUD>();
        if (hud != null)
            hud.showGUI = false;
        speed = defaultSpeed;
        rb2d = GetComponent<Rigidbody2D>();
        GameObject.Find("GameController").GetComponent<GameController>().SetLevel();
        GameObject playerLivesGrid = GameObject.Find("Lives");

        this.lifeImages = new List<GameObject>();
        for (int lifeIndex = 0; lifeIndex < this.numberOfLives; ++lifeIndex)
        {
            GameObject lifeImage = Instantiate(heart, playerLivesGrid.transform) as GameObject;
            this.lifeImages.Add(lifeImage);
        }
    }

    // Update is called once per frame
    void Update () {

        if(!isLocalPlayer)
        {
            return;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Prevent diagonal movement
        if (Mathf.Abs(x) >= Mathf.Abs(y))
            y = 0;
        else if (Mathf.Abs(x) <= Mathf.Abs(y))
            x = 0;
        
        // Calculate movement
        Vector2 movement = new Vector2(x, y) * speed;

        // Set movement 
        rb2d.velocity = movement;
    }
}
