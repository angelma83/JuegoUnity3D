using UnityEngine;
using System.Collections;

public class ComportamientoSonidos : MonoBehaviour {


	// sonidos paneles de juego
	public AudioClip tocoBoton;
	public AudioClip aciertoImagen;
	public AudioClip falloImagenes;

	// sonidos panel Acertado.
	public AudioClip sonidoAplausos;


	// sonidos panel Fin de Juego
	public AudioClip sonidoRecord;
	public AudioClip sonidoNoRecord;

	public AudioClip aciertoFrase;

	// palabras de animales. 
	public AudioClip [] sonidosPalabras;

	// cuenta atras de fin de juego. 
	public AudioClip tiempoFin;

	// Use this for initialization
	void Start () {
			
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void impactoBoton (){
		GetComponent<AudioSource>().clip = tocoBoton;
		GetComponent<AudioSource>().Play();
	}

	public void cuentaAtras (){

		//audio.PlayOneShot(tiempoFin, 1.0f);
		if (BotonPause.pauseActivado == true && ComportamientoReloj.inicioCuentaAtras == true ) {
			GetComponent<AudioSource>().Pause ();
		} 
		if (BotonPause.pauseActivado == true && ComportamientoReloj.inicioCuentaAtras == false) {
			GetComponent<AudioSource>().Pause ();
		} 
		if (BotonPause.pauseActivado == false && ComportamientoReloj.inicioCuentaAtras == true ) {
			GetComponent<AudioSource>().PlayOneShot (tiempoFin, 1.0f);
		}  
	}

	public void falloBoton (){
		// cargo sonido de fallo imagenes. 
		StartCoroutine (esperoTiempoFallo(0.0f));
	}

	public void aciertoBoton (){
		// cargo sonido aciertoImagen
		StartCoroutine (esperoTiempoAcierto(0.0f));
	}

	// mostramos panel cuando acierta el panel de jugabildad
	public void panelAcertado (){
		GetComponent<AudioSource>().clip = sonidoAplausos;
		GetComponent<AudioSource>().Play ();
	}

	// para el sonido de aplausos cuando pulsan dicho panel. 
	public void paroSonidoPanelAcertado (){
		GetComponent<AudioSource>().Stop ();
	}


	public void aciertoExpresion (){
		GetComponent<AudioSource>().clip = aciertoFrase;
		GetComponent<AudioSource>().Play();
	}


	public void sonidoRecordPanelFin (){
		GetComponent<AudioSource>().clip = sonidoRecord;
		GetComponent<AudioSource>().Play ();
	}

	public void sonidoNoRecordPanelFin (){
		GetComponent<AudioSource>().clip = sonidoNoRecord;
		GetComponent<AudioSource>().Play ();
	}

	IEnumerator esperoTiempoAcierto (float tiempoEspera){
//		yield return new WaitForSeconds (tiempoEspera);
		if (ComprobacionCartaAvanzada.panelAvanzado == true) {
			GetComponent<AudioSource>().clip = sonidosPalabras [ComprobacionCartaAvanzada.elementoDetectado];
			GetComponent<AudioSource>().Play ();
			yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length);
			ComprobacionCartaAvanzada.palabraItem = false;
		} else {
			GetComponent<AudioSource>().clip = sonidosPalabras [ComprobadorCarta.elementoDetectado];
			GetComponent<AudioSource>().Play ();
			yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length);
			ComprobadorCarta.palabraItem = false;
		}
	}

	IEnumerator esperoTiempoFallo (float tiempoEspera){
		GetComponent<AudioSource>().clip = falloImagenes;
		GetComponent<AudioSource>().Play ();
		yield return new WaitForSeconds (GetComponent<AudioSource>().clip.length);
		if (ComprobacionCartaAvanzada.panelAvanzado == true) {
			ComprobacionCartaAvanzada.palabraItem = false;
		} else {
			ComprobadorCarta.palabraItem = false;
		}
	}
}
