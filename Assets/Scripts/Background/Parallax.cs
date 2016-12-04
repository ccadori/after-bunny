using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Inspector
    [SerializeField]
    private string targetTag;
    [SerializeField]
    private float percentageMovimentation;
    [SerializeField]
    private bool x;
    [SerializeField]
    private bool y;
    // Inspector

    private GameObject target;
    public Vector3 initialPosition { private set; get; }

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (target == null && !AsignTarget())
            return;

        float calcVelocity = (percentageMovimentation / 100) * -1;
        Vector3 newPosition = transform.position;
        if (x)
        {
            float distance = initialPosition.x - target.transform.position.x;
            newPosition.x = target.transform.position.x - (distance * calcVelocity);
        }
        if (y)
        {
            float distance = initialPosition.y - target.transform.position.y;
            newPosition.y = target.transform.position.y - (distance * calcVelocity);
        }

        transform.position = newPosition;
    }

    private bool AsignTarget()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);

        if (target == null)
            return false;

        return true;
    }
}
