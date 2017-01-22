using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//This code has been created by the Lord Supremes. They, the most Holy and all that is good in our world,
//our God-Emperors Darren and Jay, First of their Names, Lords of All Humanity, The Alphas and Omegas.
//They who brought light to Calums miserable life.
public class PlayerMovement : MonoBehaviour {
    
    [SerializeField]
    //Variable for the CharacterSwitch script
    CharacterSwitch switcher;
    //Variable for the GameManager script
    GameManager gm;
    [Header("Rigid Bodies")]
    private Rigidbody theRB;
    [Header("Floats")]
    public float playerNo;
    //Sets movement speed
    public float speed;
    //Sets jump height
    public float jumpForce;
    public float rotateLeft;
    public float rotateRight;
    [Header("Bools")]
    public bool playerDead = false;
    //States if the player is on solid ground
    bool onGround;
    //States if the player has taken their second jump
    bool secondJump;
    //States if the player is on a wall
    bool onWall;
    bool facingLeft;
    bool facingRight;
	public bool fire;
	public bool ice;
	public bool earth;
	public bool air;
    [Header("Strings")]
    public string Horizontal;
    public string Vertical;
    [Header("Key Codes")]
    public KeyCode attack;
    public KeyCode jump;
    [Header("Attacks")]
    public GameObject ammo;
    public Transform throwPoint;
    public GameObject ammoClone;
	public GameObject airBlock;
	public GameObject stoneBlock;
	public GameObject fireDab;

	public Animator ani;

	float time;

    void Start() {
        //Sets the GameManager script  
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();  
        //Sets the rigidbody 
        theRB = GetComponent<Rigidbody>();
        //Determines which bool needs to be true depending on which player it is
        if(playerNo == 1) {
            facingRight = true;
        }else {
            facingLeft = true;
        }
    }

    void Update() {
        //Testy bit to see which buttosn on the gamepad we're hitting, can now be turned off/removed/commented out
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(kcode))
                Debug.Log("KeyCode down: " + kcode);
        }
    }
	//Everythings says do physics in fixedUpdate, so that's what I did
	void FixedUpdate() {
		if (onWall)
			secondJump = false;
		//If jump is pressed and the player is either on the ground, or is in the air with their second jump unused
		if (Input.GetKeyDown(jump) && (onGround || !onGround && !secondJump)) {
			//Sets the force of the jump
			theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
			//If the player jumps while not on the ground, this will use their second jump
			if (!onGround) {
				secondJump = true;
			}
		}
		//Movement. Leave alone. Play with the variables in the inspector
		float translationX = Input.GetAxis(Horizontal) * speed;
		float translationY = Input.GetAxis(Vertical) * speed;

		transform.Translate(translationX, translationY, 0);
		if (translationX > 0 || translationX < 0) {
			ani.SetBool("Running", true);
		} else {
			ani.SetBool("Running", false);
		}

        if (facingLeft) {
            if (translationX >= rotateRight) {
                transform.localScale = new Vector3(1, 5, 1);
                facingLeft = false;
                facingRight = true;
            }
        }

        else if (facingRight) {
            if (translationX <= rotateLeft) {
                transform.localScale = new Vector3(-1, 5, 1);
                facingLeft = true;
                facingRight = false;
            }
        }
        //Press that fire button? Shit's getting instantiated at the throw point
        if (Input.GetKeyDown(attack)) {
			if (ice) {
				ani.SetTrigger("IA");
				GameObject ammoClone = (GameObject)Instantiate(ammo, throwPoint.position, throwPoint.rotation);
			}
			if (fire) {
				ani.SetTrigger("Fire");
				float startX = gameObject.transform.position.x;
				//GameObject fireClone = (GameObject)Instantiate(fireDab, throwPoint.position, throwPoint.rotation);
				//fireClone.transform.parent = gameObject.transform;
				if(gameObject.transform.position.x <= startX + 30) {
					theRB.velocity = new Vector2(40 * transform.localScale.x, 0);
				}

			}
			if (earth && onGround) {
				ani.SetTrigger("Earth");
				GameObject earthClone = (GameObject)Instantiate(stoneBlock, new Vector3(throwPoint.position.x, throwPoint.position.y - 5, throwPoint.position.z), Quaternion.Euler(0,0,0));
			}
			if (air) {
				ani.SetTrigger("IA");
				GameObject airClone = (GameObject)Instantiate(airBlock, throwPoint.position, throwPoint.rotation);

			}
        }

    }
    //#Triggered
    //If the object is an attack, like the bullets, you dead
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Attack" || col.gameObject.tag == "Death") {
            playerDead = true;
            //Keeping tabs on your kill counts
            if(playerNo == 1) {
				Debug.Log("Player 1 is Dead");
                gm.Player2Score = 1;
            }
            if (playerNo == 2) {
				Debug.Log("Player 2 is Dead");
                gm.Player1Score = 1;
            }
			if(col.gameObject.tag == "Air") {

			}
        }
    }
    //Lets shit outside the script check which way the player's facing
    public bool FacingLeft { get { return facingLeft; } }
    public bool FacingRight { get { return facingRight; } }

    //Making a collision shit
    void OnCollisionEnter(Collision col) {
            //Open the door
        if(col.collider.gameObject.tag == "Floor") {
            if (!onGround) {
                //Get on the floor
                onGround = true;
                secondJump = false;
                    //Everybody do the dinosaur
            }
        }
        //Ninja shit, yo
        if (col.collider.gameObject.tag == "Wall") {
            if (!onWall && !onGround) {
                secondJump = false;
                onWall = true;
            }
        }
    }
    //Leaving a collision shit
    void OnCollisionExit(Collision col) {
        //Was you on the floor?
        if(col.collider.gameObject.tag == "Floor") {
            if(onGround) {
            //Not anymore
                onGround = false;
                //Bitch
            }
        }
        //Get off that wall, you're not fucking Spiderman
        if(col.collider.gameObject.tag == "Wall") {
        //Well, Jay may be fucking someone claiming to be Spiderman for all we know
            if(onWall) {
            //But that's none of my business
                onWall = false;
            }
        }
    }
}
//Did you guys really bother reading all that stuff at the top?