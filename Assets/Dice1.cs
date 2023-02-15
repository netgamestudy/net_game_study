using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice1 : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public bool coroutineAllowed = true;
    public bool RollingAllowed = true;
    public int randomDiceSide = 0;

    GameObject diceControl;

	private void Start () {
        diceControl = GameObject.Find("DiceControl");
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
	}

    private void OnMouseDown()
    {
        // gameover 가 되지 않았을 경우라는 조건추가
        if (coroutineAllowed)
            diceControl.GetComponent<DiceControl>().RollDices();
        else if (!coroutineAllowed && RollingAllowed)
            diceControl.GetComponent<DiceControl>().StopDices();
    } 

    public IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        randomDiceSide = 0;

        while(RollingAllowed)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
            
        }

        diceControl.GetComponent<DiceControl>().DiceFinished(randomDiceSide+1);

    }
}
