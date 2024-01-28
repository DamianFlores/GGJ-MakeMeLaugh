using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovimientoCartas : MonoBehaviour
{
    public static MovimientoCartas instancia;

    public Camera camara;
    public float velocidadCarta = 10;
    public Carta cartaSeleccionada;
    public LayerMask capaDestinoCartas;

    public Vector2 posicionInicial;

    private void Awake()
    {
        instancia = this;

        Carta.AlCliquear += SetCartaSeleccionada;
    }

    private float DistanciaCartaAMouse(Carta carta) => Vector2.Distance(carta.transform.position, Input.mousePosition);

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

        if (distanciaACarta > 0.1f)
        {
            //float velocidadActual = velocidadCarta * distanciaACarta;
            //Vector3 posicionObjetivo = Input.mousePosition;
            //cartaSeleccionada.transform.position = Vector3.MoveTowards(cartaSeleccionada.transform.position, posicionObjetivo, velocidadActual * Time.deltaTime);

            float velocidadActual = velocidadCarta * distanciaACarta;
            Vector3 posicionObjetivo = camara.ScreenToWorldPoint(Input.mousePosition);
            cartaSeleccionada.transform.position = Vector3.MoveTowards(cartaSeleccionada.transform.position, posicionObjetivo, velocidadActual * Time.deltaTime);
        }
        cartaSeleccionada.transform.position = Vector2.MoveTowards(cartaSeleccionada.transform.position, Input.mousePosition, velocidadCarta * Time.deltaTime);
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
        var rayo = camara.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayo, out var hit, 1000f))
        {
            Debug.Log("Golpea");

            var espacio = hit.transform.GetComponent<EspacioCarta>();
            if (espacio)
                return espacio;
        }

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
        DeseleccionarCarta();
    }
}
