using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Categoría", menuName = "Datos/Categoría")]
public class Categoria : ScriptableObject
{
    public Color color, colorTexto = Color.black;
    public Sprite logo;
}
