using UnityEngine;
using System.Collections;

public class ComprobacionCartaAvanzada : MonoBehaviour {
	public GameObject [] elementosVisibles;
	public GameObject[] elementosOcultos;
	public GameObject[] nombreElemento;
	
	// acceso a GAmeObject con controlador de camara
	// declaro variable para acceder al script de puntuacion
	// como acceder a clases ubicadas en el mismo Game Object. 
	// para acceder al item de marcador
	private ComportamientoMarcador accesoMarcador;
	// para acceder a item de sonidos. 
	public ComportamientoSonidos accesoSonidos;
	// para acceder a item de paneles
	// public por estar en otro GameObject. 
	public ControladorPaneles accesoPaneles;

		
	// variable para ser que sonidos emitir
	public static int elementoDetectado;
	public static bool panelAvanzado;
	public static bool palabraItem;
	
	
	// variables para detectar qeu carta es pulsada desde pantalla
	// ya sea tocada con el raton o con la mano. 
	RaycastHit pulsador;
	Ray rayo;
	
	// iamgenes que utilizare para rellenar los elementosOcultos.
	int [] situadaEnPosicion;
	// contador para saber las cartas que pulsado y hacer comprobacion. 
	int cartasPulsadas = 0;
	// contador de cartas acertadas para detectar cuando gano el panel.
	int cartasAcertadas = 0;
	// declaro variables enteras para saber la cartas que se ha pulsado
	// ayuda a distinguir si son las mismas o no. 
	string [] elementosPulsados;
	int [] posicionDeElementosPulsados;
	bool [] elementosOcultoAcertado;
	string nombrePulsado;

	// Use this for initialization
	public void Start () {
		panelAvanzado = true;
		inicioValoresEmpieceJuego ();
		// acceso a componentes de otro script en mismo gameobject, marcador
		accesoMarcador = GetComponent<ComportamientoMarcador>();
	}
	
	public void inicioValoresEmpieceJuego  (){
		// actualizo los elementos que se deben ver on o
		inicializoVisiblesTrue ();
		inicializoOcultasFalse ();
		// cartas acertadas
		cartasAcertadas = 0;
		// inicializo cartas pulsadas
		cartasPulsadas = 0;
		// indico que no hay pulsado ninguna carta de panel. 
		palabraItem = false;
		// inicializo las posiciones de las imagenes en panel.
		situadaEnPosicion = new int[12];
		// inicializo string con las cartas que han sido pulsadas.
		elementosPulsados = new string[2];
		elementosPulsados [0] = "a";
		posicionDeElementosPulsados = new int[2];
		posicionDeElementosPulsados [0] = -1;
		elementosOcultoAcertado = new bool[12];
		// metodo donde situo las cartas en distintas posiciones. 
		calculoPosicionCartaOculta ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && palabraItem == false) {
			// tengo la posicion donde he pulsado con el raton. debo detectar si en esa misma posicion hay carta o no. 
			rayo = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (rayo, out pulsador, 100);
			cartaTocada ();
		}// cierre de if cuando pulso boton
		if (Input.GetMouseButtonDown (0) && palabraItem == true) {
			// tengo la posicion donde he pulsado con el raton. debo detectar si en esa misma posicion hay carta o no. 
			rayo = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (rayo, out pulsador, 100);
			comprueboNombrePulsado();
		}// cierre de if cuando pulso boton


	}// cierre fin de clase update. 
	
	// se detecta que cartas han sido pulsadas desde la pantalla. 
	public void cartaTocada (){
		// compruebo si la cartaTocada.
		if (pulsador.collider.tag == "CartaVisible1") {
			accesoSonidos.impactoBoton();
			elementosVisibles[0].SetActive (false);
			elementosOcultos[situadaEnPosicion[0]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[0]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[0]].tag;;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=0;
			posicionDeElementosPulsados[1]=0;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible2") {
			accesoSonidos.impactoBoton();
			elementosVisibles[1].SetActive (false);
			elementosOcultos[situadaEnPosicion[1]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[1]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[1]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=1;
			posicionDeElementosPulsados[1]=1;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible3") {
			accesoSonidos.impactoBoton();
			elementosVisibles[2].SetActive (false);
			elementosOcultos[situadaEnPosicion[2]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[2]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[2]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=2;
			posicionDeElementosPulsados[1]=2;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible4") {
			accesoSonidos.impactoBoton();
			elementosVisibles[3].SetActive (false);
			elementosOcultos[situadaEnPosicion[3]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[3]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[3]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=3;
			posicionDeElementosPulsados[1]=3;
			cartasPulsadas++;
			if (cartasPulsadas == 2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible5") {
			accesoSonidos.impactoBoton();
			elementosVisibles[4].SetActive (false);
			elementosOcultos[situadaEnPosicion[4]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[4]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[4]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=4;
			posicionDeElementosPulsados[1]=4;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible6") {
			accesoSonidos.impactoBoton();
			elementosVisibles[5].SetActive (false);
			elementosOcultos[situadaEnPosicion[5]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[5]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[5]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=5;
			posicionDeElementosPulsados[1]=5;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible7") {
			accesoSonidos.impactoBoton();
			elementosVisibles[6].SetActive (false);
			elementosOcultos[situadaEnPosicion[6]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[6]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[6]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=6;
			posicionDeElementosPulsados[1]=6;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible8") {
			accesoSonidos.impactoBoton();
			elementosVisibles[7].SetActive (false);
			elementosOcultos[situadaEnPosicion[7]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[7]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[7]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=7;
			posicionDeElementosPulsados[1]=7;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible9") {
			accesoSonidos.impactoBoton();
			elementosVisibles[8].SetActive (false);
			elementosOcultos[situadaEnPosicion[8]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[8]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[8]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=8;
			posicionDeElementosPulsados[1]=8;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible10") {
			accesoSonidos.impactoBoton();
			elementosVisibles[9].SetActive (false);
			elementosOcultos[situadaEnPosicion[9]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[9]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[9]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=9;
			posicionDeElementosPulsados[1]=9;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible11") {
			accesoSonidos.impactoBoton();
			elementosVisibles[10].SetActive (false);
			elementosOcultos[situadaEnPosicion[10]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[10]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[10]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=10;
			posicionDeElementosPulsados[1]=10;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
		if (pulsador.collider.tag == "CartaVisible12") {
			accesoSonidos.impactoBoton();
			elementosVisibles[11].SetActive (false);
			elementosOcultos[situadaEnPosicion[11]].SetActive (true);
			if (elementosPulsados[0] == "a"){
				elementosPulsados [0] =elementosOcultos[situadaEnPosicion[11]].tag;
			}else{
				elementosPulsados [1] =elementosOcultos[situadaEnPosicion[11]].tag;
			}
			if (posicionDeElementosPulsados[0] == -1)
				posicionDeElementosPulsados[0]=11;
			posicionDeElementosPulsados[1]=11;
			cartasPulsadas++;
			if (cartasPulsadas ==2)
				comprobarIgualdad();
		}
	}

	void muestroPosiblesOpciones (){
		int i = 0;
		// indicara la posicion del tablero donde pondremos la carat oculta. 
		int posicionEnPanel = 0;
		int elementoVisible = 0;
		// inicializo un booleano para comprobar si esa posicino ha sido ocupada o no. 
		bool [] posicionUsada;
		bool [] posicionElementoUsada;
		bool cartaPulsada = false;
		posicionElementoUsada = new bool[6];
		posicionUsada = new bool[3];
			
		// calculo los nombres que se mostraran en pantalla. 
		while (i<3) {
			if (cartaPulsada == false) {
				detectoElementoPulsado ();
				elementoVisible = elementoDetectado;
				cartaPulsada = true;
			} else {
				elementoVisible = (int)(6 * Random.value);
			}
			posicionEnPanel = (int)(3 * Random.value);
			if (posicionEnPanel == 0 && posicionUsada [0] == false && posicionElementoUsada [elementoVisible] == false) {
				nombreElemento [elementoVisible].SetActive (true);
				nombreElemento [elementoVisible].transform.Translate (-2, (float)(-3.5), 0);
				posicionUsada [0] = true;
				posicionElementoUsada [elementoVisible] = true;
				i++;
			}
			if (posicionEnPanel == 1 && posicionUsada [1] == false && posicionElementoUsada [elementoVisible] == false) {
				nombreElemento [elementoVisible].SetActive (true);
				nombreElemento [elementoVisible].transform.Translate (0, (float)(-3.5), 0);
				posicionUsada [1] = true;
				posicionElementoUsada [elementoVisible] = true;
				i++;
			}
			if (posicionEnPanel == 2 && posicionUsada [2] == false && posicionElementoUsada [elementoVisible] == false) {
				nombreElemento [elementoVisible].SetActive (true);
				nombreElemento [elementoVisible].transform.Translate (2, (float)(-3.5), 0);
				posicionUsada [2] = true;
				posicionElementoUsada [elementoVisible] = true;
				i++;
			}
		} // cierre de while
	}

	public void reinicioNombreElemento (){
		int i = 0;
		for (i=0; i<6; i++) {
			nombreElemento[i].SetActive (false);
			nombreElemento[i].transform.position = Vector3.zero;
		}
	}
	void comprueboNombrePulsado(){

		//palabraItem = false;

		if (pulsador.collider.tag == "CartaOculta1") {
			nombrePulsado = pulsador.collider.tag;
			comprueboCartaYPalabra();
		}
		if (pulsador.collider.tag == "CartaOculta2") {
			nombrePulsado = pulsador.collider.tag;
			comprueboCartaYPalabra();
		}
		if (pulsador.collider.tag == "CartaOculta3") {
			nombrePulsado = pulsador.collider.tag;
			comprueboCartaYPalabra();
		}
		if (pulsador.collider.tag == "CartaOculta4") {
			nombrePulsado = pulsador.collider.tag;
			comprueboCartaYPalabra();
		}
		if (pulsador.collider.tag == "CartaOculta5") {
			nombrePulsado = pulsador.collider.tag;
			comprueboCartaYPalabra();
		}
		if (pulsador.collider.tag == "CartaOculta6") {
			nombrePulsado = pulsador.collider.tag;
			comprueboCartaYPalabra();
		}

	}

	void comprueboCartaYPalabra (){

		if (elementosPulsados [0] == nombrePulsado) {
			sonidosElementos ();
			detectoPosicionAcertada ();
			accesoMarcador.modificacionPuntuacion (5);
			inicializoVariables ();
			reinicioNombreElemento ();
			cartasAcertadas = cartasAcertadas + 2;
			if (cartasAcertadas == 12) {
			StartCoroutine (activamosAnteAcierto (0.7f));
			}
		}else {
		accesoSonidos.falloBoton ();
		accesoMarcador.modificacionPuntuacion (-1);
		StartCoroutine (activamosAnteFallo(0.3f));
	}

	}

	void comprobarIgualdad(){

		// ponemos a true para que no vuelva a pulsar a las cartas de arriba. 
		palabraItem = true;

		if (elementosPulsados [0] == elementosPulsados [1]) {
			StartCoroutine (aciertoCartas(0.3f));
			}else {
			accesoSonidos.falloBoton ();
			accesoMarcador.modificacionPuntuacion (-1);
			StartCoroutine (activamosAnteFallo(0.2f));
		}
	}
			
	IEnumerator aciertoCartas (float tiempoEspera){
		yield return new WaitForSeconds (tiempoEspera);
		muestroPosiblesOpciones ();
		palabraItem = true;
		}

	IEnumerator activamosAnteAcierto (float tiempoEspera){
		yield return new WaitForSeconds (tiempoEspera);
		accesoPaneles.panelAcertado ();
		accesoSonidos.panelAcertado ();
	}
	
	IEnumerator activamosAnteFallo(float tiempoEspera){
		int i = 0;
		// probar aqui stop courotine
		yield return new WaitForSeconds (tiempoEspera);
		reinicioNombreElemento ();
		elementosVisibles[posicionDeElementosPulsados[0]].SetActive(true);
		elementosVisibles[posicionDeElementosPulsados[1]].SetActive(true);
		for (i=0; i<12; i++) {
			if (elementosOcultoAcertado [i] != true)
				elementosOcultos[i].SetActive (false);
		}
		inicializoVariables ();
		}
	
	// metodo para inicializar las variables cuando vuelvo a jugar	
	void inicializoVisiblesTrue (){
		int i = 0;
		for (i=0; i<12; i++){
			elementosVisibles [i].SetActive (true);
		}
	}
	// metodo para inicializar las variables cuanndo vuelvo a jugar
	void inicializoOcultasFalse (){
		int i = 0;
		for (i=0; i<12; i++){
			elementosOcultos[i].SetActive(false);
			elementosOcultos[i].transform.position = Vector3.zero;
		}
	}
	
	void inicializoVariables (){
		cartasPulsadas = 0;
		elementosPulsados[0]="a";
		elementosPulsados[1]="a";
		posicionDeElementosPulsados [0] = -1;
		posicionDeElementosPulsados [1] = -1;
		palabraItem = false;
	}
	
	public void comprueboCartaAcertada (){
		inicializoVariables ();
		int i=0;
		for (i=0;i<12;i++){
			if (elementosOcultoAcertado[situadaEnPosicion[i]]== false)
				elementosVisibles[i].SetActive(true);
			else
				elementosOcultos[situadaEnPosicion[i]].SetActive (true);
		}
	}
	
	void detectoPosicionAcertada (){
		if (elementosPulsados[0] == "CartaOculta1")
			elementosOcultoAcertado[0] = true;
		if (elementosPulsados[0] == "CartaOculta1")
			elementosOcultoAcertado[1] = true;
		if (elementosPulsados[0] == "CartaOculta2")
			elementosOcultoAcertado[2] = true;
		if (elementosPulsados[0] == "CartaOculta2")
			elementosOcultoAcertado[3] = true;
		if (elementosPulsados[0] == "CartaOculta3")
			elementosOcultoAcertado[4] = true;
		if (elementosPulsados[0] == "CartaOculta3")
			elementosOcultoAcertado[5] = true;
		if (elementosPulsados[0] == "CartaOculta4")
			elementosOcultoAcertado[6] = true;
		if (elementosPulsados[0] == "CartaOculta4")
			elementosOcultoAcertado[7] = true;
		if (elementosPulsados[0] == "CartaOculta5")
			elementosOcultoAcertado[8] = true;
		if (elementosPulsados[0] == "CartaOculta5")
			elementosOcultoAcertado[9] = true;
		if (elementosPulsados[0] == "CartaOculta6")
			elementosOcultoAcertado[10] = true;
		if (elementosPulsados[0] == "CartaOculta6")
			elementosOcultoAcertado[11] = true;
		if (elementosPulsados[1] == "CartaOculta1")
			elementosOcultoAcertado[0] = true;
		if (elementosPulsados[1] == "CartaOculta1")
			elementosOcultoAcertado[1] = true;
		if (elementosPulsados[1] == "CartaOculta2")
			elementosOcultoAcertado[2] = true;
		if (elementosPulsados[1] == "CartaOculta2")
			elementosOcultoAcertado[3] = true;
		if (elementosPulsados[1] == "CartaOculta3")
			elementosOcultoAcertado[4] = true;
		if (elementosPulsados[1] == "CartaOculta3")
			elementosOcultoAcertado[5] = true;
		if (elementosPulsados[1] == "CartaOculta4")
			elementosOcultoAcertado[6] = true;
		if (elementosPulsados[1] == "CartaOculta4")
			elementosOcultoAcertado[7] = true;
		if (elementosPulsados[1] == "CartaOculta5")
			elementosOcultoAcertado[8] = true;
		if (elementosPulsados[1] == "CartaOculta5")
			elementosOcultoAcertado[9] = true;
		if (elementosPulsados[1] == "CartaOculta6")
			elementosOcultoAcertado[10] = true;
		if (elementosPulsados[1] == "CartaOculta6")
			elementosOcultoAcertado[11] = true;
	}

	void sonidosElementos (){

		if (elementosPulsados [0] == "CartaOculta1")
			elementoDetectado= 0;
		accesoSonidos.aciertoBoton();
		if (elementosPulsados [0] == "CartaOculta2")
			elementoDetectado= 1;
		accesoSonidos.aciertoBoton();
		if (elementosPulsados[0] == "CartaOculta3")
			elementoDetectado= 2;
		accesoSonidos.aciertoBoton();
		if (elementosPulsados[0] == "CartaOculta4")
			elementoDetectado= 3;
		accesoSonidos.aciertoBoton();
		if (elementosPulsados[0] == "CartaOculta5")
			elementoDetectado= 4;
		accesoSonidos.aciertoBoton();
		if (elementosPulsados[0] == "CartaOculta6")
			elementoDetectado= 5;
		accesoSonidos.aciertoBoton();
	}

	void detectoElementoPulsado (){
		if (elementosPulsados [0] == "CartaOculta1")
			elementoDetectado= 0;
		if (elementosPulsados [0] == "CartaOculta2")
			elementoDetectado= 1;
		if (elementosPulsados[0] == "CartaOculta3")
			elementoDetectado= 2;
		if (elementosPulsados[0] == "CartaOculta4")
			elementoDetectado= 3;
		if (elementosPulsados[0] == "CartaOculta5")
			elementoDetectado= 4;
		if (elementosPulsados[0] == "CartaOculta6")
			elementoDetectado= 5;
	}

	
	void calculoPosicionCartaOculta (){
		// inicializo el contador del while
		int i = 0;
		// indicara la posicion del tablero donde pondremos la carat oculta. 
		int posicionEnPanel = 0;
		// inicializo un booleano para comprobar si esa posicino ha sido ocupada o no. 
		bool [] posicionUsada;
		posicionUsada = new bool[12];
		// calculo 
		while (i<12) {
			posicionEnPanel = (int)(12 * Random.value);
			
			if (posicionEnPanel == 0 && posicionUsada [0] == false) {
				elementosOcultos[i].transform.Translate ((float)(-1.6), 3, 0);
				posicionUsada[0]=true;
				situadaEnPosicion[0]= i;
				i++;
			}
			if (posicionEnPanel == 1 && posicionUsada [1] == false) {
				elementosOcultos[i].transform.Translate (0, 3, 0);
				posicionUsada[1]=true;
				situadaEnPosicion[1]= i;
				i++;
			}
			if (posicionEnPanel == 2 && posicionUsada [2] == false) {
				elementosOcultos[i].transform.Translate ((float)(1.6),3, 0);
				posicionUsada[2]=true;
				situadaEnPosicion[2]= i;
				i++;
			}
			if (posicionEnPanel == 3 && posicionUsada [3] == false) {
				elementosOcultos[i].transform.Translate ((float)(-1.6), (float)(1.5), 0);
				posicionUsada[3]=true;
				situadaEnPosicion[3]= i;
				i++;
			}
			if (posicionEnPanel == 4 && posicionUsada [4] == false) {
				elementosOcultos[i].transform.Translate (0, (float)(1.5), 0);
				posicionUsada[4]=true;			
				situadaEnPosicion[4]= i;
				i++;
			}
			if (posicionEnPanel == 5 && posicionUsada [5] == false) {
				elementosOcultos[i].transform.Translate ((float)(1.6),(float)(1.5), 0);
				posicionUsada[5]=true;
				situadaEnPosicion[5]= i;
				i++;
			}
			if (posicionEnPanel == 6 && posicionUsada [6] == false) {
				elementosOcultos[i].transform.Translate ((float)(-1.6),0, 0);
				posicionUsada[6]=true;
				situadaEnPosicion[6]= i;
				i++;
			}
			if (posicionEnPanel == 7 && posicionUsada [7] == false) {
				elementosOcultos[i].transform.Translate (0,0, 0);
				posicionUsada[7]=true;
				situadaEnPosicion[7]= i;
				i++;
			}
			if (posicionEnPanel == 8 && posicionUsada [8] == false) {
				elementosOcultos[i].transform.Translate ((float)(1.6),0, 0);
				posicionUsada[8]=true;
				situadaEnPosicion[8]= i;
				i++;
			}
			if (posicionEnPanel == 9 && posicionUsada [9] == false) {
				elementosOcultos[i].transform.Translate ((float)(-1.6),(float)(-1.5), 0);
				posicionUsada[9]=true;
				situadaEnPosicion[9]= i;
				i++;
			}
			if (posicionEnPanel == 10 && posicionUsada [10] == false) {
				elementosOcultos[i].transform.Translate (0,(float)(-1.5), 0);
				posicionUsada[10]=true;
				situadaEnPosicion[10]= i;
				i++;
			}
			if (posicionEnPanel == 11 && posicionUsada [11] == false) {
				elementosOcultos[i].transform.Translate ((float)(1.6),(float)(-1.5), 0);
				posicionUsada[11]=true;				
				situadaEnPosicion[11]= i;
				i++;
			}
			// fin de while
		}
		
		// fin de metodo
	}
	// fin de la clase
}
