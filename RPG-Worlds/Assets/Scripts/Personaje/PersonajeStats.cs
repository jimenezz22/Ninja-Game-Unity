using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class PersonajeStats : ScriptableObject
{   
    [Header("Stats")]
    public float Danio = 5f;
    public float Defensa = 2f;
    public float Velocidad = 5f;
    public float Nivel;
    public float ExpActual;
    public float ExpRequeridaSiguienteNivel;
    [Range(0f, 100)] public float PorcentajeCritico;
    [Range(0f, 100)] public float PorcentajeBloqueo;

    [Header("Atributos")]
    public int Fuerza;
    public int Destreza;
    public int Inteligencia;

    [HideInInspector] public int PuntosDisponibles;

    public void AgregarBonusPorAtributoFuerza()
    {
        Danio += 2f;
        Defensa += 1f;
        PorcentajeBloqueo += 0.03f;
    }

    public void AgregarBonusPorAtributoInteligencia()
    {
        Danio += 3f;
        PorcentajeCritico += 0.2f;
    }

    public void AgregarBonusPorAtributoDestreza()
    {
        Velocidad += 0.1f;
        PorcentajeBloqueo += 0.05f;
        
    }

    public void ResetearValores()
    {
        Danio = 5f;
        Defensa = 2f;
        Velocidad = 5f;
        Nivel = 1;
        ExpActual = 0f;
        ExpRequeridaSiguienteNivel = 0f;
        PorcentajeCritico = 0f;
        PorcentajeBloqueo = 0f;
        Fuerza = 0;
        Destreza = 0;
        Inteligencia = 0;
        PuntosDisponibles = 0;
    }
}
