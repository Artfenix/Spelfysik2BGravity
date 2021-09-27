using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSim : MonoBehaviour {
	// The unit of length used is Earth diameters ≈ 12742 km
	// The unit of mass used is Earth masses ≈ 5.972×10^24 kg
	// The unit of time used is days ≈ 86400 seconds

	// The gravitational constant ≈ 6.67408×10^-11 m^3 kg^-1 s^-2
	// To convert it into our units: 6.67408*10^-11 m^3 kg^-1 s^-2 / (12742000 m/Earth diameter)^3 * (5.972*10^24 kg/Earth mass) * (86400 s/day)^2 ≈
	// G ≈ 1438 Earth diameters^3 Earth Masses^-1 days^-2

	// The distance to the moon is approximately 385000 km ≈ 30.215 Earth diameters
	// The mass of the moon is approximately 7.340 × 10^22 ≈ 0.0123 Earth masses
	// The initial speed of the moon relative to the Earth is approximately 2*pi*30.215 Earth diameters / (27+1/3) days ≈ 6.942 Earth diameters/day


	public float G;
	public bool gravityEnabled = true;
	public float gravityMultiplier = 1;
	public float timeScale = 1;
	public float updatesPerSecond = 50;
	public int delay = 2;

	public List<MoonBehaviour> moons;

	private Vector3 _gravDir;
	private float _timeStep;
	private float _accumulator;

	// Start is called before the first frame update
	void Start() {
		// Center the system
		Vector3 totalMomentum = Vector3.zero;
		float totalMass = 0;

		foreach (var moon in moons) {
			totalMomentum += moon.velocity * moon.mass;
			totalMass += moon.mass;
		}

		Vector3 totalVelocity = totalMomentum / totalMass;

		foreach (var moon in moons) {
			moon.velocity -= totalVelocity;
		}
	}

	// Update is called once per frame
	void Update() {
		if (delay > 0) {
			delay--;
			return;
		}

		_timeStep = 1 / updatesPerSecond;
		_accumulator += Time.deltaTime * timeScale * updatesPerSecond;
		while (_accumulator >= 1) {
			_accumulator--;
			CalculateVector();
		}
	}

	void CalculateVector() {
		if (gravityEnabled) {
			for (int i = 0; i < moons.Count; i++) {
				for (int j = i + 1; j < moons.Count; j++) {
					MoonBehaviour moon0 = moons[i];
					MoonBehaviour moon1 = moons[j];

					_gravDir = moon1.transform.position - moon0.transform.position;
					float r = _gravDir.magnitude;

					_gravDir = gravityMultiplier * G * _gravDir.normalized / (r * r);

					moon0.velocity += _gravDir * _timeStep * moon1.mass;
					moon1.velocity -= _gravDir * _timeStep * moon0.mass;
				}
			}
		}

		foreach (var moon in moons) {
			moon.transform.position += moon.velocity * _timeStep;
		}
	}
	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, _gravDir);

		for (int i = 0; i < moons.Count; i++) {
			for (int j = i + 1; j < moons.Count; j++) {
				Gizmos.color = Color.cyan;
				Gizmos.DrawLine(moons[i].transform.position, moons[j].transform.position);
			}
		}
	}

	public void ToggleGravity() {
		gravityEnabled = !gravityEnabled;
	}

	public void ResetTransforms() {
		foreach (var moon in moons) {
			moon.ResetTransform();
		}
	}
}
