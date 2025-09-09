using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 distance = new Vector3(0, 5, -10);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = player.position + distance;
        transform.position = cameraPosition;
    }
}