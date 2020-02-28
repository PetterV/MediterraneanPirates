using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    TextMeshProUGUI sailSpeedDisplay;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UIController");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
        sailSpeedDisplay = GameObject.Find("SailSpeedDisplay").GetComponent<TextMeshProUGUI>();
        UpdateSailSpeedDisplay(0);
    }

    public void UpdateSailSpeedDisplay(int value){
        sailSpeedDisplay.text = value.ToString();
    }
}
