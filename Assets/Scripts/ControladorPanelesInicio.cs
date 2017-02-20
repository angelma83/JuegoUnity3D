using UnityEngine;
using System.Collections;

public class ControladorPanelesInicio : MonoBehaviour {

	public GameObject camaraNombre;
	public GameObject camaraPaneles;
	private ControladorSonidosInicio accesoSonidos;
	public ComprobadorJuegoPantallaInicial accesoPanel;

	public TextMesh exclamacion;
	public TextMesh memory;
	public TextMesh kids;
	public TextMesh email;
	public TextMesh	nombre;
	public TextMesh	twitter;
	public TextMesh textoJugar;
	public TextMesh textoNombre;
	public TextMesh textoTwuit;
	public TextMesh textoEmail;
	// Use this for initialization
	private int tiempoEnPantalla;
	private bool muestroTitulo;
	private bool muestroNombre;
	private bool muestroEmail;
	private bool muestroTwuit;
	private bool muestroJuego;
	private bool audioTitulo;

	void Start () {
	
		accesoSonidos = GetComponent<ControladorSonidosInicio>();
		exclamacion.GetComponent<Renderer>().enabled = false;
		memory.GetComponent<Renderer>().enabled = false;
		kids.GetComponent<Renderer>().enabled = false;
		email.GetComponent<Renderer>().enabled = false;
		nombre.GetComponent<Renderer>().enabled = false;
		twitter.GetComponent<Renderer>().enabled = false;
		textoJugar.GetComponent<Renderer>().enabled = false;
		textoNombre.GetComponent<Renderer>().enabled = false;
		textoEmail.GetComponent<Renderer>().enabled = false;
		textoTwuit.GetComponent<Renderer>().enabled = false;
		tiempoEnPantalla = 0;


	}
	
	// Update is called once per frame
	void Update () {
	
		if (BotonPulsadoFinJuego.tiempoJugado == true) {
			activoCamaraPaneles();
		} else {
			tiempoEnPantalla = (int)(Time.time);
			muestroElementos ();
				}
	}

	void muestroElementos (){

		if (tiempoEnPantalla == 1 && audioTitulo == false){
			accesoSonidos.audioTitulo ();
			audioTitulo = true;
		}
		if (tiempoEnPantalla == 2 && muestroTitulo == false) {
		kids.GetComponent<Renderer>().enabled = true;
		memory.GetComponent<Renderer>().enabled = true;
		exclamacion.GetComponent<Renderer>().enabled = true;
		muestroTitulo = true;
		}

		if (tiempoEnPantalla == 3 && muestroNombre == false) {
			accesoSonidos.audioNombre ();
			nombre.GetComponent<Renderer>().enabled = true;
			textoNombre.GetComponent<Renderer>().enabled = true;
			muestroNombre = true;
		}

		if (tiempoEnPantalla == 4 && muestroEmail == false) {
			accesoSonidos.audioEmail ();
			email.GetComponent<Renderer>().enabled = true;
			textoEmail.GetComponent<Renderer>().enabled = true;
			muestroEmail = true;
		}

		if (tiempoEnPantalla == 5 && muestroTwuit == false) {
			accesoSonidos.audioTwuit ();
			twitter.GetComponent<Renderer>().enabled = true;
			textoTwuit.GetComponent<Renderer>().enabled = true;
			muestroTwuit = true;
		}

		if (tiempoEnPantalla == 6 && muestroJuego == false) {
			accesoSonidos.audioJuego ();
			textoJugar.GetComponent<Renderer>().enabled = true;
			muestroJuego = true;
		}

	}

	public void activoCamaraPaneles (){

		camaraNombre.SetActive (false);
		camaraPaneles.SetActive (true);
		BotonPulsadoFinJuego.tiempoJugado = false;
		accesoPanel.comprueboElementosPanel ();
		}
}
