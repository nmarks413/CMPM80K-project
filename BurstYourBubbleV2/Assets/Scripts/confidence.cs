using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class confidence : MonoBehaviour
{
    private Image bar;
    private int conf;
    private int MaxConf;
    // Start is called before the first frame update
    void Start()
    {
        MaxConf = 100;
        bar = GameObject.Find("ConfidenceBar").gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        conf = PlayerPrefs.GetInt("Confidence");
        bar.fillAmount = (float)conf / (float)MaxConf;
    }
}
