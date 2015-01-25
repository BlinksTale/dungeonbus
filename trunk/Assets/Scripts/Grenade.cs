using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	public delegate void ExplosionNotification(float explosionForce, Vector3 explosionPosition, float explosionRadius);
	public static ExplosionNotification Explosion;

	private float explosionTime = 1f;
	private float force = 10f * 1000f;
	private float radius = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (explosionTime > 0f)
		{
			explosionTime -= Time.deltaTime;
			
			if (explosionTime <= 0f) {
				Explode();
			}
		}
	}

	void Explode() {
		if (Explosion != null) {
			Explosion(force, this.transform.position, radius);
		}
		GameObject explosion = Instantiate(Resources.Load ("Explosion")) as GameObject;
		explosion.transform.position = this.transform.position;
		explosion.transform.eulerAngles = this.transform.eulerAngles;

		Destroy(this.gameObject);
	}
}
	