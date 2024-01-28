using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorCarta : MonoBehaviour
{
    public static CreadorCarta Instancia;

    public Listas listas;
    public Carta prefabCarta;
    private Mano mano;

    private void Start()
    {
        Instancia = this;

        mano = FindObjectOfType<Mano>();
    }

    public void CrearAlAzar()
    {
        var carta = Instantiate(prefabCarta, mano.transform);
        var categoria = listas.CategoriaAlAzar();
        Tipo tipo;

        do
        {
            tipo = listas.TipoAlAzar();
        }
        while (categoria == listas.yuxtaposicion && (tipo == listas.remate || tipo == listas.autoconclusivo));

        var datos = new DatosCarta
        {
            tipo = tipo,
            categoria = categoria,
            gracia = tipo.GraciaAlAzar,
            ofensa = tipo.OfensaAlAzar
        };

        carta.Iniciar(datos);

        mano.Agregar(carta);
    }
}
