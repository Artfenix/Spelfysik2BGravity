using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centerOfGravity = Vector3.zero;
        float totalMass = 0;
        float maxDist = 0;

        foreach (var moon in PhysicsSim.moons) {
            centerOfGravity += moon.transform.position * moon.mass;
            totalMass += moon.mass;
		}

        foreach (var moon0 in PhysicsSim.moons) {
            foreach (var moon1 in PhysicsSim.moons) {
                maxDist = Mathf.Max(maxDist, (moon1.transform.transform.position - moon0.transform.transform.position).magnitude);
            }
        }

        transform.position = centerOfGravity / totalMass + Vector3.up * 2 * maxDist;
    }
}
