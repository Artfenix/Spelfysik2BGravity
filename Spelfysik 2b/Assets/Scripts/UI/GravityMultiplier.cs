using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityMultiplier : MonoBehaviour {
    public Text text;
    public PhysicsSim sim;

    public void SetGravity(float f) {
        text.text = "Gravity Multiplier:" + f;
        sim.gravityMultiplier = f;
    }
}
