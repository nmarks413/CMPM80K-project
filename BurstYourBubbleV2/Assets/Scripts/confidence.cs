using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confidence : MonoBehaviour
{
    private int conf;

    // Start is called before the first frame update
    void Start()
    {
        conf = PlayerPrefs.GetInt("Confidence");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
