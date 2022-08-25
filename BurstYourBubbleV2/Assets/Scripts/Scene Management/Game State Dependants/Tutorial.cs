using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private GameObject arrowTutorial;

    private void Start()
    {
        arrowTutorial = GameObject.Find("ArrowTutorial");
        arrowTutorial.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetString("gameState") == "Asleep")
        {
            GameObject.Find("SpaceTutorial").SetActive(false);
            arrowTutorial.SetActive(true);
        }
    }
}
