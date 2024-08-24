using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro; // Importar el namespace de TextMeshPro
using UnityEngine.SceneManagement;
//using Cinemachine;

public class GameManager : MonoBehaviour
{
    /*public AudioSource clip;
    private bool ejecutando;
    private bool cargandoNivel;
    private int indiceNivelInicio;*/

    public static GameManager instancia; // Variables estáticas ingresan a la clase directamente.
    public GameObject VidasUI;
   // public PlayerController player;
    public TMP_Text textoMonedas; // Cambiado de Text a TMP_Text
    public int monedas;
    public TMP_Text guardarPartidaTexto;

    public GameObject panelPausa;
    public GameObject panelGameOver;
    public GameObject panelCarga;
    public GameObject panelTransicion;

   // public CinemachineConfiner2D cinemachineConfiner; // Cambiado a CinemachineConfiner2D

    /*public bool avanzandoNivel;
    public int nivelActual;
    /*public List<Transform> posicionesAvance = new List<Transform>();
    public List<Transform> posicionesRetroceder = new List<Transform>();
    public List<Collider2D> areasCamara = new List<Collider2D>();

    private void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(this.gameObject);
    }

    /* private void Start()
     {
         if (SceneManager.GetActiveScene().name == "Nivel1") // Cambiar nombre escena nivel
         {
             nivelActual = PlayerPrefs.GetInt("indiceNivelInicio");
             indiceNivelInicio = PlayerPrefs.GetInt("indiceNivelInicio");
             PosicionInicialJugador(indiceNivelInicio);
             cinemachineConfiner.m_BoundingShape2D = areasCamara[indiceNivelInicio];
         }
         else if (SceneManager.GetActiveScene().name == "LevelSelect")
         {
             PosicionInicialJugador(0);
         }
     }

     public void ActivarPanelTransicion()
     {
         panelTransicion.GetComponent<Animator>().SetTrigger("Ocultar");
     }

     private void PosicionInicialJugador(int indiceNivelInicio)
     {
         player.transform.position = posicionesAvance[indiceNivelInicio].transform.position;
     }

     public void SetIndiceNivelInicio(int indiceNivelInicio)
     {
         this.indiceNivelInicio = indiceNivelInicio;
         PlayerPrefs.SetInt("indiceNivelInicio", indiceNivelInicio);
     }

     public void AparecerJuego()
     {
         panelTransicion.GetComponent<Animator>().SetTrigger("Aparecer");
     }

     public void DefaulTransicion()
     {
         panelTransicion.GetComponent<Animator>().SetTrigger("Default");
     }

     public void CambiarPosicionJugador()
     {
         if (avanzandoNivel)
         {
             if (nivelActual + 1 < posicionesAvance.Count) // Selector de nivel, si el nivel actual es menor a la posición se puede cambiar de nivel
             {
                 player.transform.position = posicionesAvance[nivelActual + 1].transform.position;
                 cinemachineConfiner.m_BoundingShape2D = areasCamara[nivelActual + 1];
                 player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                 player.GetComponent<Animator>().SetBool("Caminar", false);
                 player.terminandoMapa = false;
             }
         }
         else
         {
             if (posicionesRetroceder.Count > nivelActual - 1)
             {
                 player.transform.position = posicionesRetroceder[nivelActual - 1].transform.position;
                 cinemachineConfiner.m_BoundingShape2D = areasCamara[nivelActual - 1];
                 player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                 player.GetComponent<Animator>().SetBool("Caminar", false);
                 player.terminandoMapa = false;
             }
         }
     }

     public void GuardarPartida()
     {
         float x, y;
         x = player.transform.position.x;
         y = player.transform.position.y;

         int vidas = player.vidas;
         int nombreEscena = nivelActual; // Selecciona el nombre de la escena actual

         PlayerPrefs.SetInt("monedas", monedas);
         PlayerPrefs.SetFloat("x", x);
         PlayerPrefs.SetFloat("y", y);
         PlayerPrefs.SetInt("vidas", vidas);
         PlayerPrefs.SetInt("nivel", nombreEscena); // Usemos por nombre de la escena
         PlayerPrefs.SetInt("indiceNivelInicio", indiceNivelInicio);

         if (!ejecutando)
             StartCoroutine(MostrarTextoGuardado());
     }

     private IEnumerator MostrarTextoGuardado()
     {
         ejecutando = true;
         guardarPartidaTexto.gameObject.SetActive(true);
         yield return new WaitForSeconds(1);
         guardarPartidaTexto.gameObject.SetActive(false);
         ejecutando = false;
     }
    */
    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

    /*public void CargarPartida()
    {
        monedas = PlayerPrefs.GetInt("monedas");
        player.transform.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
        player.vidas = PlayerPrefs.GetInt("vidas");
        textoMonedas.text = monedas.ToString();
        nivelActual = PlayerPrefs.GetInt("nivel");
        cinemachineConfiner.m_BoundingShape2D = areasCamara[nivelActual];
        indiceNivelInicio = PlayerPrefs.GetInt("indiceNivelInicio");

        int vidasADescontar = 3 - player.vidas;
        player.MostrarVidasUI();
        player.ActualizarVIdasUI(vidasADescontar);
    }

    public void ActualizarContadorMonedas()
    {
        monedas++;
        textoMonedas.text = monedas.ToString();
    }*/

    public void PausarJuego()
    {
        Time.timeScale = 0;
        panelPausa.SetActive(true);
    }

    public void DespausarJuego()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void CargarSelector()
    {
        StartCoroutine(CargarEscena());
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }

    /*public void CargarEscena(string escenaACargar)
    {
        StartCoroutine(CargarEscenaCorrutina(escenaACargar));
    }

   /* public IEnumerator CargarEscenaCorrutina(string escenaACargar)
    {
        cargandoNivel = true;
        panelCarga.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(escenaACargar);

        while (!asyncLoad.isDone)
        {
            yield return new WaitForSeconds (10f);
        }

        cargandoNivel = false;
    }*/

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }

   /* public void ContinuarJuego()
    {
        if (PlayerPrefs.GetFloat("x") != 0.0f)
        {
            player.enabled = true;
            CargarPartida();
            panelGameOver.SetActive(false);
        }
    }*/

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void CargarEscenaSelector()
    {
        StartCoroutine(CargarEscena());
    }

    private IEnumerator CargarEscena()
    {
        panelCarga.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelSelect");

        while (!asyncLoad.isDone)
        {
            yield return new WaitForSeconds(10f); 
        }
    }
    /* public void PlaySoundButoon()
     {
         clip.Play();
     }*/
}
