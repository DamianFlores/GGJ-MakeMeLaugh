using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    public Image fondo, raycasteable, iconoCategoria;
    public DatosCarta datos;
    public Image valorRisa, valorOfensa;

    public Sprite[] spritesRisa, spriteOfensa;

    public static event System.Action<Carta> AlCliquear;

    public void Iniciar(DatosCarta datos)
    {
        this.datos = datos;
        fondo.sprite = datos.tipo.logo;
        //titulo.text = $"{datos.categoria.name}\n{datos.tipo.name}";
        //titulo.color = valores.color = datos.categoria.colorTexto;
        //valores.text = $"Gracia: {datos.gracia}\nOfensa: {datos.ofensa}";
        //fondo.color = datos.categoria.color;
        iconoCategoria.sprite = datos.categoria.logo;
        valorRisa.sprite = spritesRisa[datos.gracia - 1];
        valorOfensa.sprite = spriteOfensa[datos.ofensa + 1];
    }

    public void Click()
    {
        AlCliquear?.Invoke(this);
    }

    public void DesactivarRaycast()
    {
        raycasteable.raycastTarget = false;
    }

    public void ActivarRaycast()
    {
        raycasteable.raycastTarget = true;
    }
}
