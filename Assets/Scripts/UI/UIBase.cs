using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIBase : MonoBehaviour
{
    internal Animator anim;

    internal virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void Open()
    {
        anim.SetBool("Open", true);
    }

    public virtual void Close()
    {
        anim.SetBool("Open", false);
    }
}
