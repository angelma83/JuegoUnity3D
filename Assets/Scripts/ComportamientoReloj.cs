using UnityEngine;
using System.Collections;

public class ComportamientoReloj : MonoBehaviour {


	public int tiempoDeJuego;
	public float tiempoRestante;
	public 	float tiempoTranscurrido;
	public TextMesh marcadorReloj;

	public ControladorPaneles panelVisible;
	public ComportamientoSonidos emisionSonidos;

	public static bool inicioCuentaAtras;


	// Use this for initialization
	void Start () {
		// tiempo en panel. 
		tiempoDeJuego = 60;

		inicioCuentaAtras = false;

	}
	// Update is called once per frame
	void Update () {

		tiempoRestante = tiempoDeJuego - Time.time + ComprobadorJuegoPantallaInicial.tiempoEnMenu + ControladorPaneles.tiempoEnPanel; 
		if (tiempoRestante > 0.0) {
			if (tiempoRestante <5.0 && inicioCuentaAtras == false){
				inicioCuentaAtras = true;
				emisionSonidos.cuentaAtras();
				}
			muestraTiempoNumerico ();
		} else {
			panelVisible.finJuego();
			inicioCuentaAtras = false;
			ComprobacionCartaAvanzada.panelAvanzado = false;
			}
		// fin de metodo
		}

	void muestraTiempoNumerico (){

		int minutos=0;
		int segundos=0;;
		string tiempo= "";

		minutos = (int)tiempoRestante/60;
		segundos = (int)tiempoRestante % 60;
		tiempo = minutos.ToString() + ":";
		tiempo +=segundos.ToString ("D2");
		marcadorReloj.text = tiempo;
		}
}