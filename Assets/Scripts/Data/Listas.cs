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

    private List<Tipo> tipoParaAzar = null;
    public Categoria CategoriaAlAzar() => AlAzar(categorias);

    public Tipo TipoAlAzar()
    {
        //TODO optimizar

        tipoParaAzar = new List<Tipo>();
        foreach(var t in tipos)
            for (var i = 0; i < t.prioridad; i++)
                tipoParaAzar.Add(t);
        return AlAzar(tipoParaAzar);
    }

    public T AlAzar<T>(T[] lista) => lista[Random.Range(0, lista.Length)];
    public T AlAzar<T>(List<T> lista) => lista[Random.Range(0, lista.Count)];
}
