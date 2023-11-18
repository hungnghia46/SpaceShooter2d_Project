using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getScore : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       this.GetComponent<TextMeshProUGUI>().text = GetComponent<ScoreManager>().txtScore.ToString();
    }
}
