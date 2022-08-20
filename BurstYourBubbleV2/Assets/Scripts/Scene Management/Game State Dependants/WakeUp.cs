using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("gameState", "Asleep");
        GameObject.Find("Bed").GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
