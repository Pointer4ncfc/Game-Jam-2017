using UnityEngine;
using System.Collections;
//written by Darren Williams ALONE!
public class PlayerMovement : MonoBehaviour {

    public Rigidbody thisRigidbody;
    public float jumpSpeed = 5;
    public float speed = 5;
    private bool grounded = true;
    public float moveSpeed = 5;
    private Rigidbody theRB;
    public float jumpForce;



    public KeyCode throwAmmo;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public GameObject ammo;
    public Transform throwPoint;
    public GameObject ammoClone;

    // Use this for initialization
    void Start() {
        theRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            //    theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump))
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);

        }

        if (Input.GetKeyDown(throwAmmo))
        {
            GameObject ammoClone = (GameObject)Instantiate(ammo, throwPoint.position, throwPoint.rotation);


        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Platform" && grounded == false)
        {
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

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal")
        transform.position += moveSpeed * Time.deltaTime;

    }



    //  var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    //  transform.position += move * speed * Time.deltaTime;

    /*   if (Input.GetKey(KeyCode.Joystick 1 Button 14 ))
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