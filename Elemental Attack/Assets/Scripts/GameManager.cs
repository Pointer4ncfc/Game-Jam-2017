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
    PlayerMovement player1script;
    public GameObject player1prefab;
    public Vector3 player1start;
    [SerializeField]
    PlayerMovement player2script;
    public GameObject player2prefab;
    public Vector3 player2start;

    void Start() {
    }

    void Update() {
    //Updates the scoreboard
        p1Score.text = ("Player 1 : " + player1Score);
        p2Score.text = ("Player 2 : " + player2Score);

        if(player1script.playerDead) {
            Destroy(player2script.gameObject);
            Instantiate(player1prefab, player1start, Quaternion.identity);
            Instantiate(player2prefab, player2start, Quaternion.identity);
            player1script = GameObject.Find("Player 1(Clone)").GetComponent<PlayerMovement>();
            player2script = GameObject.Find("Player 2(Clone)").GetComponent<PlayerMovement>();
        }
        if(player2script.playerDead) {
            Destroy(player1script.gameObject);
            Instantiate(player1prefab, player1start, Quaternion.identity);
            Instantiate(player2prefab, player2start, Quaternion.identity);
            player1script = GameObject.Find("Player 1(Clone)").GetComponent<PlayerMovement>();
            player2script = GameObject.Find("Player 2(Clone)").GetComponent<PlayerMovement>();
        }
    }
    //Allows the private scores to be set externally
    public int Player1Score { get; set; }
    public int Player2Score { get; set; }
}
