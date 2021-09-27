using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonMass : MonoBehaviour {
	public Slider slider;
	public Text text;
	public MoonBehaviour moon;

	public void SetMoonMass(float m) {
		text.text = "Moon Mass: " + m;
		slider.value = m;
		moon.SetMass(m);
	}
}
