using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetString("gameState") == "School Hallway2")
        {
            GameObject.Find("Player").transform.position = GameObject.Find("After_Class").transform.position;
        }
        else if(PlayerPrefs.GetString("gameState") == "School Hallway3")
        {
            GameObject.Find("Player").transform.position = GameObject.Find("After_Lunch").transform.position;
        }
    }
}
