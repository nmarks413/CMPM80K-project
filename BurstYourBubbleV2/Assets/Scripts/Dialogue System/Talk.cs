using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    [Range(0, 5)]
    public float distanceUntilActivated;

    private List<int> generatedNumbers;

    private float color;

    private bool dialogueCreated;
    private bool chosen;
    private bool confirm;
    private void Start()
    {
        DisableBubbles();

        generatedNumbers = new List<int>();

        dialogueCreated = false;
        chosen = false;
        confirm = false;

        //Debug
        PlayerPrefs.SetInt("Confidence", 20);
        PlayerPrefs.SetInt("maxConfidence", 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (activatedByPlayer() && !confirm)
        {
            if (!transform.GetChild(0).gameObject.activeSelf)
            {
                SpawnBubbles();
                dialogueCreated = true;
            }

            if (Input.GetKey(KeyCode.Alpha1))
            {
                SelectBubble(0);
                chosen = true;
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                SelectBubble(1);
                chosen = true;
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                SelectBubble(2);
                chosen = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && chosen)
            {
                DisableBubbles();
                confirm = true;

                ChangeConfidence(1, 1);
                makeFriend();
            }
        }
        else
        {
            DisableBubbles();
        }
    }

    private bool activatedByPlayer()
    {
        if (distanceUntilActivated >= Vector2.Distance(new Vector3(transform.position.x, transform.position.y), new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y)))
            return true;
        else
            return false;
    }
    private void SelectBubble(int bubbleIndex)
    {
        for(int i = 0; i < 3; i++)
        {
            if (bubbleIndex == i)
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.green;
            else
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void SpawnBubbles()
    {
        for(int i = 0; i < 3; i++)
        {

            transform.GetChild(i).gameObject.SetActive(true);

            if (dialogueCreated)
            {
                PopulateBubbles(generatedNumbers[i], i);
            }
            else
            {
                PopulateBubbles(GenerateRandom(), i);
            }
        }
    }
    private void PopulateBubbles(int randomNumber, int i)
    {
        GameObject dialogueOption = new GameObject();
        dialogueOption.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Dialogue/Speech Icons/" + randomNumber.ToString());

        dialogueOption.transform.SetParent(transform.GetChild(i));
        dialogueOption.transform.position = dialogueOption.transform.parent.position + Vector3.back + 0.2f * Vector3.up;
    }
    private int GenerateRandom()
    {
        int randomNumber = Random.Range(0, 10);

        while (generatedNumbers.Contains(randomNumber))
        {
            randomNumber = Random.Range(0, 10);
        }

        return randomNumber;
    }
    private void DisableBubbles()
    {
        for (int i = 0; i < GetComponentsInChildren<SpriteRenderer>().Length + 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void ChangeConfidence(int maxUp, int currentDown)
    {
        PlayerPrefs.SetInt("Confidence", PlayerPrefs.GetInt("Confidence") - currentDown);
        PlayerPrefs.SetInt("maxConfidence", PlayerPrefs.GetInt("maxConfidence") + maxUp);
    }
    private void makeFriend()
    {
        GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color - new Color(0.25f, 0, 0.25f, 0);
    }
}