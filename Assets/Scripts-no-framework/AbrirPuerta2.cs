using UnityEngine;
using System.Collections;

public class AbrirPuerta2 : MonoBehaviour {

	public GameObject usuario;

	public float rango = 2f;
	public float sensibilidad = 0.7f;
	bool seMovio = false;
	bool reconociArriba = false;
	bool reconociAbajo = false;
	bool reconociendo = false;
	[Header("Tiempo máximo para reconocer el gesto")]
	public float tiempoMax= 5f;
	float tiempoMaximoParaReconocerGesto=5f;
	bool insideZone = false;

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		reconociendo = true;
		reconociArriba = false;
		reconociAbajo = false;

	}

	void Update(){
		if (!seMovio) {
			float distanceX = usuario.transform.position.x - gameObject.transform.position.x;
			float distanceY = usuario.transform.position.y - gameObject.transform.position.y;
			float distanceZ = usuario.transform.position.z - gameObject.transform.position.z;
			if (Mathf.Abs (distanceX) <= rango && Mathf.Abs (distanceY) <= rango && Mathf.Abs (distanceZ) <= rango) {
				if (!insideZone) 
				{
					usuario.GetComponent<TextMesh> ().text = "INSIDE ZONE";
					insideZone = true;
				}
				if (Time.time >= tiempoMaximoParaReconocerGesto) {
					reconociendo = false;
					reconociArriba = false;
					reconociAbajo = false;
				}

				if (Input.gyro.rotationRateUnbiased.x > sensibilidad && !reconociArriba)
					reconociendo = true;

				if (!reconociendo)
					tiempoMaximoParaReconocerGesto = Time.time + tiempoMax;
				else {
					if (!reconociArriba && Time.time < tiempoMaximoParaReconocerGesto) {
						if (Input.gyro.rotationRateUnbiased.x > sensibilidad) {// reconocí el primer movimiento de la cabeza hacia arriba dentro del tiempo permitido
							reconociendo = true;
							reconociArriba = true;
							if (usuario.GetComponent<TextMesh> ().text != null) { 
								usuario.GetComponent<TextMesh> ().text = "arriba Reconocido";
							}
						}
					} else if (Input.gyro.rotationRateUnbiased.x < -sensibilidad && !reconociAbajo && Time.time < tiempoMaximoParaReconocerGesto) { // reconocí el primer movimiento de la cabeza hacia abajo dentro del tiempo permitido
						reconociAbajo = true;
						usuario.GetComponent<TextMesh> ().text = "abajo Reconocido";
					} else if (Input.gyro.rotationRateUnbiased.x > sensibilidad && Time.time < tiempoMaximoParaReconocerGesto && reconociAbajo) {// reconocí el segundo movimiento de la cabeza hacia arriba dentro del tiempo permitido
						reconociArriba = false;
						reconociAbajo = false;
						reconociendo = false;
						if (usuario.GetComponent<TextMesh> ().text != null) { 
							usuario.GetComponent<TextMesh> ().text = "Yes Reconocido";
						}
						gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - 100, gameObject.transform.position.z);
						seMovio = true;
					}

				}
			}
		}
	}
}
