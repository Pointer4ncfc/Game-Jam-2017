using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//majority of help from God-Emperor-Lord-Commander Bucknall
public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    CharacterSwitch switcher;
    GameManager gm;
    [Header("Rigid Bodies")]
    public Rigidbody thisRigidbody;
    private Rigidbody theRB;
    [Header("Floats")]
    public float playerNo; 
    public float jumpSpeed = 5;
    public float speed = 5;
    private bool grounded = true;
    public float moveSpeed = 5;
    public float jumpForce;
    public float rotateLeft;
    public float rotateRight;
    [Header("Bools")]
    public bool playerDead = true;
    bool facingLeft;
    bool facingRight;
    bool flipped;
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

    // Use this for initialization
    void Start() {
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();   
        theRB = GetComponent<Rigidbody>();
        if(playerNo == 1) {
            facingRight = true;
        }else {
            facingLeft = true;
        }
    }

    // Update is called once per frame
    void Update() {
        float translationX = Input.GetAxis(Horizontal) * speed;
        float translationY = Input.GetAxis(Vertical) * speed;
        if(gameObject.name == "Player 1") {
            Debug.Log("FLeft : " + facingLeft + " FRight : " + facingRight);
        }
        
        transform.Translate(translationX, translationY, 0);

        if(facingLeft) {
            if(translationX >= rotateRight) {
                transform.localScale = new Vector3(1, 5, 1);
                facingLeft = false;
                facingRight = true;
            }
        }
        
        else if(facingRight) {
            if(translationX <= rotateLeft)
            {
                transform.localScale = new Vector3(-1, 5, 1);
                facingLeft = true;
                facingRight = false;
            }
        }

        if (Input.GetKeyDown(jump)) {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);

        }

        if (Input.GetKeyDown(throwAmmo)) {
            GameObject ammoClone = (GameObject)Instantiate(ammo, throwPoint.position, throwPoint.rotation);


        }

        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(kcode))
                Debug.Log("KeyCode down: " + kcode);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Attack")
        {
            playerDead = true;
            Debug.Log(playerDead);
            Destroy(gameObject);
            if(playerNo == 1) {
                gm.Player2Score = 1;
            }
            if (playerNo == 2) {
                gm.Player1Score = 1;
            }
        }
    }

    public bool FacingLeft { get { return facingLeft; } }
    public bool FacingRight { get { return facingRight; } }

    
 
  //  if (playerDead=true)

/*
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Platform" && grounded == false) {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "Platform") {
            grounded = false;
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal")
        transform.position += moveSpeed * Time.deltaTime;

    }



     var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
      transform.position += move * speed * Time.deltaTime;

       if (Input.GetKey(KeyCode.Joystick 1 Button 14 ))
       {

       }

       if (Input.GetKey(KeyCode.LeftArrow))
       {

       }

       if (Input.GetKey(KeyCode.UpArrow) && grounded == true)
       {
           grounded = false;
           thisRigidbody.velocity = new Vector3(0, jumpSpeed, 0);
       }




       if(Input.GetKey(left))
       {
           theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
       }       else if(Input.GetKey(right))
       {
           theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
       } else {
           theRB.velocity = new Vector2(0, theRB.velocity.y);
       }


       

    if (Input.GetKeyDown(throwAmmo))
    {
        GameObject ammoClone = (GameObject)Instantiate(ammo, throwPoint.position, throwPoint.rotation);
        ammoClone.transform.localScale = transform.localScale;

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Platform" && grounded == false) {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Platform")
        {
            grounded = false;
        }
    }
  */
}