using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject window;
    // Start is called before the first frame update
    public void Exit()
    {
        window.SetActive(false);
        MoveControl.MovePlayer(MoveControl.whosTurn);
    }
}
