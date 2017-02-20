using UnityEngine;
using System.Collections;

public class ValoresPanelAcertado : MonoBehaviour {

	public TextMesh tiempoUtilizado;
	public TextMesh puntuacionAlcanzada;
	public ComportamientoMarcador puntos;
	public ComportamientoReloj reloj;

	public ComportamientoSonidos accesoASonidos;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable (){
		int tiempoEmpleado;	
		tiempoEmpleado = reloj.tiempoDeJuego - (int)(reloj.tiempoRestante);
		puntuacionAlcanzada.text = puntos.puntuacionPanel.ToString ();
		tiempoUtilizado.text = tiempoEmpleado.ToString ();
	
	}
	}