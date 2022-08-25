using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [Range(0, 5)]
    public float activationRange;

    private GameObject trashTutorial;

    private void Start()
    {
        trashTutorial = GameObject.Find("TrashTutorial");
        trashTutorial.SetActive(false);
    }

    void Update()
    {
        if (activationRange >= Vector2.Distance(new Vector3(transform.position.x, transform.position.y), new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y)))
        {
            trashTutorial.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                transform.position = GameObject.Find("trashAway").transform.position;
            }
        }
    }
}
