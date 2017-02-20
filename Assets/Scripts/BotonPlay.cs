using UnityEngine;
using System.Collections;

public class BotonPlay : MonoBehaviour {

	public GameObject botonPause;
	public GameObject botonPlay;
	public ComprobadorCarta siActivos;
	public ComprobacionCartaAvanzada siVisibles;
	public GeneradorFrases accesoFrase;
	public ComportamientoSonidos accesoSonidos;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown (){

	Time.timeScale = 1f;
	botonPause.SetActive (true);
	botonPlay.SetActive (false);
	BotonPause.pauseActivado = false;
	accesoSonidos.cuentaAtras ();
	// metodo que compruebe lo acertado o no para hacerlo visible. 
	if (ComprobacionCartaAvanzada.panelAvanzado == true) {
		siVisibles.reinicioNombreElemento ();
		siVisibles.comprueboCartaAcertada ();
	}
	if (ComprobacionCartaAvanzada.panelAvanzado == false && GeneradorFrases.panelAvanzado == false) {
		siActivos.comprueboCartaAcertada ();
		}
	if (GeneradorFrases.panelAvanzado == true) {
			accesoFrase.activoElementos();

		}

	}

}
