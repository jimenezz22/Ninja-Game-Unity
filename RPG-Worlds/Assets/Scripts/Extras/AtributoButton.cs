using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TipoAtributo
{
    Fuerza,
    Destreza,
    Inteligencia
}

public class AtributoButton : MonoBehaviour
{   
    public static Action<TipoAtributo> EventoAgregarAtributo;

    [SerializeField] private TipoAtributo tipo;

    public void AgregarAtributo()
    {
        EventoAgregarAtributo?.Invoke(tipo); // Invoca el evento y envía el tipo de atributo
    }
}
