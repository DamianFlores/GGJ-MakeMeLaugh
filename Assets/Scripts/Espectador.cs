using UnityEngine;

public class Espectador : MonoBehaviour
{
    public DatosEspectador datos;
    public EspectadorAnimator animator;

    private void Awake()
    {
        Combo.Ejecutar += AplicarEfecto;
    }

    public  void Iniciar(DatosEspectador datos)
    {
        this.datos = datos;
        //ActualizarTexto();
    }

    public void AplicarEfecto(Combo combo)
    {
        //Esto se debe a que Procesar efecto carda espera una carta
        Carta cartaSimulada = new Carta();
        DatosCarta datosCarta = new DatosCarta();

        datosCarta.ofensa = combo.Valor().ofensa;
        datosCarta.gracia = combo.Valor().gracia;
        datosCarta.categoria = combo.Valor().categoria;
        cartaSimulada.datos = datosCarta;

        int humorAplicado = datos.ProcesarEfectoCarta(cartaSimulada);

        print($"Aplicando efectos de combo {humorAplicado}");
        if (humorAplicado > 0)
        {
            animator.Reir();
        }
        if (humorAplicado < 0)
        {
            animator.Enojarse();
        }
    }

    public void AplicarEfecto(Carta carta)
    {
        print("Aplicando efectos de carta");
        if (datos.ProcesarEfectoCarta(carta) > 0)
        {
            animator.Reir();
        }
        if (datos.ProcesarEfectoCarta(carta) < 0)
        {
            animator.Enojarse();
        }

        //ActualizarTexto();
    }

    //public void ActualizarTexto()
    //{
    //    var compatibilidades = string.Join('\n', datos.compatibilidades.Select(c => $"<b>{c.Key.name.ToUpper()}</b>\ngracia: {c.Value.aFavor}\nofensa: {c.Value.enContra}\n").ToArray());

    //    texto.text = $"<size=24>Estado: {datos.humor}</size>\n\n{compatibilidades}";
    //}

    private void OnDestroy()
    {
        Combo.Ejecutar -= AplicarEfecto;
    }
}
