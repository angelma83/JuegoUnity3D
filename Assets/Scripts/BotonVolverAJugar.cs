using UnityEngine;
using System.Collections;

public class BotonVolverAJugar : MonoBehaviour {

	// Use this for initialization
	public ControladorPaneles muestroPanel;
	public ComportamientoSonidos accesoSonido;
	public static bool pulsado;


	void Start () {
		pulsado = false;
	}
	
	// Update is called once per frame
	void Update () {

			}

	void OnMouseDown (){
		pulsado = true;
		if (ComprobadorJuegoPantallaInicial.panelBasicoBol == true && ComprobadorJuegoPantallaInicial.panelBasico != 2) {
			ComprobadorJuegoPantallaInicial.panelBasico++;
		}
		if (ComprobadorJuegoPantallaInicial.PanelAvanzado1Bol == true) {
			ComprobadorJuegoPantallaInicial.panelAvanzado++;
		}
		ControladorPaneles.tiempoEnPanel = 0f;
		accesoSonido.paroSonidoPanelAcertado ();
		//accesoSonido.vuelvoAJugar ();
		muestroPanel.continuoJugando ();

	}


}
