using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public struct Datos
    {
        public int gracia, ofensa;
        public Categoria categoria;
    }

    private List<Carta> cartas = new List<Carta>();

    private int rondasRestantes;

    public static event System.Action<Combo> Ejecutar;

    private void Awake()
    {
        Juego.AlPasarDeRonda += AlPasarDeRonda;
    }

    public void Agregar(Carta c)
    {
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
