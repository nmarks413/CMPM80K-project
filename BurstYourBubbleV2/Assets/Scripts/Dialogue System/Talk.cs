using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    [Range(0, 5)]
    public float distanceUntilActivated;

    private void Start()
    {
        for(int i = 0; i < GetComponentsInChildren<SpriteRenderer>().Length+1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (distanceUntilActivated >= Vector2.Distance(new Vector3(transform.position.x, transform.position.y), new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y)))
        {
            if (!transform.GetChild(0).gameObject.activeSelf)
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }

            if(Input.GetKey(KeyCode.Alpha1))
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if(Input.GetKey(KeyCode.Alpha2))
            {
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if(Input.GetKey(KeyCode.Alpha3))
            {
                transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
