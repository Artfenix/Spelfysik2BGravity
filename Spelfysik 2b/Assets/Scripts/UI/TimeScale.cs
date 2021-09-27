using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScale : MonoBehaviour
{
    public Text text;
    public PhysicsSim sim;
    public Timer timer;

    public void SetTimeScale(float f)
    {
        text.text = "Time Scale: " + f;
        sim.timeScale = f;
        timer.timeScale = f;
    }
}
