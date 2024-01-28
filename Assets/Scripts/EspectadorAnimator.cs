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
        Invoke(nameof(VolverANeutral), 2);
    }

    public void Enojarse()
    {
        animator.SetBool("Enojado", true);
        EvaluarVariante();
        Invoke(nameof(VolverANeutral), 2);
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
