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

    void Start() {
    }

    void Update() {
    //Updates the scoreboard
        p1Score.text = ("Player 1 : " + player1Score);
        p2Score.text = ("Player 2 : " + player2Score);
    }
    //Allows the private scores to be set externally
    public int Player1Score { set { player1Score += value; } }
    public int Player2Score { set { player2Score += value; } }
}
