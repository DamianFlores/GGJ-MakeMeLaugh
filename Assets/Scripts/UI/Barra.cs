using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    public RectTransform barra;

    private float valor;
    public float factorLerp;

    void Update()
    {
        barra.localScale = Vector3.Lerp(barra.localScale, new Vector3(valor, 1, 1), factorLerp);
    }

    public float Valor
    {
        set
        {
            valor = Mathf.Clamp(value, 0f, 1f);
        }
    }

    public void Aumentar()
    {
        valor += .1f;
    }
}
