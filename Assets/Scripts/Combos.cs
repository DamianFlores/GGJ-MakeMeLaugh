using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combos : MonoBehaviour
{
    public Combo prefabCombo;

    public void AgregarCombo()
    {
        Instantiate(prefabCombo, transform);
    }
}
