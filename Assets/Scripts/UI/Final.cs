using UnityEngine;

public class Final : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        ReachFinal.onFinal += Open;
    }

    void Open()
    {
        anim.SetBool("Opened", true);
    }
}