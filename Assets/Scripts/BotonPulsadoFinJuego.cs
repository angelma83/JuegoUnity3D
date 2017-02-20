using UnityEngine;
using System.Collections;

public class BotonPulsadoFinJuego : MonoBehaviour {

	public static bool tiempoJugado;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown (){
		tiempoJugado = true;
		ControladorPaneles.tiempoEnPanel = 0f;
		Application.LoadLevel ("PantallaInicio");

	}
}
