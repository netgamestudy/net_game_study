using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControl : MonoBehaviour
{
    public void BuyStar()
    {
        if (MoveControl.whosTurn > 0)
        {
            if (OwnControl.CheckMoney(1, 20))
            {
                OwnControl.GetCoin(1, -20);
                OwnControl.GetStar(1, 1);
            }
        }
        else
        {
            if (OwnControl.CheckMoney(2, 20))
            {
                OwnControl.GetCoin(2, -20);
                OwnControl.GetStar(2, 1);
            }
        }
    }
}
