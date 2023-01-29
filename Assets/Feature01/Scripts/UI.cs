using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{

    [SerializeField] TMP_Text health;
    [SerializeField] PolarityManager playerPolarityManager;
   

    // Update is called once per frame
    void Update()
    {


        health.text = playerPolarityManager.CurrentHealth.ToString();


        
    }
}
