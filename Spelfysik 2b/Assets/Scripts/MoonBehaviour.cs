using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBehaviour : MonoBehaviour
{
    public MoonBehaviour earthPos;

    // TODO: EXPLAIN THE UNITS AND EQUATIONS USED

    public float mass;
    public float G;
    private Vector3 gravDir;
    public float r;
    public Vector3 velocity;
    public bool gravityEnabled = true;
    public float timeScale = 1;
    public float updatesPerSecond = 50;
    private float timeStep;
    private float accumulator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeStep = 1 / updatesPerSecond;
        accumulator += Time.deltaTime * timeScale;
        while (accumulator >= timeStep)
        {
            accumulator -= timeStep;
            CalculateVector();
        }
    }

    void CalculateVector()
    {
        if (gravityEnabled)
        {
            gravDir = earthPos.transform.position - transform.position;
            r = gravDir.magnitude;

            gravDir = G * gravDir.normalized * earthPos.mass / (r * r);

            velocity += gravDir * timeStep;
        }

        transform.position += velocity * timeStep;
    }
    private void OnDrawGizmos()
    {
        if (earthPos != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, earthPos.transform.position);
            //Gizmos.DrawRay(transform.position, gravDir * 10);
        }
    }

    public void Toggle()
    {
        gravityEnabled = !gravityEnabled;
    }
}
