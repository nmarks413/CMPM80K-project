using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [Range(0, 5)]
    public float activationRange;

    void Update()
    {
        if (activationRange >= Vector2.Distance(new Vector3(transform.position.x, transform.position.y), new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y)))
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {

            }
        }
    }
}
