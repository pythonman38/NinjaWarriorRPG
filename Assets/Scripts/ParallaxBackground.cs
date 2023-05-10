using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject gameCamera;

    [SerializeField] private float parallexEffect;

    private float xPosition, length;

    void Start()
    {
        gameCamera = GameObject.FindWithTag("MainCamera");

        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
    }

    void Update()
    {
        float distanceMoved = gameCamera.transform.position.x * (1 - parallexEffect);
        float distanceToMove = gameCamera.transform.position.x * parallexEffect;

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

        if (distanceMoved > xPosition + length) xPosition = xPosition + length;
        else if (distanceMoved < xPosition - length) xPosition = xPosition - length;
    }
}
