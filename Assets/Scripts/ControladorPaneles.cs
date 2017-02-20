using UnityEngine;
using System.Collections;

public class ControladorPaneles: MonoBehaviour {

	public GameObject camaraPrincipal;
	public GameObject camaraPanel;
	public GameObject camaraFin;
	public ComprobadorCarta inicializoJugabilidad;
	public ComprobacionCartaAvanzada inicioJuego;
	public GeneradorFrases reInicioJuego;
	public GeneradorGlobos accesoGlobos;
	public ComportamientoReloj reloj;
	public static float tiempoEnPanel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// se llama desde el controlador de juego cuando el tiempo de panel termino. 
	public void finJuego (){
		camaraPrincipal.SetActive (false);
		camaraFin.SetActive (true);
		}
	// se llama cuando el usuario acierta todas las cartas ocultas
	// y se muestra el panel de aciertos. 
	public void panelAcertado (){
		BotonVolverAJugar.pulsado = false;
		camaraPrincipal.SetActive (false);
		camaraPanel.SetActive (true);
		if (ComprobacionCartaAvanzada.panelAvanzado == false && GeneradorFrases.panelAvanzado == false) {
			accesoGlobos.iniciarParametros ();
		}
		}
	// se llama al metodo cuando se acaba el tiempo y el jugador 
	// quiere continuar jugado. 
	public void vuelvoAlJuego (){
		camaraFin.SetActive (false);
		camaraPrincipal.SetActive (true);
		}
	// se llama a dicho metodo cuando despues de acertar panel el jugador
	// quiere continuar con el panel siguiente. 
	public void continuoJugando (){

		int tiempoEmpleado;
		tiempoEmpleado = reloj.tiempoDeJuego - (int)(reloj.tiempoRestante);
		tiempoEnPanel = Time.time - tiempoEmpleado - ComprobadorJuegoPantallaInicial.tiempoEnMenu;
		camaraPanel.SetActive (false);
		StartCoroutine (muestroPanelEspaciado (0.0f));
		}

	IEnumerator muestroPanelEspaciado (float tiempoEspera) {

		yield return new WaitForSeconds (tiempoEspera);

		if (ComprobacionCartaAvanzada.panelAvanzado == true) {
			inicioJuego.inicioValoresEmpieceJuego ();		
		}
		if (ComprobacionCartaAvanzada.panelAvanzado == false && GeneradorFrases.panelAvanzado == false) {
		inicializoJugabilidad.inicioValoresEmpieceJuego ();
		}
		if (GeneradorFrases.panelAvanzado == true) {
			reInicioJuego.iniciarParametros();
		}
		camaraPrincipal.SetActive (true);

	}

}
