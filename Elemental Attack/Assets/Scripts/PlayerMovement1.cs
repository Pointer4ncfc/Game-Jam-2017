using UnityEngine;
using System.Collections;

public class PlayerMovement1 : MonoBehaviour {

    public Rigidbody thisRigidbody;
    public float jumpSpeed = 5;
    public float speed = 5;
    private bool grounded = true;

    public KeyCode throwAmmo;

    public GameObject ammo;
    public Transform throwPoint;

    // Use this for initialization
    void Start() {}

    // Update is called once per frame
    void Update() {}


    void FixedUpdate()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.G))
        {

        }

        if (Input.GetKey(KeyCode.J))
        {

        }

        if (Input.GetKey(KeyCode.Y) && grounded == true)
        {
            grounded = false;
            thisRigidbody.velocity = new Vector3(0, jumpSpeed, 0);
        }



        if(Input.GetKeyDown(throwAmmo))
        {
            GameObject ballClone = (GameObject)Instantiate(ammo, throwPoint.position, throwPoint.rotation);
          

        }


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

}