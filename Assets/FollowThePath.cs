using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 5f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed;
    public GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
            Move();
    }

    void Move()
    {
        if (waypointIndex == waypoints.Length)// loop
        {
            waypointIndex = 0;
            if (MoveControl.whosTurn > 0)
                OwnControl.GetCoin(1, 10);
            else
                OwnControl.GetCoin(2, 10);
        }

        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                if (MoveControl.role[waypointIndex] == "상점")
                {
                    moveAllowed = false;
                    shop.gameObject.SetActive(true);
                    if (MoveControl.whosTurn > 0)
                    {
                        Debug.Log("PL1 상점");
                    }
                    else
                    {
                        Debug.Log("PL2 상점");
                    }
                }
                waypointIndex += 1;
                Debug.Log((waypointIndex - 1).ToString() + " 통과");
            }
        }
    }
}
