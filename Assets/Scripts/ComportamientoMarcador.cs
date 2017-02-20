using UnityEngine;
using System.Collections;

public class ComportamientoMarcador : MonoBehaviour {

	public int puntuacionPanel;
	public int puntuacionInicial;
	public int puntuacionMaxima;
	public TextMesh marcador;
	// Use this for initialization
	void Start () {

		puntuacionMaxima = PlayerPrefs.GetInt ("puntuacionMaxima", 0);

		puntuacionInicial = 0;
		puntuacionPanel = puntuacionInicial;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void modificacionPuntuacion (int puntos){

		puntuacionPanel += puntos;
		marcador.text = puntuacionPanel.ToString ();
	}

}