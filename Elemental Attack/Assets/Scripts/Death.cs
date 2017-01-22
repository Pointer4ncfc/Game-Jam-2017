using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
//Acecessing the Variables from The Game Manager Code
    GameManager gm;
    private Rigidbody theRB;

//Accessing the Variables from The Player Movement code
    public bool playerDead = false;
    public float playerNo;


  

    PlayerMovement player1script;
    public GameObject player1prefab;
    public Vector3 player1start;
  
    PlayerMovement player2script;
    public GameObject player2prefab;
    public Vector3 player2start;

    // Use this for initialization
    void Start() {
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        theRB = GetComponent<Rigidbody>();

        playerDead = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        theRB = GetComponent<Rigidbody>();

        playerNo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerNo;
        theRB = GetComponent<Rigidbody>();

        player1script = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().player1script;
        theRB = GetComponent<Rigidbody>();

         player1script = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().player1script;
        theRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
    }
     
// Picking up whether it is colliding with the 
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Death") {
            playerDead = true;
            Destroy(gameObject);

            if (playerNo == 1) {
                gm.Player2Score = 1;
            }
            if (playerNo == 2) {
                gm.Player1Score = 1;
            }
        }
        /*
        if (player1script.playerDead) {
            Destroy(player2script.gameObject);
            Instantiate(player1prefab, player1start, Quaternion.identity);
            Instantiate(player2prefab, player2start, Quaternion.identity);
            player1script = GameObject.Find("Player 1(Clone)").GetComponent<PlayerMovement>();
            player2script = GameObject.Find("Player 2(Clone)").GetComponent<PlayerMovement>();
        }
        if (player2script.playerDead) {
            Destroy(player1script.gameObject);
            Instantiate(player1prefab, player1start, Quaternion.identity);
            Instantiate(player2prefab, player2start, Quaternion.identity);
            player1script = GameObject.Find("Player 1(Clone)").GetComponent<PlayerMovement>();
            player2script = GameObject.Find("Player 2(Clone)").GetComponent<PlayerMovement>();
        }
        */
    } 
   
}