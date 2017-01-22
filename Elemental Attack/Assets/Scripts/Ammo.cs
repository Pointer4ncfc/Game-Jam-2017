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
	[SerializeField]
    bool fired;

	float startHeight;

    float time = 0;
	public float timer;
	[SerializeField]
    PlayerMovement player1;
	[SerializeField]
    PlayerMovement player2;
    GameManager gm;


    void Start () {
        theRB = GetComponent<Rigidbody>();
        gm = GameObject.Find("Main Camera").GetComponent<GameManager>();
		//Gets the PlayerMovement scripts from the player objects
		{
            player1 = GameObject.Find("Player 1").GetComponent<PlayerMovement>();
            player2 = GameObject.Find("Player 2").GetComponent<PlayerMovement>();
        }
		startHeight = gameObject.transform.position.y;
		Debug.Log(startHeight);
    }

    void Update()
    {
        //Counts time since creation of the ammo
        time += Time.deltaTime;
        
        //If the bullet is fired by player 1
        if (gameObject.name == "Ammo(Clone)" || gameObject.name == "AirWall(Clone)") {
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
        if (gameObject.name == "Ammo 1(Clone)" || gameObject.name == "AirWall 1(Clone)") {
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
        if (time >= timer)
            Destroy(gameObject);
        //Sets the velocity of the ammo
		if(gameObject.name == "Ammo(Clone)" || gameObject.name == "Ammo 1(Clone)") {
			theRB.velocity = new Vector2(ammoSpeed * transform.localScale.x, 0);
		}
		if(gameObject.name == "AirWall(Clone)" || gameObject.name == "AirWall 1(Clone)") {
			theRB.velocity = new Vector2(ammoSpeed * transform.localScale.x, 0);
		}

		if(gameObject.name == "Stone(Clone)" || gameObject.name == "Stone 1(Clone)") {
			Debug.Log("Rock Block");
			if(gameObject.transform.position.y <= startHeight + 4)
				transform.Translate(0, 1, 0);
		}
    }
    //If the ammo collides with anything, it's destroyed
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
