using UnityEngine;
using System.Collections;

public class MoverObjeto : MonoBehaviour {

    public void rotar() {

    }

    public void desaparecer() {
        transform.position = new Vector3(0, -50, 0);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(90, 0, 0);
    }
}
