using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//This code has been created by his Lord Supreme, his most Holiness and all that is good in our world,
//our God-Emperor Calum Bucknall, First of his Name, Lord of All Humanity, The Alpha and Omega.
//He who brings light to our miserable lives, the very essence of Good.
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
    [SerializeField]
    //States if the player is on solid ground
    bool onGround;
    [SerializeField]
    //States if the player has taken their second jump
    bool secondJump;
    [SerializeField]
    //States if the player is on a wall
    bool onWall;
    bool facingLeft;
    bool facingRight;
    [Header("Strings")]
    public string Horizontal;
    public string Vertical;
    [Header("Key Codes")]
    public KeyCode throwAmmo;
    public KeyCode jump;
    [Header("Attacks")]
    public GameObject ammo;
    public Transform throwPoint;
    public GameObject ammoClone;

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
        if (Input.GetKeyDown(throwAmmo)) {
            GameObject ammoClone = (GameObject)Instantiate(ammo, throwPoint.position, throwPoint.rotation);


        }
    }
    //#Triggered
    //If the object is an attack, like the bullets, you dead
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Attack") {
            playerDead = true;
            Destroy(gameObject);
            //Keeping tabs on your kill counts
            if(playerNo == 1) {
                gm.Player2Score = 1;
            }
            if (playerNo == 2) {
                gm.Player1Score = 1;
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