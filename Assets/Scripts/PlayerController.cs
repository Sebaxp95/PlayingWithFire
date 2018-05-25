using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

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
        if (!this.isInvulnerable)
        {
            this.numberOfLives--;
            GameObject lifeImage = this.lifeImages[this.lifeImages.Count - 1];
            Destroy(lifeImage);
            this.lifeImages.RemoveAt(this.lifeImages.Count - 1);
            if (this.numberOfLives == 0)
            {
                Destroy(this.gameObject);
            }
            this.isInvulnerable = true;
            Invoke("BecomeVulnerable", this.invulnerabilityDuration);
        }
    }

    private void BecomeVulnerable()
    {
        this.isInvulnerable = false;
    }

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        if(!isLocalPlayer)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
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
