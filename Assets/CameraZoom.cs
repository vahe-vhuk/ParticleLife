using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float zoomSpeed = 50f;
    [SerializeField]
    private float minZoom = 50f;
    [SerializeField]
    private float maxZoom = 1000f;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (cam == null || !cam.orthographic)
        {
            return;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > Mathf.Epsilon)
        {
            float size = cam.orthographicSize - scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(size, minZoom, maxZoom);
        }
    }
}
