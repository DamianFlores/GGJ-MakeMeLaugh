using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCartas : MonoBehaviour
{
    public static MovimientoCartas instancia;

    public float velocidadCarta = 10;
    public Carta cartaSeleccionada;

    public Vector2 posicionInicial;

    private void Awake()
    {
        instancia = this;

        Carta.AlCliquear += SetCartaSeleccionada;
    }

    private float DistanciaCartaAMouse(Carta carta) => Vector2.Distance(carta.transform.position, Input.mousePosition);

    void Update()
    {
        if (cartaSeleccionada != null)
        {
            float distanciaACarta = DistanciaCartaAMouse(cartaSeleccionada);

            if (distanciaACarta > 0.1f)
            {
                float velocidadActual = velocidadCarta * distanciaACarta;
                Vector3 posicionObjetivo = Input.mousePosition;
                cartaSeleccionada.transform.position = Vector3.MoveTowards(cartaSeleccionada.transform.position, posicionObjetivo, velocidadActual * Time.deltaTime);
            }
            cartaSeleccionada.transform.position = Vector2.MoveTowards(cartaSeleccionada.transform.position, Input.mousePosition, velocidadCarta * Time.deltaTime);
        }
    }

    public void SetCartaSeleccionada(Carta carta)
    {
        posicionInicial = carta.transform.position;
        cartaSeleccionada = carta;
    }

    public void DeseleccionarCarta()
    {
        cartaSeleccionada = null;
    }

    public void DevolverAMano()
    {
        cartaSeleccionada.transform.position = posicionInicial;
    }
}
