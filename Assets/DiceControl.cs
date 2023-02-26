using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceControl : MonoBehaviour
{
    private static GameObject dice1, dice2;
    public int DiceNum = 2; // 주사위의 갯수
    private int DiceCount = 0; // 끝난 주사위 카운트
    public int DiceSideSum = 0; // 나온 주사위 값의 총합

    // Start is called before the first frame update
    void Start()
    {
        dice1 = GameObject.Find("Dice1");
        dice2 = GameObject.Find("Dice2");
    }

    public void RollDices()
    {
        DiceSideSum = 0;
        dice1.GetComponent<Dice1>().StartCoroutine("RollTheDice");
        dice2.GetComponent<Dice2>().StartCoroutine("RollTheDice");
    }

    public void StopDices()
    {
        dice1.GetComponent<Dice1>().RollingAllowed = false;
        dice2.GetComponent<Dice2>().RollingAllowed = false;
    }

    public static void ReleaseDices()
    {
        dice1.GetComponent<Dice1>().coroutineAllowed = true;
        dice1.GetComponent<Dice1>().RollingAllowed = true;
        dice2.GetComponent<Dice2>().coroutineAllowed = true;
        dice2.GetComponent<Dice2>().RollingAllowed = true;
    }

    public void DiceFinished(int DiceSides)
    {
        DiceSideSum += DiceSides;
        DiceCount++;
        if (DiceCount >= DiceNum)
        {
            MoveControl.diceSideThrown = DiceSideSum;
            MoveControl.MovePlayer(MoveControl.whosTurn);// 이 부분에서 더해진 주사위 값인 DiceSideSum 만큼 플레이어를 움직이게 함


            DiceCount = 0;
        }
            
    }
}
