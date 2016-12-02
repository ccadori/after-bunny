using UnityEngine;

public class Final : UIBase
{
    void Start()
    {
        ReachFinal.onFinal += Open;
    }
}