using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspectadorAnimator : MonoBehaviour
{
    public Animator animator;

    public void Reir()
    {
        animator.SetBool("Contento", true);
        EvaluarVariante();
    }

    public void Enojarse()
    {
        animator.SetBool("Contento", true);
        EvaluarVariante();
    }

    private void EvaluarVariante()
    {
        animator.SetBool("Variante", Random.Range(0, 2) == 0);
    }

    public void VolverANeutral()
    {
        animator.SetBool("Enojado", false);
        animator.SetBool("Contento", false);
    }
}
