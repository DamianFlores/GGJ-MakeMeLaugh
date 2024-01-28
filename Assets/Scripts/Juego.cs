using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    public static Juego Instancia;

    public IndicadorPuntaje uiGracia, uiIndignacion;

    public static event System.Action AlPasarDeRonda;

    private int puntajeGracia, puntajeIndignacion;

    void Start()
    {
        Instancia = this;
    }

    void Update()
    {
        
    }

    public void PasarDeRonda()
    {
        //Bajar humor del público
        //Rellenar mano

        AlPasarDeRonda?.Invoke();
    }
}
