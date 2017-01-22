using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Score counters")]
    int player1Score = 0;
    int player2Score = 0;
    [Header("Text that displays scores")]
    public TextMesh p1Score;
    public TextMesh p2Score;
    [Header("Arrays containing environmental colliders")]
    public Collider[] floors;
    public Collider[] walls;
    public Collider[] ceilings;
    [Header("Scripts")]
    [SerializeField]
    public PlayerMovement player1script;
    public GameObject player1prefab;
    public Vector3 player1start;
    [SerializeField]
    public PlayerMovement player2script;
    public GameObject player2prefab;
    public Vector3 player2start;

    void Start() {
    }

    void Update() {
    //Updates the scoreboard
        p1Score.text = ("Player 1 : " + player1Score);
        p2Score.text = ("Player 2 : " + player2Score);

        if(player1script.playerDead || player2script.playerDead || (player1script.playerDead && player2script.playerDead)) {
			//Ragdoll
			//After animation
			player1script.gameObject.transform.position = player1start;
			player2script.gameObject.transform.position = player2start;
			player1script.playerDead = false;
			player2script.playerDead = false;
        }
    }
    //Allows the private scores to be set externally
    public int Player1Score { get { return player1Score; } set { player1Score += value; } }
    public int Player2Score { get { return player2Score; } set { player2Score += value; } }
}
