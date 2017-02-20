using UnityEngine;
using System.Collections;

public class ValoresPanelFin : MonoBehaviour {

	public TextMesh puntuacionMaxima;
	public TextMesh puntuacionAlcanzada;
	public TextMesh mensajeRecord;
	public ComportamientoMarcador puntos;
	public ComportamientoReloj reloj;
	public ComportamientoSonidos accesoSonidos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable (){
	
		if (puntos.puntuacionPanel > puntos.puntuacionMaxima) {
			accesoSonidos.sonidoRecordPanelFin ();
			// actualizamos maxima puntuacion
			PlayerPrefs.SetInt ("puntuacionMaxima", puntos.puntuacionPanel);
			 // asignamos puntuacino panel
			puntuacionAlcanzada.text = puntos.puntuacionPanel.ToString ();
			// asginamos maxima puntuacion			
			puntuacionMaxima.text = puntos.puntuacionPanel.ToString ();
			// ponemos el menseje de records			
			mensajeRecord.text = "RECORD ";
		} else {
			accesoSonidos.sonidoNoRecordPanelFin ();
			// ponemos puntuacion alcanzada
			puntuacionAlcanzada.text = puntos.puntuacionPanel.ToString ();
			// ponemos puntuacion maxima anterior
			puntuacionMaxima.text = puntos.puntuacionMaxima.ToString ();
			// ponemos mensaje de no records. 
			mensajeRecord.text = " NO RECORD ";
			}
	}
}
