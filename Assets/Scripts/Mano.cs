using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano : MonoBehaviour
{
    public int limite = 5;
    private List<Carta> cartas = new List<Carta>();

    void Start()
    {
        Juego.AlPasarDeRonda += Llenar;
        StartCoroutine(Iniciar());
    }

    private IEnumerator Iniciar()
    {
        yield return new WaitForSeconds(.5f);

        Llenar();
    }

    public void Agregar(Carta carta)
    {
        cartas.Add(carta);
    }

    public void Sacar(Carta carta)
    {
        cartas.Remove(carta);
    }

    public void Llenar()
    {
        Debug.Log("Llenar");
        while (cartas.Count < limite)
            CreadorCarta.Instancia.CrearAlAzar();
    }

    private void OnDestroy()
    {
        Juego.AlPasarDeRonda -= Llenar;
    }
}
