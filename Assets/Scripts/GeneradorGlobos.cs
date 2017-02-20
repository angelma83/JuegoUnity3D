using UnityEngine;
using System.Collections;

public class GeneradorGlobos : MonoBehaviour {

	public GameObject [] globos;
	// Use this for initialization
	void Start () {

		//GenerarGlobos ();
		}
	
	// Update is called once per frame
	void Update () {

	}
	public void iniciarParametros(){

		GenerarGlobos ();
	}

	void GenerarGlobos (){
		if ( BotonVolverAJugar.pulsado== false){
		Instantiate (globos [Random.Range (0, globos.Length)], new Vector3(15f,50.45f,1f), Quaternion.identity);
		Invoke("GenerarGlobos", Random.Range(5f, 8f));

		Instantiate (globos [Random.Range (0, globos.Length)], new Vector3(16f,47.21f,1f), Quaternion.identity);
		Invoke("GenerarGlobos", Random.Range(4f, 10f));

		Instantiate (globos [Random.Range (0, globos.Length)], new Vector3(19f,41.25f,1f), Quaternion.identity);
		Invoke("GenerarGlobos", Random.Range(7f, 15f));

		}

	}

	}
	
