using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Bedroom")
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }
        else if (SceneManager.GetActiveScene().name == "School Hallway")
        {
            Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        else if (SceneManager.GetActiveScene().name == "Classroom" || SceneManager.GetActiveScene().name == "Lunch")
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }
    }
}
