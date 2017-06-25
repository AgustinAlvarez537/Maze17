using UnityEngine;
using System.Collections;

public class AbrirPuerta1 : MonoBehaviour {

	public GameObject usuario;

	public float rango = 2f;
	public float sensibilidad = 0.7f;
	bool seMovio = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!seMovio) {
			float distanceX = usuario.transform.position.x - gameObject.transform.position.x;
			float distanceY = usuario.transform.position.y - gameObject.transform.position.y;
			float distanceZ = usuario.transform.position.z - gameObject.transform.position.z;
			if (Mathf.Abs (distanceX) <= rango && Mathf.Abs (distanceY) <= rango && Mathf.Abs (distanceZ) <= rango) {
				if (- sensibilidad >= Input.acceleration.z) {
					gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 100, gameObject.transform.position.z);
					seMovio = true;
				}
			}
		}
	}
}
