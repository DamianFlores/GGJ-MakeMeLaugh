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

    private List<RaycastResult> IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results;
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
        var objetos = IsPointerOverUIObject();

        if (objetos.Count > 0 && objetos[0].gameObject.CompareTag("Soltar Carta"))
        {
            var descarte = objetos[0].gameObject.GetComponentInParent<Descarte>();
            if (descarte)
                return descarte;

            var combo = objetos[0].gameObject.GetComponentInParent<Combo>();
            if (combo && combo.PuedeAgregar(cartaSeleccionada))
                return combo;
        }

        return null;
    }

    public void SetCartaSeleccionada(Carta carta)
    {
        posicionInicial = carta.transform.position;
        cartaSeleccionada = carta;
        cartaSeleccionada.DesactivarRaycast();
    }

    public void DeseleccionarCarta()
    {
        cartaSeleccionada = null;
    }

    public void DevolverAMano()
    {
        cartaSeleccionada.transform.position = posicionInicial;
        cartaSeleccionada.ActivarRaycast();
        DeseleccionarCarta();
    }
}
