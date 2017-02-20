using UnityEngine;
using System.Collections;

public class BotonActivoPaneles : MonoBehaviour {

	public ControladorPanelesInicio panelJuegos;
	public ControladorSonidosInicio sonidosInicio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown (){
			panelJuegos.activoCamaraPaneles ();
		
	}

}
