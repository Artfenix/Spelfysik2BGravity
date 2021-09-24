using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScale : MonoBehaviour
{
    public Text text;
    public MoonBehaviour moon;
    public MoonBehaviour earth;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTimeScale(float f)
    {
        text.text = "Time Scale: " + f;
        moon.timeScale = f;
        earth.timeScale = f;
        timer.timeScale = f;
    }
}
