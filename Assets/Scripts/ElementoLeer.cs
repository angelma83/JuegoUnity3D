using UnityEngine;
using System.Collections;

public class ElementoLeer : MonoBehaviour {

	public GameObject [] palabras;
	// Use this for initialization
	
	public ComportamientoSonidos accesoSonidos;
	public ControladorPaneles accesoPaneles;
	private ComportamientoMarcador accesoMarcador;
	
	// boolean para saber si la instancia se destruyo. 
	bool [] iAfir;
	
	// variables para eliminar los objetos clonados
	Object elementoInstanciado;
	Object [] instanciaAfirmativa;
	
	// variable para saber si la frase afirmativa esta ok o no. 
	bool fraseAfirmativa;
	
	// para saber donde se ha pulsado
	string [] elementoPulsado;
	
	bool [] posicionOcupada;
	// utilizo entero para saber donde he colocado la imagen. 
	bool [] estructuraFrase;
	
	
	// Use this for initialization
	void Start () {
		accesoMarcador = GetComponent<ComportamientoMarcador> ();
		
	}
	
	
	public void destruyoInstancias(){		
		int i = 0;
		
		for (i=0; i<instanciaAfirmativa.Length; i++) {
			Destroy (instanciaAfirmativa [i]);		
		}
		
		for (i=0; i<palabras.Length; i++){
			palabras[i].transform.position = Vector3.zero;
			palabras[i].SetActive(false);
			palabras[i].GetComponent<Collider>().enabled= true;
		}
	}
	
	public void iniciarParametros(){
		
		instanciaAfirmativa = new Object[3];
		iAfir = new bool [3];
		estructuraFrase = new bool [3];
		elementoPulsado = new string[3];
		posicionOcupada = new bool [3];
		fraseAfirmativa = false;
		
		mostrarEtiquetas ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void comprobarFraseElemento (string elemento){
		if (estructuraFrase[0] == false && posicionOcupada [0] == false) {
			if (elemento == "yes") {
				elementoPulsado [0] = elemento;
				accesoSonidos.impactoBoton ();
				palabras [0].GetComponent<Collider>().enabled = false;
				elementoInstanciado = Instantiate (palabras[0], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				palabras [0].GetComponent<Collider>().enabled = true;
				comprobarPosicionAfirmativa ();
			}
			if (elemento == "doesnot") {
				elementoPulsado [0] = elemento;
				accesoSonidos.impactoBoton ();
				elementoInstanciado = Instantiate (palabras [1], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				comprobarPosicionAfirmativa ();
			}
			if (elemento == "isnot") {
				elementoPulsado [0] = elemento;
				accesoSonidos.impactoBoton ();
				elementoInstanciado = Instantiate (palabras [2], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				comprobarPosicionAfirmativa ();
			}
			if (elemento == "you") {
				elementoPulsado [0] = elemento;
				accesoSonidos.impactoBoton ();
				elementoInstanciado = Instantiate (palabras [3], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				comprobarPosicionAfirmativa ();
			}
			if (elemento == "are") {
				elementoPulsado [0] = elemento;	
				accesoSonidos.impactoBoton ();
				elementoInstanciado = Instantiate (palabras [4], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				comprobarPosicionAfirmativa ();
			}
			if (elemento == "can") {
				elementoPulsado [0] = elemento;
				accesoSonidos.impactoBoton ();
				elementoInstanciado = Instantiate (palabras[5], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				comprobarPosicionAfirmativa ();
			}
			if (elemento == "she") {
				elementoPulsado [0] = elemento;
				accesoSonidos.impactoBoton ();
				elementoInstanciado = Instantiate (palabras [6], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				comprobarPosicionAfirmativa ();
			}
			if (elemento == "is") {
				elementoPulsado [0] = elemento;
				accesoSonidos.impactoBoton ();
				elementoInstanciado = Instantiate (palabras [7], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				comprobarPosicionAfirmativa ();
			}
			if (elemento == "he") {
				elementoPulsado [0] = elemento;
				accesoSonidos.impactoBoton ();
				elementoInstanciado = Instantiate (palabras [8], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				comprobarPosicionAfirmativa ();
			}
		} else {
			if (estructuraFrase[1] == false && estructuraFrase [0] == true && posicionOcupada [0] == true) {
				if (elemento == "yes") {
					elementoPulsado [1] = elemento;
					accesoSonidos.impactoBoton ();
					elementoInstanciado = Instantiate (palabras[0], new Vector3 ((float) (-0.9), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
					comprobarPosicionAfirmativa ();
				}
				if (elemento == "doesnot") {
					elementoPulsado [1] =elemento;
					accesoSonidos.impactoBoton ();
					elementoInstanciado = Instantiate (palabras [1], new Vector3 ((float)(-0.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
					comprobarPosicionAfirmativa ();
					
				}
				if (elemento == "isnot") {
					elementoPulsado [1] = elemento;
					accesoSonidos.impactoBoton ();
					elementoInstanciado = Instantiate (palabras[2], new Vector3 ((float)(-0.9), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
					comprobarPosicionAfirmativa ();
					
				}
				if (elemento == "you") {
					elementoPulsado [1] = elemento;
					accesoSonidos.impactoBoton ();
					elementoInstanciado = Instantiate (palabras[3], new Vector3 ((float)(-0.9), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
					comprobarPosicionAfirmativa ();
					
				}
				if (elemento == "are") {
					elementoPulsado [1] = elemento;
					accesoSonidos.impactoBoton ();
					elementoInstanciado = Instantiate (palabras[4], new Vector3 ((float)(-0.9), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
					comprobarPosicionAfirmativa ();
					
				}
				if (elemento == "can") {
					elementoPulsado [1] = elemento;
					accesoSonidos.impactoBoton ();
					elementoInstanciado = Instantiate (palabras[5], new Vector3 ((float)(-0.75), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
					comprobarPosicionAfirmativa ();
				} 
				if (elemento == "she") {
					elementoPulsado [1] = elemento;
					accesoSonidos.impactoBoton ();
					palabras[6].GetComponent<Collider>().enabled = false;
					elementoInstanciado = Instantiate (palabras[6], new Vector3 ((float)(-1), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
					palabras[6].GetComponent<Collider>().enabled = true;
					comprobarPosicionAfirmativa ();
				}
				if (elemento == "is") {
					elementoPulsado [1] = elemento;
					accesoSonidos.impactoBoton ();
					elementoInstanciado = Instantiate (palabras[7], new Vector3 ((float)(-0.9), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
					comprobarPosicionAfirmativa ();
				}
				if (elemento == "he") {
					elementoPulsado [1] = elemento;
					accesoSonidos.impactoBoton ();
					elementoInstanciado = Instantiate (palabras[8], new Vector3 ((float)(-0.9), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
					comprobarPosicionAfirmativa ();
				}
			} else {
				if (estructuraFrase [2] == false && posicionOcupada [0] == true && posicionOcupada [1] == true) {
					if (elemento == "yes") {
						elementoPulsado [2] = elemento;
						accesoSonidos.impactoBoton ();
						elementoInstanciado = Instantiate (palabras[0], new Vector3 ((float)(-0.2), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
						comprobarPosicionAfirmativa ();
					}
					if (elemento == "doesnot") {
						elementoPulsado [2] = elemento;
						accesoSonidos.impactoBoton ();
						elementoInstanciado = Instantiate (palabras[1], new Vector3 ((float)(0), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
						comprobarPosicionAfirmativa ();
					}
					if (elemento == "isnot") {
						elementoPulsado [2] = elemento;
						accesoSonidos.impactoBoton ();
						elementoInstanciado = Instantiate (palabras[2], new Vector3 ((float)(-0.15), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
						comprobarPosicionAfirmativa ();
					}
					if (elemento == "you") {
						elementoPulsado [2] = elemento;
						accesoSonidos.impactoBoton ();
						elementoInstanciado = Instantiate (palabras[3], new Vector3 ((float)(-0.1), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
						comprobarPosicionAfirmativa ();
					}
					if (elemento == "are") {
						elementoPulsado [2] = elemento;
						accesoSonidos.impactoBoton ();
						elementoInstanciado = Instantiate (palabras[4], new Vector3 ((float)(-0.2), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
						comprobarPosicionAfirmativa ();
					}
					if (elemento == "can") {
						elementoPulsado [2] = elemento;
						accesoSonidos.impactoBoton ();
						palabras[5].GetComponent<Collider>().enabled = false;
						elementoInstanciado = Instantiate (palabras[5], new Vector3 ((float)(-0.2), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
						palabras[5].GetComponent<Collider>().enabled = true;
						comprobarPosicionAfirmativa ();
					}
					if (elemento == "she") {
						elementoPulsado [2] = elemento;
						accesoSonidos.impactoBoton ();
						elementoInstanciado = Instantiate (palabras[6], new Vector3 ((float)(-0.2), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
						comprobarPosicionAfirmativa ();			
					}
					if (elemento == "is") {
						elementoPulsado [2] = elemento;
						accesoSonidos.impactoBoton ();
						elementoInstanciado = Instantiate (palabras[7], new Vector3 ((float)(-0.2), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
						comprobarPosicionAfirmativa ();
					}
					if (elemento == "he") {
						elementoPulsado [2] = elemento;
						accesoSonidos.impactoBoton ();
						elementoInstanciado = Instantiate (palabras[8], new Vector3 ((float)(-0.2), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
						comprobarPosicionAfirmativa ();	
					}
				}
			} // else de 1
		} // else de 0
	} // fin de metodo
	
	void comprobarPosicionAfirmativa (){
		
		GeneradorFrases.pulsaste = true;
		
		
		if (elementoPulsado [0] == "yes" && posicionOcupada [0] == false) {
			estructuraFrase [0] = true;
			posicionOcupada [0] = true;
			instanciaAfirmativa[0] = elementoInstanciado;
			GeneradorFrases.pulsaste = false;
			iAfir[0] = true;
			accesoMarcador.modificacionPuntuacion(2);
		} else {
			if (elementoPulsado [1] == "she" && posicionOcupada [0] == true && posicionOcupada [1] == false) {
				estructuraFrase[1] = true;
				posicionOcupada [1] = true;
				instanciaAfirmativa[1] = elementoInstanciado;
				GeneradorFrases.pulsaste = false;
				iAfir[1] = true;
				accesoMarcador.modificacionPuntuacion(2);
			} else {
				if (elementoPulsado [2] == "can" && posicionOcupada [1] == true && posicionOcupada [2] == false) {
					estructuraFrase[2] = true;
					posicionOcupada [2] = true;
					instanciaAfirmativa[2] = elementoInstanciado;
					GeneradorFrases.pulsaste = false;
					iAfir[2] = true;
					fraseAfirmativa = true;
					accesoSonidos.aciertoExpresion();
					accesoMarcador.modificacionPuntuacion(5);
					inicializaVariables();
					comprobacionPanel();
				} 
				else {
					devuelvoCollider();
					StartCoroutine (devuelvoImagenAPosicion (0.4f)); 
				}
			}
		}
	}
	
	void devuelvoCollider(){
		int i = 0;
		for (i=0; i<9; i++) {
			palabras[i].GetComponent<Collider>().enabled= true;		
		}
	}
	
	void comprobarFraseInterrogativa (){
	}
	
	void comprobacionPanel (){
		GeneradorFrases.pulsaste = false;
		if (fraseAfirmativa == true)
			StartCoroutine(frasesAcertadas(0.7f));
	}
	
	IEnumerator frasesAcertadas ( float tiempoEspera){
		yield return new WaitForSeconds (tiempoEspera);
		accesoPaneles.panelAcertado();
		accesoSonidos.panelAcertado ();
		
	}
	
	IEnumerator devuelvoImagenAPosicion(float tiempoEspera){
		yield return new WaitForSeconds (tiempoEspera);
		GeneradorFrases.pulsaste = false;
		accesoMarcador.modificacionPuntuacion(-1);
		accesoSonidos.falloBoton();
		Destroy (elementoInstanciado);
	}
	
	void inicializaVariables(){
		int j = 0;
		for (j=0; j<3; j++) {
			estructuraFrase[j] = false;
			posicionOcupada [j] = false;
		}
	}
	
	public void pausoElementos (){
		int i = 0;
		
		for (i=0;i<palabras.Length;i++){
			palabras[i].SetActive(false);
		}
		
		for (i=0;i<instanciaAfirmativa.Length;i++){
			Destroy (instanciaAfirmativa[i]);
		}
	}
	
	public void activoElementos (){
		int i = 0;
		// activo palabras a mostrar en parte baja
		for (i=0; i<9; i++) {
			palabras [i].SetActive (true);		
		}
		
		for(i=0;i<3;i++){
			if (iAfir [i] == true && i == 0) {
				palabras [0].GetComponent<Collider>().enabled = false;
				elementoInstanciado = Instantiate (palabras[0], new Vector3 ((float)(-1.7), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				palabras [0].GetComponent<Collider>().enabled = true;
				instanciaAfirmativa [i] = elementoInstanciado;
			}
			if (iAfir [i] == true && i == 1) {
				palabras [3].GetComponent<Collider>().enabled = false;
				elementoInstanciado = Instantiate (palabras[3], new Vector3 ((float)(-1.2), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				palabras[3].GetComponent<Collider>().enabled = true;
				instanciaAfirmativa [i] = elementoInstanciado;
			}
			if (iAfir [i] == true && i == 2) {
				palabras [2].GetComponent<Collider>().enabled = false;
				elementoInstanciado = Instantiate (palabras[2], new Vector3 ((float)(-0.8), (float)(-0.7), (float)(1.6)), Quaternion.identity); 
				palabras [2].GetComponent<Collider>().enabled = true;
				instanciaAfirmativa [i] = elementoInstanciado;
			}
			
		}
	}
	
	
	public void mostrarEtiquetas (){
		int i = 0;
		int posicionEtiqueta = 0;
		int elementoVisible = 0;
		bool[] posicionUsada;
		posicionUsada = new bool[9];
		bool [] elementoUsado;
		elementoUsado = new bool[9];
		
		while (i < 9) {
			// calcula la etiqueta que cargare en dicha posicion. 
			elementoVisible = (int)(8.99*Random.value);
			
			posicionEtiqueta = (int)(8.99*Random.value);
			
			if (posicionEtiqueta == 0 && posicionUsada [0] == false && elementoUsado[elementoVisible] == false) {
				palabras[elementoVisible].SetActive (true);
				palabras[elementoVisible].transform.Translate ((float)(-1.7), (float)(-3.2), (float)(1.6));
				posicionUsada [0] =true;
				elementoUsado [elementoVisible] = true;
				i++;
			}
			if (posicionEtiqueta == 1 && posicionUsada [1] == false && elementoUsado[elementoVisible] == false) {
				palabras[elementoVisible].SetActive (true);
				palabras[elementoVisible].transform.Translate (0, (float)(-3.2), (float)(1.6));
				posicionUsada [1] = true;
				elementoUsado [elementoVisible] = true;
				i++;
			}
			if (posicionEtiqueta == 2 && posicionUsada [2] == false && elementoUsado[elementoVisible] == false) {
				palabras[elementoVisible].SetActive (true);
				palabras[elementoVisible].transform.Translate ((float)(1.7), (float)(-3.2), (float)(1.6));
				posicionUsada [2] = true;
				elementoUsado [elementoVisible] = true;
				i++;
			}
			if (posicionEtiqueta == 3 && posicionUsada [3] == false && elementoUsado[elementoVisible] == false) {
				palabras[elementoVisible].SetActive (true);
				palabras[elementoVisible].transform.Translate ((float)(-1.7), (float)(-3.9), (float)(1.6));
				posicionUsada [3] = true;
				elementoUsado [elementoVisible] = true;
				i++;
			}
			if (posicionEtiqueta == 4 && posicionUsada [4] == false && elementoUsado[elementoVisible] == false) {
				palabras[elementoVisible].SetActive (true);
				palabras[elementoVisible].transform.Translate (0, (float)(-3.9), (float)(1.6));
				posicionUsada [4] = true;
				elementoUsado [elementoVisible] = true;
				i++;
			}
			if (posicionEtiqueta == 5 && posicionUsada [5] == false && elementoUsado[elementoVisible] == false) {
				palabras[elementoVisible].SetActive (true);
				palabras[elementoVisible].transform.Translate ((float)(1.7), (float)(-3.9), (float)(1.6));
				posicionUsada [5] = true;
				elementoUsado [elementoVisible] = true;
				i++;
			}
			if (posicionEtiqueta == 6 && posicionUsada [6] == false && elementoUsado[elementoVisible] == false) {
				palabras[elementoVisible].SetActive (true);
				palabras[elementoVisible].transform.Translate ((float)(-1.7), (float)(-4.5), (float)(1.6));
				posicionUsada [6] = true;
				elementoUsado [elementoVisible] = true;
				i++;
			}
			if (posicionEtiqueta == 7 && posicionUsada [7] == false && elementoUsado[elementoVisible] == false) {
				palabras[elementoVisible].SetActive (true);
				palabras[elementoVisible].transform.Translate (0, (float)(-4.5), (float)(1.6));
				posicionUsada [7] = true;
				elementoUsado [elementoVisible] = true;
				i++;
			}
			if (posicionEtiqueta == 8 && posicionUsada [8] == false && elementoUsado[elementoVisible] == false) {
				palabras[elementoVisible].SetActive (true);
				palabras[elementoVisible].transform.Translate ((float)(1.7), (float)(-4.5), (float)(1.6));
				posicionUsada [8] = true;
				elementoUsado [elementoVisible] = true;
				i++;
			}
		}
	}
}