using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveControl : MonoBehaviour
{
    public string[] role = {"시작점", "", "", "", "", "", "",
                            "코인", "코인", "코인", "코인", "코인", "코인", "코인",
                            "상점", "", "", "", "", "", "",
                            "도둑", "도둑", "도둑", "도둑", "도둑", "도둑", "도둑"};

    private static GameObject player1MoveText, player2MoveText, turnText;

    private static GameObject player1, player2;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static int whosTurn = 1; //양수면 파랑, 음수면 빨강, 절대치는 턴수
    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");
        turnText = GameObject.Find("Turn");

        player1 = GameObject.Find("PL1");
        player2 = GameObject.Find("PL2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex >
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
            Debug.Log("PL1 " + player1StartWaypoint.ToString() + " 도착");
            CheckArrived(1, player1StartWaypoint);
            ChangeTurn();
        }
        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
            Debug.Log("PL2 " + player2StartWaypoint.ToString() + " 도착");
            CheckArrived(2, player2StartWaypoint);
            ChangeTurn();
        }
        if (player1StartWaypoint + diceSideThrown > 27 && player1.GetComponent<FollowThePath>().waypointIndex == 0)
            player1StartWaypoint -= 28;
        if (player2StartWaypoint + diceSideThrown > 27 && player2.GetComponent<FollowThePath>().waypointIndex == 0)
            player2StartWaypoint -= 28;
    }

    public static void MovePlayer(int Turn)
    {
        if (Turn > 0)
            player1.GetComponent<FollowThePath>().moveAllowed = true;
        else
            player2.GetComponent<FollowThePath>().moveAllowed = true;
    }

    void CheckArrived(int player, int arrived)
    {
        switch (role[arrived])
        {
            case "코인":
                OwnControl.GetCoin(player, 10);
                break;
            case "도둑":
                OwnControl.GetCoin(player, -10);
                break;
        }
    }
    void ChangeTurn()
    {
        whosTurn *= -1;
        if (whosTurn > 0)
        {
            whosTurn += 1;
            turnText.GetComponent<Text>().text = "Turn : " + whosTurn.ToString();
        }
    }
            
}
