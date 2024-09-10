using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeExperiencia : MonoBehaviour
{   
    [Header("Stats")]
    [SerializeField] private PersonajeStats stats;

    [Header("Config")]
    [SerializeField] private int nivelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int valorIncremental;

    private float expActualTemp;
    private float expRequeridaSiguienteNivel;
    private float expActual;

    // Start is called before the first frame update
    void Start()
    {
        stats.Nivel = 1;
        expRequeridaSiguienteNivel = expBase;
        stats.ExpRequeridaSiguienteNivel = expRequeridaSiguienteNivel;
        ActualizarBarraExperiencia();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AgregarExperiencia(2f);
        }
    }

    public void AgregarExperiencia(float expObtenida) //Agrega experiencia después de un combate
    {
        if (expObtenida > 0f)
        {
            float expRestanteNuevoNivel = expRequeridaSiguienteNivel - expActualTemp;
            
            if (expObtenida >= expRestanteNuevoNivel) 
            {
                expObtenida -= expRestanteNuevoNivel;
                expActual += expObtenida;
                ActualizarNivel();
                AgregarExperiencia(expObtenida); // Llamada recursiva para agregar la experiencia actualizada
            }
            else
            {
                expActualTemp += expObtenida;
                expActual += expObtenida;

                if (expActualTemp == expRequeridaSiguienteNivel)
                {
                    ActualizarNivel();
                }
            }
        }

        stats.ExpActual = expActual;
        ActualizarBarraExperiencia();
    }

    private void ActualizarNivel()
    {
        if (stats.Nivel < nivelMax)
        {
            stats.Nivel++;
            expActualTemp = 0f;
            expRequeridaSiguienteNivel *= valorIncremental;
            stats.ExpRequeridaSiguienteNivel = expRequeridaSiguienteNivel;
            stats.PuntosDisponibles += 3;
        }
    }

    private void ActualizarBarraExperiencia()
    {
        UIManager.Instance.ActualizarExpPersonaje(expActualTemp, expRequeridaSiguienteNivel);
    }
}
