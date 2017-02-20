using UnityEngine;
using System.Collections;

public class ComprobadorJuegoPantallaInicial : MonoBehaviour {

	// variables para detectar qeu carta es pulsada desde pantalla
	// ya sea tocada con el raton o con la mano. 
	RaycastHit pulsador;
	Ray rayo;

	// variable tiempo para saber cuando se ha pulsado
	public static float tiempoEnMenu;
		// para acceder a item de sonidos. 
	public ControladorSonidosInicio accesoSonidos;
	public static bool juega;
	bool entre;
	public GameObject nivelAvanzado;
	public GameObject nivelAvanzado1;
	public GameObject nivelAvanzado2;
	// entero para saber si muestro avanzado o no. 
	public static int panelBasico;
	public static int panelAvanzado;
	bool activadoAvanzado1;
	public static bool panelBasicoBol;
	public static bool PanelAvanzado1Bol;
	// Use this for initialization
	void Start () {


	}

	public void comprueboElementosPanel (){


		if (panelBasico > 1 && activadoAvanzado1 == false) {
			nivelAvanzado.SetActive (true); 
			nivelAvanzado1.SetActive (true);
			activadoAvanzado1 = true;
		}
		if (panelAvanzado > 1) {
			nivelAvanzado2.SetActive (true);
		}

	}

	// Update is called once per frame
	void Update () {

		if (BotonPulsadoFinJuego.tiempoJugado == true && entre == false) {
			juega= false;
			accesoSonidos.audioJuego();
			entre = true;
		}
		if (Input.GetMouseButtonDown (0)) {
			// tengo la posicion donde he pulsado con el raton. debo detectar si en esa misma posicion hay carta o no. 
			rayo = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (rayo, out pulsador, 100);
			comprueboPanelJuego ();
			// cierre de if cuando pulso boton
		}
		// cierre fin de clase update. 
	}
	
	// se detecta que cartas han sido pulsadas desde la pantalla. 
	void comprueboPanelJuego (){
	

		// compruebo si la cartaTocada.
		if (pulsador.collider.tag == "PanelAnimal") {
			accesoSonidos.impactoBoton ();
			juega = true;
			entre = false;
			tiempoEnMenu = Time.time;
			panelBasicoBol = true;
			Application.LoadLevel ("PantallaAnimales");
		}

		if (pulsador.collider.tag == "PanelVehiculo") {
			accesoSonidos.impactoBoton ();
			juega = true;
			entre = false;
			tiempoEnMenu = Time.time;
			panelBasicoBol = true;
			Application.LoadLevel ("PantallaVehiculos");
			}

		if (pulsador.collider.tag == "PanelCuerpo") {
			ComprobacionCartaAvanzada.palabraItem = false;
			accesoSonidos.impactoBoton();
			entre = false;
			tiempoEnMenu = Time.time;
			juega = true;
			PanelAvanzado1Bol = true;
			Application.LoadLevel ("PantallaCuerpo");
		}
		if (pulsador.collider.tag == "PanelFruta") {
			ComprobacionCartaAvanzada.palabraItem = false;
			accesoSonidos.impactoBoton();
			tiempoEnMenu = Time.time;
			Application.LoadLevel ("PantallaAvanzada");
		}
		// fin comprobar panel de juego
	}
	

	// fin de clase
}
