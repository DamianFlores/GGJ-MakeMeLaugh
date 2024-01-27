using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorEspectador : MonoBehaviour
{
    public Listas listas;
    public Espectador prefabEspectador;
    public RectTransform contenedor;

    public void CrearAlAzar()
    {
        var espectador = Instantiate(prefabEspectador, contenedor);
        var datos = DatosEspectador.CrearAlAzar(listas.categorias);
        espectador.Iniciar(datos);
    }
}
