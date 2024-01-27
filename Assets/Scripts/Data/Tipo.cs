using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tipo", menuName = "Datos/Tipos")]
public class Tipo : ScriptableObject
{
    public Sprite logo;
    public bool esInicio, termina;

    [Range(-1, 5)]
    public int minimoGracia, maximoGracia, minimoOfensa, maximoOfensa;

    public int GraciaAlAzar => Random.Range(minimoGracia, maximoGracia + 1);
    public int OfensaAlAzar => Random.Range(minimoOfensa, maximoOfensa + 1);
}
