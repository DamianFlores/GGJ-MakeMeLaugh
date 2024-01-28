using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descarte : MonoBehaviour
{
    public void DescartarCarta()
    {
        Carta cartaSeleccionada = MovimientoCartas.instancia.cartaSeleccionada;

        if (cartaSeleccionada != null)
        {
            Destroy(cartaSeleccionada.gameObject);
            MovimientoCartas.instancia.DeseleccionarCarta();
        }
    }
}
