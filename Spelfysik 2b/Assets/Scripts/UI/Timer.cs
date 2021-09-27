using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeScale = 1;
    private Text text;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t += timeScale * Time.deltaTime;
        text.text = "Time: " + t.ToString();
    }
}
