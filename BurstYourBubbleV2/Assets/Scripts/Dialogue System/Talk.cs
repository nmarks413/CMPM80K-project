using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Talk : MonoBehaviour
{
    [Range(0, 5)]
    public float distanceUntilActivated;

    private List<int> generatedNumbers;

    private float color;

    private bool dialogueCreated;
    private bool chosen;
    private bool confirm;

    public char chosenDir;
    private void Start()
    {
        DisableBubbles();

        generatedNumbers = new List<int>();

        dialogueCreated = false;
        chosen = false;
        confirm = false;

        GetComponent<SpriteRenderer>().color = new Color(PlayerPrefs.GetFloat("Red" + SceneManager.GetActiveScene().name + transform.name, GetComponent<SpriteRenderer>().color.r), PlayerPrefs.GetFloat("Green" + SceneManager.GetActiveScene().name + transform.name, GetComponent<SpriteRenderer>().color.g), PlayerPrefs.GetFloat("Blue" + SceneManager.GetActiveScene().name + transform.name, GetComponent<SpriteRenderer>().color.b));
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

                switch (chosenDir)
                {
                    case '0':
                        ChangeConfidence(1, 1);
                        break;
                    case '1':
                        ChangeConfidence(1, 1);
                        break;
                    case '2':
                        ChangeConfidence(3, 2);
                        break;
                    case '3':
                        ChangeConfidence(15, 3);
                        break;
                    case '4':
                        ChangeConfidence(1, 1);
                        break;
                    case '5':
                        ChangeConfidence(1, 1);
                        break;
                    case '6':
                        ChangeConfidence(5, 2);
                        break;
                    case '7':
                        ChangeConfidence(1, 1);
                        break;
                    case '8':
                        ChangeConfidence(-1, -1);
                        break;
                    case '9':
                        ChangeConfidence(-1, 0);
                        break;
                }
                if (chosenDir == '8')
                    makeEnemy();
                else
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
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.green;
                chosenDir = transform.GetChild(i).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.ToString()[0];
                Debug.Log(chosenDir);
            }
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
        int randomNumber = Random.Range(0, 9);

        while (generatedNumbers.Contains(randomNumber))
        {
            randomNumber = Random.Range(0, 9);
        }

        generatedNumbers.Add(randomNumber);

        return randomNumber;
    }
    private void DisableBubbles()
    {
        for (int i = 0; i < GetComponentsInChildren<SpriteRenderer>().Length + 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void ChangeConfidence(int currentDown, int maxUp)
    {
        PlayerPrefs.SetInt("Confidence", PlayerPrefs.GetInt("Confidence") - currentDown);
        PlayerPrefs.SetInt("maxConfidence", PlayerPrefs.GetInt("maxConfidence") + maxUp);
    }
    private void makeFriend()
    {
        GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color - new Color(0.2f, 0, 0.2f, 0);

        PlayerPrefs.SetFloat("Red" + SceneManager.GetActiveScene().name + transform.name, GetComponent<SpriteRenderer>().color.r);
        PlayerPrefs.SetFloat("Green" + SceneManager.GetActiveScene().name + transform.name, GetComponent<SpriteRenderer>().color.g);
        PlayerPrefs.SetFloat("Blue" + SceneManager.GetActiveScene().name + transform.name, GetComponent<SpriteRenderer>().color.b);
    }

    private void makeEnemy()
    {
        GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color - new Color(0f, 0.2f, 0.2f, 0);

        PlayerPrefs.SetFloat("Red" + SceneManager.GetActiveScene().name + transform.name, GetComponent<SpriteRenderer>().color.r);
        PlayerPrefs.SetFloat("Green" + SceneManager.GetActiveScene().name + transform.name, GetComponent<SpriteRenderer>().color.g);
        PlayerPrefs.SetFloat("Blue" + SceneManager.GetActiveScene().name + transform.name, GetComponent<SpriteRenderer>().color.b);
    }
}