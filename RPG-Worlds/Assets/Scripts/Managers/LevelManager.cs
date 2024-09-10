using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    [SerializeField] private Transform puntoReaparicion;

    [SerializeField] private Personaje personaje;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (personaje.CharacterLife.Derrotado)
            {
                personaje.transform.localPosition = puntoReaparicion.position; //set the position of the character to the respawn point
                personaje.RevivirPersonaje();
            }
        }
    }
}