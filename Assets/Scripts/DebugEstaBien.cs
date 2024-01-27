using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEstaBien : MonoBehaviour
{
    

    [ContextMenu("Usar carta")]
    public void UsarCarta()
    {
        var carta = FindObjectOfType<Carta>();
        var espectador = FindObjectOfType<Espectador>();
        espectador.AplicarEfecto(carta);
    }
}
