using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{

    int player1Score = 0;
    int player2Score = 0;

    public TextMesh p1Score;
    public TextMesh p2Score;

    void Start()
    {

    }

    void Update()
    {
        p1Score.text = ("Player 1 : " + player1Score);
        p2Score.text = ("Player 2 : " + player2Score);
    }

    public int Player1Score { set { player1Score += value; } }
    public int Player2Score { set { player2Score += value; } }
}
