using UnityEngine;

public class DiskController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 startPosition;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                startPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended && isDragging)
            {
                isDragging = false;
                Vector2 endPosition = touch.position;
                Vector2 direction = (endPosition - startPosition).normalized;

                float power = Vector2.Distance(startPosition, endPosition) * 0.1f;

                rb.AddForce(new Vector3(direction.x, 0, direction.y) * power, ForceMode.Impulse);
            }
        }
    }
}
