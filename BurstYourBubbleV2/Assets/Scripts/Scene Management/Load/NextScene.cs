using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(PlayerPrefs.GetString("gameState"));
        
        switch(PlayerPrefs.GetString("gameState"))
        {
            case "Awake":
                StartCoroutine(wait("Transition","School Hallway",4f));
                PlayerPrefs.SetString("gameState","School Hallway");
                break;
            case "School Hallway":
                Debug.Log("test");
                StartCoroutine(wait("Transition","Classroom",1f));
                PlayerPrefs.SetString("gameState","Classroom");
                break;
            case "Classroom":
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
