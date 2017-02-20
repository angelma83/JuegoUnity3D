using UnityEngine;
using System.Collections;

public class ComprobadorElementos : MonoBehaviour {

	private GeneradorFrases accesoFrases;
	private ComportamientoMarcador accesoMarcador;
	public ComportamientoSonidos accesoSonidos;

	bool [] fraseAfirmativa;
	bool [] fraseInterrogativa;
	bool [] posicionOcupadaFraseAfirmativa;
	bool [] posicionOcupadaFraseInterrogativa;
	// variables para detectar qeu carta es pulsada desde pantalla
	// ya sea tocada con el raton o con la mano. 
	RaycastHit pulsador;
	Ray rayo;
	bool pulsaste;

	void Start () {
		accesoFrases = GetComponent<GeneradorFrases> ();
		accesoMarcador = GetComponent<ComportamientoMarcador>();
		//accesoFrases.creoElementosBasicos ();
		inicioValores ();
	}

	public void inicioValores (){
		// accedo a clase donde creamos los parametros en pantalla
		accesoFrases.iniciarParametros ();
		fraseAfirmativa = new bool[5];
		fraseInterrogativa = new bool [6];
		posicionOcupadaFraseAfirmativa = new bool[5];
		posicionOcupadaFraseInterrogativa = new bool[6];
}

	void Update () {

		if (Input.GetMouseButtonDown (0) && pulsaste == false) {
			// tengo la posicion donde he pulsado con el raton. 
			// debo detectar si en esa misma posicion hay carta o no. 
			rayo = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (rayo, out pulsador, 100);
//			muevoElementoEnPanel ();
		}// cierre de if cuando pulso boton
				
	}
	/*
	void muevoElementoEnPanel (){

		if (fraseAfirmativa [0] == false && posicionOcupadaFraseAfirmativa [0] == false) {
			//if (accesoFrases.palabrasMostradas[0]== "Palabras20"){
				print (pulsador.collider.tag);
			//if(pulsador.collider.tag == accesoFrases.palabrasMostradas[0]){
			accesoSonidos.impactoBoton ();
			//if (pulsador.collider.tag = "1A")
			Instantiate(accesoFrases.palabrasMostradas[0],new Vector3((float)(-1.2), (float)(-0.4), (float)(1.6)), Quaternion.identity);
			Instantiate(accesoFrases.palabrasMostradas[1],new Vector3((float)(-1.2), (float)(-0.4), (float)(1.6)), Quaternion.identity);
			//}
		}
	}
*/
	void comprueboAfirmativa (){

	}

	void comprueboInterrogativa (){

	}


}