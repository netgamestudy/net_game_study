using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnControl : MonoBehaviour
{
    private static GameObject player1CoinText, player2CoinText, player1StarText, player2StarText;
    public static int PL1Coin = 0;
    public static int PL2Coin = 0;
    public static int PL1Star = 0;
    public static int PL2Star = 0;

    void Start()
    {
        player1CoinText = GameObject.Find("Player1CoinText");
        player2CoinText = GameObject.Find("Player2CoinText");
        player1StarText = GameObject.Find("Player1StarText");
        player2StarText = GameObject.Find("Player2StarText");
    }

    public static void GetCoin(int player, int coins)//1Àº ÆÄ¶û, 2´Â »¡°­
    {
        if (player == 1)
        {
            PL1Coin += coins;
            if (PL1Coin < 0)
                PL1Coin = 0;
            player1CoinText.GetComponent<Text>().text = PL1Coin.ToString();
        }
        else
        {
            PL2Coin += coins;
            if (PL2Coin < 0)
                PL2Coin = 0;
            player2CoinText.GetComponent<Text>().text = PL2Coin.ToString();
        }
    }

    public static void GetStar(int player, int stars)//1Àº ÆÄ¶û, 2´Â »¡°­
    {
        if (player == 1)
        {
            PL1Star += stars;
            if (PL1Star < 0)
                PL1Star = 0;
            player1StarText.GetComponent<Text>().text = ""+PL1Star.ToString();
        }
        else
        {
            PL2Star += stars;
            if (PL2Star < 0)
                PL2Star = 0;
            player2StarText.GetComponent<Text>().text = "" + PL2Star.ToString();
        }
    }
}
