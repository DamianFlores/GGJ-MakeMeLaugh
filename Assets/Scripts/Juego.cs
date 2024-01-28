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
        }
        get => puntajeGracia;
    }

    public int Indignacion
    {
        set
        {
            puntajeIndignacion = value;
            uiIndignacion.Valor = 1f * puntajeIndignacion / indignacionFinal;
        }
        get => puntajeIndignacion;
    }
}
