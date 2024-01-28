using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Combo : EspacioCarta
{
    public struct Datos
    {
        public int gracia, ofensa;
        public Categoria categoria;
    }

    private List<Carta> cartas = new List<Carta>();

    private int rondasRestantes = 2;

    public static event Action<Combo> Ejecutar;

    public float separacion = 240;

    private void Awake()
    {
        Juego.AlPasarDeRonda += AlPasarDeRonda;
    }
    public override void ColocarCarta()
    {
        Carta cartaSeleccionada = MovimientoCartas.instancia.cartaSeleccionada;

        if (cartaSeleccionada != null)
        {
            cartaAsignada = cartaSeleccionada;
            MovimientoCartas.instancia.DeseleccionarCarta();
            cartaAsignada.DesactivarRaycast();
            cartaAsignada.transform.SetParent(transform);
            cartaAsignada.transform.DOMove(transform.position + Vector3.right * separacion * cartas.Count, 0.2f).SetEase(Ease.OutQuad);
            Agregar(cartaAsignada);
        }
    }

    public bool PuedeAgregar(Carta cartaSeleccionada)
    {
        return cartas.Count > 0 ?
            cartaSeleccionada.datos.categoria == cartas[0].datos.categoria && !cartaSeleccionada.datos.tipo.esInicio :
            cartaSeleccionada.datos.tipo.esInicio;
    }

    public void Agregar(Carta c)
    {
        if (cartas.Count == 0)
            GetComponentInParent<Combos>().AgregarCombo();

        cartas.Add(c);

        Ejecutar?.Invoke(this);

        if (c.datos.tipo.termina)
            Completar();
    }

    public Datos Valor() => new Datos
    {
        gracia = cartas.Sum(c => c.datos.gracia),
        ofensa = cartas.Sum(c => c.datos.ofensa),
        categoria = cartas.Any(c => c == CreadorCarta.Instancia.listas.yuxtaposicion) ?
            CreadorCarta.Instancia.listas.yuxtaposicion :
            cartas.First().datos.categoria
    };

    private void Completar()
    {
        StartCoroutine(Eliminar());
    }

    private IEnumerator Eliminar()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void AlPasarDeRonda()
    {
        if (--rondasRestantes <= 0)
            Caducar();
    }

    private void Caducar()
    {
        //tirar un cartelito

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Juego.AlPasarDeRonda -= AlPasarDeRonda;
    }
}
