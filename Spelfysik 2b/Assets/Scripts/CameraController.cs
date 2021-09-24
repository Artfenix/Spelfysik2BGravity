using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public MoonBehaviour transform0;
    public MoonBehaviour transform1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = 2 * (transform1.transform.position - transform0.transform.position).magnitude;

        transform.position = (transform1.transform.position * transform1.mass - transform0.transform.position * transform0.mass) / (transform0.mass + transform1.mass) + Vector3.up * dist;
    }
}
