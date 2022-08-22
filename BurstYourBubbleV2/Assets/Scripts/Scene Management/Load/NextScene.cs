using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        switch(PlayerPrefs.GetString("gameState"))
        {
            case "Awake":
                //DontDestroyOnLoad(this.transform.parent.gameObject);
                StartCoroutine(wait("Transition","School Hallway",4f));
                PlayerPrefs.SetString("GameState","School Hallway");
                break;
            case "":
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
