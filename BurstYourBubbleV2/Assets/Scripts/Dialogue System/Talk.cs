using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    [Range(0, 5)]
    public float distanceUntilActivated;

    private List<int> generatedNumbers;

    private bool dialogueCreated;
    private bool chosen;

    private void Start()
    {
        for (int i = 0; i < GetComponentsInChildren<SpriteRenderer>().Length + 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        generatedNumbers = new List<int>();
        dialogueCreated = false;
        chosen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (distanceUntilActivated >= Vector2.Distance(new Vector3(transform.position.x, transform.position.y), new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y)))
        {
            if (!transform.GetChild(0).gameObject.activeSelf)
            {
                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);

                    int randomNumber;

                    if (!dialogueCreated)
                    {
                        randomNumber = Random.Range(0, 10);

                        while (generatedNumbers.Contains(randomNumber))
                        {
                            randomNumber = Random.Range(0, 10);
                        }

                        generatedNumbers.Add(randomNumber);
                        chosen = false;
                    }
                    else
                    {
                        randomNumber = generatedNumbers[i];
                    }
                    GameObject dialogueOption = new GameObject();
                    dialogueOption.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Dialogue/Speech Icons/" + randomNumber.ToString());

                    dialogueOption.transform.SetParent(transform.GetChild(i));
                    dialogueOption.transform.position = dialogueOption.transform.parent.position + Vector3.back + 0.2f * Vector3.up;

                }

                dialogueCreated = true;
            }

            if (Input.GetKey(KeyCode.Alpha1))
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
                transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.white;
                chosen = true;
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.green;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.white;
                chosen = true;
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.green;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
                chosen = true;
            }
            if(Input.GetKeyDown(KeyCode.Space) && chosen)
            {
                for (int i = 0; i < GetComponentsInChildren<SpriteRenderer>().Length + 1; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }

                PlayerPrefs.SetInt("Confidence", PlayerPrefs.GetInt("Confidence") - 1);
            }
        }
        else
        {
            for (int i = 0; i < GetComponentsInChildren<SpriteRenderer>().Length + 1; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
