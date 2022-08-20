using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    
    private async void OnCollisionEnter2D(Collision2D collision)
    {
        switch(PlayerPrefs.GetString("GameState"))
        {
            case "Awake":
                AudioSource bus = Resources.Load<AudioSource>("Audio/bus.wav");
                AudioSource kids = Resources.Load<AudioSource>("Audio/kids.wav");
                bus.volume = .5f;
                kids.volume = .5f;
                bus.Play();
                kids.Play();
                await Task.Delay(2000);
                bus.Stop();
                kids.Stop();
                SceneManager.LoadScene("School Hallway", LoadSceneMode.Single);
                break;
            case "":
                break;
        }
    }
}
