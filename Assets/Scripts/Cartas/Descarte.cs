using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class Descarte : EspacioCarta
{
    public override void ColocarCarta()
    {
        Carta cartaSeleccionada = MovimientoCartas.instancia.cartaSeleccionada;

        if (cartaSeleccionada != null)
        {
            Destroy(cartaSeleccionada.gameObject);
            MovimientoCartas.instancia.DeseleccionarCarta();
        }
    }
}
