using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Espectador : MonoBehaviour
{
    public DatosEspectador datos;
    public TextMeshProUGUI texto;

    private void Awake()
    {
        Combo.Ejecutar += AplicarEfecto;
    }

    public  void Iniciar(DatosEspectador datos)
    {
        this.datos = datos;
        ActualizarTexto();
    }

    public void AplicarEfecto(Combo combo)
    {

    }

    public void AplicarEfecto(Carta carta)
    {
        datos.ProcesarEfectoCarta(carta);
        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        var compatibilidades = string.Join('\n', datos.compatibilidades.Select(c => $"<b>{c.Key.name.ToUpper()}</b>\ngracia: {c.Value.aFavor}\nofensa: {c.Value.enContra}\n").ToArray());

        texto.text = $"<size=24>Estado: {datos.humor}</size>\n\n{compatibilidades}";
    }

    private void OnDestroy()
    {
        Combo.Ejecutar -= AplicarEfecto;
    }
}
