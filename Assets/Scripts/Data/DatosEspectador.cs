using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosEspectador
{
    public struct Compatibilidad
    {
        public Categoria categoria;
        public int aFavor, enContra;

        public Compatibilidad(int aFavor, int enContra, Categoria categoria)
        {
            this.aFavor = aFavor;
            this.enContra = enContra;
            this.categoria = categoria;
        }
    }

    public Dictionary<Categoria, Compatibilidad> compatibilidades
        = new Dictionary<Categoria, Compatibilidad>();

    public int humor, perdidaPorRonda, limite;

    public static DatosEspectador CrearAlAzar(Categoria[] ccc)
    {
        var compatibilidades = new Dictionary<Categoria, Compatibilidad>();

        foreach (var c in ccc)
            compatibilidades.Add(c, CompatibilidadAlAzar(c));

        return new DatosEspectador { compatibilidades = compatibilidades };
    }

    public void ProcesarEfectoCarta(Carta carta)
    {
        Debug.Log($"Procesa carta {carta.datos.categoria}");

        var compatibilidad = compatibilidades[carta.datos.categoria];

        var sumaHumor = 0;
        var baseGracia = compatibilidad.aFavor;
        for (var i = 0; i < carta.datos.gracia; i++)
            sumaHumor += Random.Range(0, 6) + baseGracia;

        var restaHumor = 0;
        var baseOfensa = compatibilidad.enContra;
        for (var i = 0; i < carta.datos.ofensa; i++)
            restaHumor += Random.Range(0, 6) + baseOfensa;
        
        Debug.Log($"Suma {sumaHumor}");
        Debug.Log($"Resta {restaHumor}");

        humor += sumaHumor - restaHumor;

        if (humor > 0)
            Debug.Log($"Suma {humor} en gracia");
        else if (humor < 0)
            Debug.Log($"Suma {humor} en ofensa");

        humor = Mathf.Clamp(humor, -limite, limite);
    }

    public static Compatibilidad CompatibilidadAlAzar(Categoria categoria)
    {
        var total = Random.Range(0, 6);
        var risa = Random.Range(0, total + 1);
        var ofensa = total - risa;

        return new Compatibilidad
        {
            aFavor = risa,
            enContra = ofensa,
            categoria = categoria
        };
    }
}
