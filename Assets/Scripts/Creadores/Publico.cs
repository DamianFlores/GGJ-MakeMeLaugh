using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publico : MonoBehaviour
{
    public Listas listas;
    private Espectador[] espectadores;

    void Start()
    {
        espectadores = GetComponentsInChildren<Espectador>();

        var categorias = listas.categorias;
        foreach (var e in espectadores)
        {
            var datos = DatosEspectador.CrearAlAzar(categorias);
            e.Iniciar(datos);
        }
    }

    private void ClickCarta(Carta carta)
    {

    }


}
