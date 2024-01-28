using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EspacioCarta : MonoBehaviour
{
    public Carta cartaAsignada;
    public void ColocarCarta()
    {
        Carta cartaSeleccionada = MovimientoCartas.instancia.cartaSeleccionada;

        if (cartaSeleccionada != null)
        {
            cartaAsignada = cartaSeleccionada;
            MovimientoCartas.instancia.DeseleccionarCarta();
            cartaAsignada.transform.DOMove(transform.position, 0.2f).SetEase(Ease.OutQuad);
        }
    }
}
