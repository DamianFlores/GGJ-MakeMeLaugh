using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    public static Juego Instancia;

    public Barra uiGracia, uiIndignacion;

    public static event System.Action AlPasarDeRonda;

    private int puntajeGracia, puntajeIndignacion;

    public int graciaFinal, indignacionFinal;

    public GameObject cartelVictoria, cartelDerrota;

    private bool terminado;

    void Start()
    {
        Instancia = this;
    }

    public void PasarDeRonda()
    {
        //Bajar humor del público
        //Rellenar mano

        AlPasarDeRonda?.Invoke();

    }

    public int Gracia
    {
        set
        {
            puntajeGracia = value;
            uiGracia.Valor = 1f * puntajeGracia / graciaFinal;

            if (puntajeGracia > graciaFinal && !terminado)
                Ganar();
        }
        get => puntajeGracia;
    }

    public int Indignacion
    {
        set
        {
            puntajeIndignacion = value;
            uiIndignacion.Valor = 1f * puntajeIndignacion / indignacionFinal;


            if (puntajeIndignacion > indignacionFinal && !terminado)
                Perder();
        }
        get => puntajeIndignacion;
    }

    private void Ganar()
    {
        cartelVictoria.SetActive(true);
        terminado = true;
    }

    private void Perder()
    {
        cartelDerrota.SetActive(true);
        terminado = true;
    }
}
