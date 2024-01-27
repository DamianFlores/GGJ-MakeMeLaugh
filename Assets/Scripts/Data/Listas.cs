using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Listas", menuName = "Datos/Listas")]
public class Listas : ScriptableObject
{
    public Categoria[] categorias;
    public Tipo[] tipos;

    public Categoria yuxtaposicion;
    public Tipo remate, autoconclusivo;

    public Categoria CategoriaAlAzar() => AlAzar(categorias);

    public Tipo TipoAlAzar() => AlAzar(tipos);

    public T AlAzar<T>(T[] lista) => lista[Random.Range(0, lista.Length)];
}
