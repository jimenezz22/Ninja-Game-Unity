using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Math = UnityEngine.Mathf;

public class UIManager : Singleton<UIManager>
{   
    [Header("Stats")]
    [SerializeField] private PersonajeStats stats;

    [Header("Paneles")]
    [SerializeField] private GameObject panelStats;

    [Header("Barra")]
    [SerializeField] private Image vidaPlayer; //Referencia a la imagen de la vida del jugador
    [SerializeField] private Image escudoPlayer; //Referencia a la imagen del escudo del jugador
    [SerializeField] private Image expPlayer; //Referencia a la imagen del escudo del jugador

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP; //Referencia al texto de la vida del jugador
    [SerializeField] private TextMeshProUGUI escudoTMP; //Referencia al texto de la vida del jugador
    [SerializeField] private TextMeshProUGUI expTMP; //Referencia al texto de la vida del jugador
    [SerializeField] private TextMeshProUGUI nivelTMP; //Referencia al texto de la vida del jugador

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI statDanioTMP;
    [SerializeField] private TextMeshProUGUI statDefensaTMP;
    [SerializeField] private TextMeshProUGUI statCriticoTMP;
    [SerializeField] private TextMeshProUGUI statBloqueoTMP;
    [SerializeField] private TextMeshProUGUI statVelocidadTMP;
    [SerializeField] private TextMeshProUGUI statNivelTMP;
    [SerializeField] private TextMeshProUGUI statExpTMP;
    [SerializeField] private TextMeshProUGUI statExpRequeridaTMP;
    [SerializeField] private TextMeshProUGUI atributoFuerzaTMP;
    [SerializeField] private TextMeshProUGUI atributoInteligenciaTMP;
    [SerializeField] private TextMeshProUGUI atributoDestrezaTMP;
    [SerializeField] private TextMeshProUGUI atributosDisponiblesTMP;

    private float vidaActual;
    private float vidaMaxima;
    private float escudoActual;
    private float escudoMaximo;
    private float expActual;
    private float expRequeridaNuevoNivel;

    // Update is called once per frame
    void Update()
    {
        ActualizarUIPersonaje();
        ActualizarPanelStats();
    }

    private void ActualizarUIPersonaje(){

        //Lerp es una función que interpola entre dos valores a lo largo de una fracción de tiempo. Interpolación Lineal

        //this line of code is gradually changing the fillAmount of vidaPlayer from its current value to the ratio of vidaActual to 
        //vidaMaxima at a speed determined by 10f * Time.deltaTime. This could be used, for example, 
        //to gradually decrease a health bar as the player loses health.

        vidaPlayer.fillAmount = Math.Lerp(vidaPlayer.fillAmount, 
        vidaActual / vidaMaxima, 10f * Time.deltaTime);

        //this line of code is setting the text of the vidaTMP object to a string that represents the current health and the 
        //maximum health of the player, separated by a slash.
        //The resulting string will look something like "50 / 100"
        vidaTMP.text = $"{vidaActual} / {vidaMaxima}";

        escudoPlayer.fillAmount = Math.Lerp(escudoPlayer.fillAmount, 
        escudoActual / escudoMaximo, 10f * Time.deltaTime);

        escudoTMP.text = $"{escudoActual} / {escudoMaximo}";

        expPlayer.fillAmount = Math.Lerp(expPlayer.fillAmount, 
        expActual / expRequeridaNuevoNivel, 10f * Time.deltaTime);

        expTMP.text = $"{((expActual/expRequeridaNuevoNivel)*100):F2}%";

        nivelTMP.text = $"Nivel {stats.Nivel}";
    }

    public void ActualizarVidaPersonaje(float vidaActual, float vidaMaxima)
    {
        this.vidaActual = vidaActual;
        this.vidaMaxima = vidaMaxima;
    }  

    public void ActualizarEscudoPersonaje(float escudoActual, float escudoMaximo)
    {
        this.escudoActual = escudoActual;
        this.escudoMaximo = escudoMaximo;
    } 

    public void ActualizarExpPersonaje(float expActual, float expRequeridaNuevoNivel)
    {
        this.expActual = expActual;
        this.expRequeridaNuevoNivel = expRequeridaNuevoNivel;
    }

    private void ActualizarPanelStats()
    {
        if (panelStats.activeSelf) 
        {
            statDanioTMP.text = stats.Danio.ToString();
            statDefensaTMP.text = stats.Defensa.ToString();
            statCriticoTMP.text = $"{stats.PorcentajeCritico}%";
            statBloqueoTMP.text = $"{stats.PorcentajeBloqueo}%";
            statVelocidadTMP.text = stats.Velocidad.ToString();
            statNivelTMP.text = stats.Nivel.ToString();
            statExpTMP.text = stats.ExpActual.ToString();
            statExpRequeridaTMP.text = stats.ExpRequeridaSiguienteNivel.ToString();

            atributoFuerzaTMP.text = stats.Fuerza.ToString();
            atributoInteligenciaTMP.text = stats.Inteligencia.ToString();
            atributoDestrezaTMP.text = stats.Destreza.ToString();
            atributosDisponiblesTMP.text = $"Puntos: {stats.PuntosDisponibles}";
        }
        else 
        {
            return;
        }
    }
}
