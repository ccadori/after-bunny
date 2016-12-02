using UnityEngine;

public class ReachFinal : MonoBehaviour
{
    // Inspector
    [SerializeField]
    private bool x;
    [SerializeField]
    private bool y;
    [SerializeField]
    private float xFinalPosition;
    [SerializeField]
    private float yFinalPosition;
    // Inspector

    public static event Health.voidEvent onFinal;

    private void FixedUpdate()
    {
        if (x)
            if (transform.position.x > xFinalPosition)
                Final();

        if (y)
            if (transform.position.y > yFinalPosition)
                Final();
    }

    private void Final()
    {
        if (onFinal != null)
            onFinal();

        Destroy(this);
    }
}