using UnityEngine;
using System.Collections;

public class BotonPause : MonoBehaviour {
	public GameObject botonPlay;
	public GameObject botonPause;
	public ComprobadorCarta noActivos;
	public ComprobacionCartaAvanzada noVisibles;
	public GeneradorFrases accesoFrase;
	// boolena para comprobar si ha sido pulsado. 
	public ComportamientoSonidos accesoSonido;
	public static bool pauseActivado;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown (){

		botonPause.SetActive (false);
		botonPlay.SetActive (true);
		pauseActivado = true;
		accesoSonido.cuentaAtras ();
		Time.timeScale = 0f;
		int i = 0;
		if (ComprobacionCartaAvanzada.panelAvanzado == true){
			for (i=0; i<12; i++) {
			noVisibles.elementosVisibles [i].SetActive (false);
			noVisibles.elementosOcultos [i].SetActive (false);
				}
			for (i=0;i<6;i++){
				noVisibles.nombreElemento[i].SetActive(false);
			}
		}
		if (ComprobacionCartaAvanzada.panelAvanzado == false && GeneradorFrases.panelAvanzado == false) {
			for (i=0; i<12; i++) {
				noActivos.elementosVisibles [i].SetActive (false);
				noActivos.elementosOcultos [i].SetActive (false);
			}
		}
		if (GeneradorFrases.panelAvanzado == true) {
			accesoFrase.pausoElementos();

}

		// fin de metodo
		}

}