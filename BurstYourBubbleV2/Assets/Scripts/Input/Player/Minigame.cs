
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    private bool questionLoaded;
    private char[] operations;
    int timer;
    int NumberOfQuestions;
    int correctAnswer;
    bool chosen;
    bool inSeat;
    string chosenAns;

    int MaxTime = 900;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Confidence", 20);
        PlayerPrefs.SetInt("TestOver", 0);
        PlayerPrefs.SetString("gameState", "Classroom");
        operations = new char[] { '+', '-', '*' };
        timer = 0;
        inSeat = false;
        DisableBubbles();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(new Vector3(GameObject.Find("Player_chair").transform.position.x, GameObject.Find("Player_chair").transform.position.y),
            new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y));
        //Debug.Log(distance);
        if (!inSeat && Input.GetKeyDown(KeyCode.Space) && distance < 3)
        {
            //Debug.Log("test");
            inSeat = true;
            EnableBubbles();
            SpawnBubbles();
        }
        if (NumberOfQuestions < 5)
        {
            if (inSeat)
            {
                if (timer > MaxTime)
                {
                    // Debug.Log(timer);
                    timer = 0;
                    PlayerPrefs.SetInt("Confidence", PlayerPrefs.GetInt("Confidence") - 3);
                    SpawnBubbles();
                    NumberOfQuestions++;
                    chosen = false;
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
                else if (Input.GetKey(KeyCode.Alpha4))
                {
                    SelectBubble(3);
                    chosen = true;
                }
                if (Input.GetKeyDown(KeyCode.Space) && chosen)
                {

                    if (chosenAns == correctAnswer.ToString())
                    {
                        Debug.Log("test");
                        PlayerPrefs.SetInt("Confidence", PlayerPrefs.GetInt("Confidence") + 3);
                        timer = 0;
                        SpawnBubbles();
                        NumberOfQuestions++;
                        chosen = false;
                    }

                    else
                    {
                        //DisableBubbles();
                    }
                }
                GameObject.Find("Timer").GetComponent<Image>().fillAmount = 1 - (float)timer / MaxTime;
                timer++;
            }
        }
        else
        {
            PlayerPrefs.SetInt("TestOver", 1);
            DisableBubbles();
        }
    }

    private void SpawnBubbles()
    {
        string[] s = generateRandomProblem();
        int correct = Random.Range(0, 3);
        int r = Random.Range(0, 1);
        for (int i = 0; i < 4; i++)
        {

            if (i == correct)
            {
                PopulateBubbles(s[3], i);
            }
            else
            {
                if (r == 1) { PopulateBubbles((System.Int32.Parse(s[3]) + Random.Range(1, 5)).ToString(), i); }
                else { PopulateBubbles((System.Int32.Parse(s[3]) + Random.Range(-5, -1)).ToString(), i); }
            }

        }
        Text middle = GameObject.Find("middle_Bubble").GetComponentInChildren<Text>();
        middle.text = s[0] + s[2] + s[1] + "=" + " ?";
        correctAnswer = System.Int32.Parse(s[3]);
    }
    private string[] generateRandomProblem()
    {
        int r1 = Random.Range(0, 9);
        int r2 = Random.Range(0, 9);
        char operation = operations[Random.Range(0, 2)];
        int o = PerformCalculation(operation, r1, r2);

        return new string[] { r1.ToString(), r2.ToString(), operation.ToString(), o.ToString() };
    }
    private void PopulateBubbles(string randomNumber, int i)
    {
        transform.GetChild(i).GetComponentInChildren<Text>().text = randomNumber;

    }

    private int PerformCalculation(char r, int number1, int number2)
    {
        if (r == '+')
        {
            return number1 + number2;
        }
        else if (r == '-')
        {
            return number1 - number2;
        }
        else if (r == '*')
        {
            return number1 * number2;
        }
        else if (r == '/')
        {
            // Warning: Integer division probably won't produce the result you're looking for.
            // Try using `double` instead of `int` for your numbers.
            return number1 / number2;
        }
        else
        {
            throw new System.ArgumentException("Unexpected operator string: " + r);
        }
    }
    private void SelectBubble(int bubbleIndex)
    {
        for (int i = 0; i < 4; i++)
        {
            if (bubbleIndex == i)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.green;
                //Debug.Log(transform.GetChild(i));
                chosenAns = transform.GetChild(i).GetComponentInChildren<Text>().text;
                //Debug.Log(chosenAns);

            }
            else
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void DisableBubbles()
    {
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void EnableBubbles()
    {
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
