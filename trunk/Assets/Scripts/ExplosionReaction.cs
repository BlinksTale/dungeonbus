using UnityEngine;
using System.Collections;

public class ExplosionReaction : MonoBehaviour {

	void OnEnable() {
		Grenade.Explosion += ExplosionListener;
	}

	void OnDisable() {
		Grenade.Explosion -= ExplosionListener;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ExplosionListener(float explosionForce, Vector3 explosionPosition, float explosionRadius) {
		rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
	}
}
