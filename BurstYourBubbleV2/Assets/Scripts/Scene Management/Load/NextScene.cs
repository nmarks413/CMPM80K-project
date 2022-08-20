using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(SceneManager.GetActiveScene().name == "Bedroom")
        {
            SceneManager.LoadScene("School Hallway", LoadSceneMode.Single);
        }
    }
}
