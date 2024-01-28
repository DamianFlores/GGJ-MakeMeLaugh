using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCartas : MonoBehaviour
{
    public static MovimientoCartas instancia;

    public Camera camara;
    public float velocidadCarta = 10;
    public Carta cartaSeleccionada;

    public Vector2 posicionInicial;

    private void Awake()
    {
        instancia = this;

        Carta.AlCliquear += SetCartaSeleccionada;
    }

    private float DistanciaCartaAMouse(Carta carta) => Vector2.Distance(carta.transform.position, camara.ScreenToWorldPoint(Input.mousePosition));

    void Update()
    {
        if (cartaSeleccionada == null)
            return;

        if (Input.GetMouseButtonUp(0))
            SoltarCarta();
        else
            MoverCarta();
    }

    private void MoverCarta()
    {
        float distanciaACarta = DistanciaCartaAMouse(cartaSeleccionada);

        float velocidadActual = velocidadCarta * distanciaACarta;
        Vector3 posicionObjetivo = camara.ScreenToWorldPoint(Input.mousePosition);
        posicionObjetivo.z = cartaSeleccionada.transform.position.z;
        cartaSeleccionada.transform.position = Vector3.MoveTowards(cartaSeleccionada.transform.position, posicionObjetivo, velocidadActual * Time.deltaTime);
        
    }

    private void SoltarCarta()
    {
        var destino = BuscarDestinoParaCarta();

        if (destino)
            destino.ColocarCarta();
        else
            DevolverAMano();
    }

    private EspacioCarta BuscarDestinoParaCarta()
    {
        return null;
    }

    public void SetCartaSeleccionada(Carta carta)
    {
        posicionInicial = carta.transform.position;
        cartaSeleccionada = carta;
        cartaSeleccionada.Seleccionar();
    }

    public void DeseleccionarCarta()
    {
        cartaSeleccionada.Deseleccionar();
        cartaSeleccionada = null;
    }

    public void DevolverAMano()
    {
        cartaSeleccionada.transform.position = posicionInicial;
    }
}
