using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class OnTransitionLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetString("gameState")) {
            case "Awake":
                AudioSource bus = gameObject.AddComponent<AudioSource>();
                bus.clip = Resources.Load<AudioClip>("Audio/Transitions/bus");
                AudioSource kids = gameObject.AddComponent<AudioSource>();
                kids.clip = Resources.Load<AudioClip>("Audio/Transitions/kids");
                bus.volume = 0.5f;
                kids.volume = 0.5f;
                bus.Play();
                kids.Play();
                StartCoroutine(Coroutine(new AudioSource[] { bus,kids}, 4f));
                break;
            case "School Hallway":
                break;
        }
    }
    IEnumerator Coroutine(AudioSource[] asource,float t)
    {
        
        yield return new WaitForSeconds(t);
        for (int i = 0; i < asource.Length; i++)
        {
            asource[i].Stop();
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
