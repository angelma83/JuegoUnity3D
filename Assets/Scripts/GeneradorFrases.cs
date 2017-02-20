using UnityEngine;
using System.Collections;

public class GeneradorFrases : MonoBehaviour {

	// game object donde cargo los elementos a mostrar 
	public GameObject [] elementosOcultos;


	private ElementoFutbol accesoFutbol;
	private ElementoDormir accesoDormir;
	private ElementoFelices accesoFelices;
	private ElementoLluvia accesoLluvia;
	private ElementoLeer accesoLeer;
	private ElementoHelado accesoHelado;
	private ElementoNoClase accesoNoClase;
	private ElementoPerro accesoPerro;
	private ElementoPinguino accesoPinguino;
	private ElementoTenis accesoTenis;

	// sentencias que aparecen en pantalla. 
	public TextMesh fraseAfirmativaCastellano;


	//acceso a distintas clases para poder acceder a sus elementos
	public ComportamientoSonidos accesoSonidos;
	public ControladorPaneles accesoPaneles;
	private ComportamientoMarcador accesoMarcador;
	public static bool panelAvanzado;
	public bool entreEnElemento;

	// variable que me servira para identificar el elemento que se ha mostrado. 
	public int elementoMostrado;
	// boolean donde compruebo si elemento se ha mostrado ya o no. 
	bool [] elementosVisibles;

	// string elemento que hemso pulsado
	string elementoIncidido;
	// variables para detectar qeu carta es pulsada desde pantalla
	// ya sea tocada con el raton o con la mano. 
	RaycastHit pulsador;
	Ray rayo;
	public static bool pulsaste;
	
	// Use this for initialization
	public void Start () {
		// booleano que sirve para saber si esta foto ha sido ya mostrada. 
		elementosVisibles = new bool[10];
		// accedo a las clases de las imagenes. 
		accesoDormir = GetComponent<ElementoDormir> ();
		accesoFutbol = GetComponent<ElementoFutbol> ();
		accesoFelices = GetComponent<ElementoFelices> ();
		accesoLluvia = GetComponent<ElementoLluvia> ();
		accesoLeer = GetComponent<ElementoLeer> ();
		accesoHelado = GetComponent<ElementoHelado> ();
		accesoNoClase = GetComponent<ElementoNoClase> ();
		accesoPerro = GetComponent<ElementoPerro> ();
		accesoPinguino = GetComponent<ElementoPinguino> ();
		accesoTenis = GetComponent<ElementoTenis> ();
		//		iniciarParametros ();
		accesoMarcador = GetComponent<ComportamientoMarcador>();
		calculoElementoAMostrar ();
		panelAvanzado = true;
							
	}

	public void iniciarParametros(){

		// booleano para saber si estamos en panel avanzado o no
		// nos sirve para los sonidos. 
		panelAvanzado = true;				
		elementosOcultos [elementoMostrado].SetActive (false);
		elementosOcultos [elementoMostrado].transform.position = Vector3.zero;

		switch(elementoMostrado){
		case 0:
			accesoDormir.destruyoInstancias();
			break;
		case 1:
			accesoFutbol.destruyoInstancias();
			break;
		case 2:
			accesoFelices.destruyoInstancias();
			break;
		case 3:
			accesoLluvia.destruyoInstancias();
			break;
		case 4:
			accesoLeer.destruyoInstancias();
			break;
		case 5:
			accesoHelado.destruyoInstancias();
			break;
		case 6:
			accesoNoClase.destruyoInstancias();
			break;
		case 7:
			accesoPinguino.destruyoInstancias();
			break;
		case 8:
			accesoPerro.destruyoInstancias();
			break;
		case 9:
			accesoTenis.destruyoInstancias();
			break;
		default:
		break;
	}
		calculoElementoAMostrar ();
			
	}

	public void pausoElementos(){

			elementosOcultos[elementoMostrado].SetActive (false);
			fraseAfirmativaCastellano.GetComponent<Renderer>().enabled = false;
			switch (elementoMostrado) {
		case 0:
			accesoDormir.pausoElementos();
			break;
		case 1:
			accesoFutbol.pausoElementos();
			break;
		case 2:
			accesoFelices.pausoElementos();
			break;
		case 3:
			accesoLluvia.pausoElementos();
			break;
		case 4:
			accesoLeer.pausoElementos();
			break;
		case 5:
			accesoHelado.pausoElementos();
			break;
		case 6:
			accesoNoClase.pausoElementos();
			break;
		case 7:
			accesoPinguino.pausoElementos();
			break;
		case 8:
			accesoPerro.pausoElementos();
			break;
		case 9:
			accesoTenis.pausoElementos();
			break;
		default:
			break;
		}

		

	}
	public void activoElementos (){
		int i = 0;
		//activo el elemento que mostramos en pantalla
		elementosOcultos [elementoMostrado].SetActive (true);
		// activo etiquetas a mostrar con las frases que deben indicar
		fraseAfirmativaCastellano.GetComponent<Renderer>().enabled = true;

		switch (elementoMostrado) {
		case 0:
			accesoDormir.activoElementos();
			break;
		case 1:
			accesoFutbol.activoElementos();
			break;
		case 2:
			accesoFelices.activoElementos();
			break;
		case 3:
			accesoLluvia.activoElementos();
			break;
		case 4:
			accesoLeer.activoElementos();
			break;
		case 5:
			accesoHelado.activoElementos();
			break;
		case 6:
			accesoNoClase.activoElementos();
			break;
		case 7:
			accesoPinguino.activoElementos();
			break;
		case 8:
			accesoPerro.activoElementos();
			break;
		case 9:
			accesoTenis.activoElementos();
			break;
		default:
			break;
		}
					

	}

	void Update () {

		if (Input.GetMouseButtonDown (0) && pulsaste == false) {
			// tengo la posicion donde he pulsado con el raton. 
			// debo detectar si en esa misma posicion hay carta o no. 
			rayo = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (rayo, out pulsador, 100);
	
			elementoIncidido = pulsador.collider.tag;
		
	
			switch (elementoMostrado) {
			case 0:
				accesoDormir.comprobarFraseElemento(elementoIncidido);
				break;
			case 1:
				accesoFutbol.comprobarFraseElemento(elementoIncidido);
				break;
			case 2:
				accesoFelices.comprobarFraseElemento (elementoIncidido);
				break;
			case 3:
				accesoLluvia.comprobarFraseElemento (elementoIncidido);
				break;
			case 4:
				accesoLeer.comprobarFraseElemento (elementoIncidido);
				break;
			case 5:
				accesoHelado.comprobarFraseElemento (elementoIncidido);
				break;
			case 6:
				accesoNoClase.comprobarFraseElemento (elementoIncidido);
				break;
			case 7:
				accesoPinguino.comprobarFraseElemento (elementoIncidido);
				break;
			case 8:
				accesoPerro.comprobarFraseElemento (elementoIncidido);
				break;
			case 9:
				accesoTenis.comprobarFraseElemento (elementoIncidido);
				break;

			default:
				break;

			}			
		}
	}


	void calculoElementoAMostrar (){

		bool mostreImagen;
		mostreImagen = false;
		while (mostreImagen == false) {
		elementoMostrado = (int)(9 * Random.value);
			if (elementoMostrado == 0 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;	
				elementosOcultos [0].SetActive (true);
				elementosOcultos [0].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Does the tortoise awake?";
				mostreImagen = true;
				accesoDormir.iniciarParametros();
				}
			if (elementoMostrado == 1 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;		
				elementosOcultos [1].SetActive (true);
				elementosOcultos [1].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Do you play football?";
				mostreImagen = true;
				accesoFutbol.iniciarParametros ();
				}
			if (elementoMostrado == 2 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;			
				elementosOcultos [2].SetActive (true);
				elementosOcultos [2].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Are they happy?";
				mostreImagen = true;
				accesoFelices.iniciarParametros ();
				}
			if (elementoMostrado == 3 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;			
				elementosOcultos [3].SetActive (true);
				elementosOcultos [3].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Is it raining?";
				mostreImagen = true;
				accesoLluvia.iniciarParametros ();
				}
			if (elementoMostrado == 4 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;			
				elementosOcultos [4].SetActive (true);
				elementosOcultos [4].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Can she read?";
				mostreImagen = true;
				accesoLeer.iniciarParametros ();
				}
			if (elementoMostrado == 5 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;			
				elementosOcultos [5].SetActive (true);
				elementosOcultos [5].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Do they like ice cream?";
				mostreImagen = true;
				accesoHelado.iniciarParametros ();
				}
			if (elementoMostrado == 6 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;			
				elementosOcultos [6].SetActive (true);
				elementosOcultos [6].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Are they in class?";
				mostreImagen = true;
				accesoNoClase.iniciarParametros ();
				}

			if (elementoMostrado ==7 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;			
				elementosOcultos [7].SetActive (true);
				elementosOcultos [7].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Can the pinguin fly?";
				mostreImagen = true;
				accesoPinguino.iniciarParametros ();
				}
			if (elementoMostrado == 8 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;			
				elementosOcultos [8].SetActive (true);
				elementosOcultos [8].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Is the dog black?";
				mostreImagen = true;
				accesoPerro.iniciarParametros ();
			}
			if (elementoMostrado == 9 && elementosVisibles [elementoMostrado] == false) {
				elementosVisibles [elementoMostrado] = true;			
				elementosOcultos [9].SetActive (true);
				elementosOcultos [9].transform.Translate (0, (float)(2.25), 0);
				fraseAfirmativaCastellano.text = "Does he a tennis player?";
				mostreImagen = true;
				accesoTenis.iniciarParametros ();
			}

		}
		}// fin de metodo

}// fin de clase