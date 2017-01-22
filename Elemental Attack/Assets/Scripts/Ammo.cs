using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {
    
    [Header("Speeds are to determine which direction it travels")]
    [Header("ammoSpeed is the one used for velocity,")]
    [Header("and will be left or right")]
    public float speedRight;
    public float speedLeft;
    public float ammoSpeed;
    private Rigidbody theRB;
    bool fired;

    float time = 0;


    void Start () {
        theRB = GetComponent<Rigidbody>();
	}

    void Update()
    {
        //Gets the PlayerMovement scripts from the player objects
        PlayerMovement player1 = GameObject.Find("Player 1").GetComponent<PlayerMovement>();
        PlayerMovement player2 = GameObject.Find("Player 2").GetComponent<PlayerMovement>();
        //Counts time since creation of the ammo
        time += Time.deltaTime;
        
        //If the bullet is fired by player 1
        if (gameObject.name == "Ammo(Clone)") {
            //If the player is facing right
            if (player1.FacingRight == true && !fired) {
                //The ammo is set to fire right
                ammoSpeed = speedRight;
                fired = true;
            //else the ammo is set to fire left
            } else if (player1.FacingLeft == true && !fired) {
                ammoSpeed = speedLeft;
                fired = true;
            }
        }
        //The above, but for player 2
        if (gameObject.name == "Ammo 1(Clone)") {
            if (player2.FacingRight == true && !fired) {
                ammoSpeed = speedRight;
                fired = true;
            }
            else if (player2.FacingLeft == true && !fired) {
                ammoSpeed = speedLeft;
                fired = true;
            }
        }
        //When time reaches 3 seconds, it destroys itself
        if (time >= 3)
            Destroy(gameObject);
        //Sets the velocity of the ammo
        theRB.velocity = new Vector2(ammoSpeed * transform.localScale.x, 0);
    }
    //If the ammo collides with anything, it's destroyed
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
