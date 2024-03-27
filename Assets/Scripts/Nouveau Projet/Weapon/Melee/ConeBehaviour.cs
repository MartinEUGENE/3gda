using UnityEngine;

public class ConeBehaviour : MonoBehaviour
{
    public float duration = 2f;
    public float destroyDelay = 1f;
    private float timer = 0f;
    private bool destroyScheduled = false;

    private Vector3 initialLocalPosition;

    void Start()
    {
        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float progress = Mathf.Clamp01(timer / duration);

        // Increase the scale by 2 units in all axes
        Vector3 newScale = Vector3.one * (1f + 2f * progress);

        // Set the new scale
        transform.localScale = newScale;

        // If the animation is complete, schedule destruction
        if (progress >= 1f && !destroyScheduled)
        {
            Invoke("DestroyObject", destroyDelay);
            destroyScheduled = true;
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
