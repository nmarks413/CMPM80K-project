using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    [Range(0, 5f)]
    public float activationRange;

    private GameObject diaryCanvas;

    private bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        diaryCanvas = GameObject.Find("Diary Canvas");
        diaryCanvas.SetActive(false);
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activationRange >= Vector2.Distance(new Vector3(transform.position.x, transform.position.y), new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y)))
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isActivated)
            {
                diaryCanvas.SetActive(true);
                isActivated = true;
            }
            else if(Input.GetKeyDown(KeyCode.Space) && isActivated)
            {
                diaryCanvas.SetActive(false);
            }
        }
    }
}
