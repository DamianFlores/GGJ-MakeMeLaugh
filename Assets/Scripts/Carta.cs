using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Carta : MonoBehaviour
{
    public TextMeshProUGUI titulo, descripcion, valores;
    public Image fondo, iconoTipo, iconoCategoria;
    public DatosCarta datos;

    public static event System.Action<Carta> AlCliquear;

    public void Iniciar(DatosCarta datos)
    {
        this.datos = datos;
        titulo.text = $"{datos.categoria.name}\n{datos.tipo.name}";
        titulo.color = valores.color = datos.categoria.colorTexto;
        valores.text = $"Gracia: {datos.gracia}\nOfensa: {datos.ofensa}";
        fondo.color = datos.categoria.color;
        iconoTipo.sprite = datos.tipo.logo;
        iconoCategoria.sprite = datos.categoria.logo;
    }

    public void Click()
    {
        AlCliquear?.Invoke(this);
    }
}
