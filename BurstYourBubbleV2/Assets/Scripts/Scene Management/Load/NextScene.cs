using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(gameObject.name);
        
        switch(PlayerPrefs.GetString("gameState"))
        {
            case "Awake":
                StartCoroutine(wait("Transition","School Hallway",4f));
                PlayerPrefs.SetString("gameState","School Hallway");
                break;
            case "School Hallway":
                if (gameObject.name == "Door")
                {
                    StartCoroutine(wait("Transition", "Classroom", 1f));
                    PlayerPrefs.SetString("gameState", "Classroom");
                }
                break;
            case "Classroom":
                StartCoroutine(wait("Transition","School Hallway",1f));
                PlayerPrefs.SetString("gameState", "School Hallway2");
                break;
            case "School Hallway2":
                if(gameObject.name == "maroon_double")
                StartCoroutine(wait("Transition", "Lunch", 1f));
                PlayerPrefs.SetString("gameState", "Lunch");
                break;
            case "Lunch":
                StartCoroutine(wait("Transition", "School Hallway", 1f));
                PlayerPrefs.SetString("gameState", "School Hallway3");
                break;
            case "School Hallway3":
                StartCoroutine(wait("Transition", "Bedroom", 1f));
                PlayerPrefs.SetString("gameState", "Home");
                break;
        }
    }
    IEnumerator wait(string s1,string s2,float t)
    {
        SceneManager.LoadScene(s1, LoadSceneMode.Additive);
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(s2,LoadSceneMode.Single);
    }
    
    

    
}
