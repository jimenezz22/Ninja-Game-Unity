using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMana : MonoBehaviour
{
    [SerializeField] private float escudoInicial;
    [SerializeField] private float escudoMaximo;
    [SerializeField] private float regeneracionPorSegundo;

    public float EscudoActual { get; private set; }

    private CharacterLife _characterLife;

    private void Awake()
    {
        _characterLife = GetComponent<CharacterLife>();
    }

    void Start()
    {
        EscudoActual = escudoInicial;
        ActualizarBarraEscudo();

        //Llama a un metodo cada cierto tiempo
        InvokeRepeating(nameof(RegenerarEscudo), 1, 1); //Cada segundo llama a RegenerarEscudo 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UsarEscudo(10f);
        }
    }

    public void UsarEscudo(float cantidad)
    {
        if (EscudoActual >= cantidad)
        {
            EscudoActual -= cantidad;
            ActualizarBarraEscudo();
        }
    }

    private void ActualizarBarraEscudo(){
        UIManager.Instance.ActualizarEscudoPersonaje(EscudoActual, escudoMaximo);
    }

    private void RegenerarEscudo()
    {
        if (_characterLife.Health > 0f && EscudoActual < escudoMaximo) //Si el personaje tiene vida y el escudo no está al máximo
        {
            EscudoActual += regeneracionPorSegundo;
            ActualizarBarraEscudo();
            
        }
    }

    public void RestablecerEscudo()
    {
        EscudoActual = escudoInicial;
        ActualizarBarraEscudo();
    }
}