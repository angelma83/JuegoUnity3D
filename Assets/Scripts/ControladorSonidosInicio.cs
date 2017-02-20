using UnityEngine;
using System.Collections;

public class ControladorSonidosInicio : MonoBehaviour {

	public AudioClip sonidoTitulo;
	public AudioClip sonidoJuego;
	public AudioClip sonidoElementos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void impactoBoton (){

		// debo poner el sonido del lets go. 
	}

	public void audioTitulo (){
		GetComponent<AudioSource>().clip = sonidoTitulo;
		GetComponent<AudioSource>().Play ();
	}
	public void audioNombre (){
		GetComponent<AudioSource>().clip = sonidoElementos;
		GetComponent<AudioSource>().Play ();
	}
	public void audioEmail (){
		GetComponent<AudioSource>().clip = sonidoElementos;
		GetComponent<AudioSource>().Play ();
	}
	public void audioTwuit (){
		GetComponent<AudioSource>().clip = sonidoElementos;
		GetComponent<AudioSource>().Play ();
	}
	public void audioJuego (){

		GetComponent<AudioSource>().clip = sonidoJuego;
		GetComponent<AudioSource>().volume = 0.4f;
		GetComponent<AudioSource>().Play ();
	}

}
