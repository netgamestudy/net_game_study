using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnControl : MonoBehaviour
{
    private static GameObject player1CoinText, player2CoinText, player1StarText, player2StarText;
    public static int[] CoinList = { 0, 0 };
    public static int[] StarList = { 0, 0 };

    void Start()
    {
        player1CoinText = GameObject.Find("Player1CoinText");
        player2CoinText = GameObject.Find("Player2CoinText");
        player1StarText = GameObject.Find("Player1StarText");
        player2StarText = GameObject.Find("Player2StarText");
    }

    public static void GetCoin(int player, int coins)//1Àº ÆÄ¶û, 2´Â »¡°­
    {
        CoinList[player - 1] += coins;
        if (CoinList[player - 1] < 0)
            CoinList[player - 1] = 0;
        if (player == 1)
            player1CoinText.GetComponent<Text>().text = CoinList[0].ToString();
        else
            player2CoinText.GetComponent<Text>().text = CoinList[1].ToString();
    }

    public static void GetStar(int player, int stars)//1Àº ÆÄ¶û, 2´Â »¡°­
    {
        StarList[player - 1] += stars;
        if (StarList[player - 1] < 0)
            StarList[player - 1] = 0;
        if (player == 1)
            player1StarText.GetComponent<Text>().text = StarList[0].ToString();
        else
            player2StarText.GetComponent<Text>().text = StarList[1].ToString();
    }

    public static bool CheckMoney(int player, int price)
    {
        return CoinList[player - 1] >= price;
    }
}
