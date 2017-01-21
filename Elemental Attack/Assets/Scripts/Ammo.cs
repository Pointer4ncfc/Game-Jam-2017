using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

    public float ammoSpeed;
    private Rigidbody theRB;
    bool fired;

    float time = 0;




    // Use this for initialization
    void Start () {
        theRB = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        PlayerMovement player1 = GameObject.Find("Player 1").GetComponent<PlayerMovement>();
        PlayerMovement player2 = GameObject.Find("Player 2").GetComponent<PlayerMovement>();
        
        time += Time.deltaTime;
        Debug.Log("TIME : " + time);

        if (gameObject.name == "Ammo(Clone)") {
            if (player1.FacingRight == true && !fired) {
                ammoSpeed = 15;
                fired = true;
            } else if (player1.FacingLeft == true && !fired) {
                ammoSpeed = -15;
                fired = true;
            }
        }
        if (gameObject.name == "Ammo 1(Clone)") {
            if (player2.FacingRight == true && !fired) {
                ammoSpeed = 15;
                fired = true;
            }
            else if (player2.FacingLeft == true && !fired) {
                ammoSpeed = -15;
                fired = true;
            }
        }

        if (time >= 3)
            Destroy(gameObject);

        theRB.velocity = new Vector2(ammoSpeed * transform.localScale.x, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
