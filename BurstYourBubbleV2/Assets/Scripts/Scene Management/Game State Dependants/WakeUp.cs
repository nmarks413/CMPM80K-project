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
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetString("gameState") == "Asleep")
        {
            GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/idle_right");
            GameObject.Find("Player").transform.position += Vector3.right;
            GameObject.Find("Bed").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("bed_blanket").SetActive(false);

            PlayerPrefs.SetString("gameState", "Awake");
        }
    }
}
