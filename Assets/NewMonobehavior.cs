using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonobehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        GUILayout.Label(Environment.GetEnvironmentVariable("JAVA_HOME"));
    }
}
