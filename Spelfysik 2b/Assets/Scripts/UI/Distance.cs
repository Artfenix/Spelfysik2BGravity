using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public Text text;
    public string pattern = "Distance: {0} km";
    public float multiplier = 12742;

    public MoonBehaviour moon0;
    public MoonBehaviour moon1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format(pattern, (moon1.transform.position - moon0.transform.position).magnitude * multiplier);
    }
}
