using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBehaviour : MonoBehaviour {
	public float mass;
	public Vector3 velocity;
	public MoonMass text;
	private MoonBehaviour _prefab;

	private void Start() {
		if (_prefab == null) {
			gameObject.SetActive(false);
			_prefab = Instantiate(this);
			gameObject.SetActive(true);
		}
	}

	public void ResetTransform() {
		transform.position = _prefab.transform.position;
		velocity = _prefab.velocity;
		mass = _prefab.mass;
		if (text != null) {
			text.SetMoonMass(mass);
		}
	}

	public void SetMass(float m) {
		mass = m;
	}
}
