using UnityEngine;
using System.Collections;

public class GeneradorImagenes : MonoBehaviour {

	public GameObject [] imagenes;
	// Use this for initialization
	void Start () {
	
		generarImagenes ();
		generarImagenes1 ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void generarImagenes (){
		if (ComprobadorJuegoPantallaInicial.juega == false) {

			Instantiate (imagenes [Random.Range (0, imagenes.Length)], new Vector3 (0f, 4f, -42f), Quaternion.identity);
			Invoke ("generarImagenes", Random.Range (5f, 8f));
		}
		}
	public void generarImagenes1 (){
		if (ComprobadorJuegoPantallaInicial.juega == false) {
			
			Instantiate (imagenes [Random.Range (0, imagenes.Length)], new Vector3 (0f, -1f, -42f), Quaternion.identity);
			Invoke ("generarImagenes1", Random.Range (5f, 8f));
		}
	}


}
