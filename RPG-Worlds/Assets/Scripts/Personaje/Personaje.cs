using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{   
    [SerializeField] private PersonajeStats stats;
    public CharacterLife CharacterLife { get; private set; } //property to get and set the CharacterLife component

    public PersonajeAnimaciones PersonajeAnimaciones { get; private set; }

    public PersonajeMana PersonajeMana { get; private set; }

    private void Awake()
    {
        CharacterLife = GetComponent<CharacterLife>(); //get the CharacterLife component
        PersonajeAnimaciones = GetComponent<PersonajeAnimaciones>(); //get the PersonajeAnimaciones component
        PersonajeMana = GetComponent<PersonajeMana>(); //get the PersonajeMana component
    }

    public void RevivirPersonaje()
    {
        CharacterLife.RevivirPersonaje(); //restore the health of the character
        PersonajeAnimaciones.RevivirPersonaje(); //revive the character animations
        PersonajeMana.RestablecerEscudo(); //restore the shield of the character
    }

    private void AtributoRespuesta(TipoAtributo tipo)
    {   
        if (stats.PuntosDisponibles <= 0) return; //if there are no points available, return

        switch(tipo)
        {
            case TipoAtributo.Fuerza:
                stats.Fuerza++;
                stats.AgregarBonusPorAtributoFuerza();
                break;
            case TipoAtributo.Destreza:
                stats.Destreza++;
                stats.AgregarBonusPorAtributoDestreza();
                break;
            case TipoAtributo.Inteligencia:
                stats.Inteligencia++;
                stats.AgregarBonusPorAtributoInteligencia();
                break;
        }

        stats.PuntosDisponibles -= 1;
    }

    private void OnEnable()
    {
        AtributoButton.EventoAgregarAtributo += AtributoRespuesta; //subscribe to the event
    }

    private void OnDisable()
    {
        AtributoButton.EventoAgregarAtributo -= AtributoRespuesta; //desubscribe to the event
    }
}
