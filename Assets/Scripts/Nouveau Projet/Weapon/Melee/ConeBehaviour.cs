using UnityEngine;

public class ConeBehaviour : MonoBehaviour
{
    public float duration = 0.5f;
    public float destroyDelay = 0.25f;
    private float timer = 0f;
    private bool destroyScheduled = false;

    //private Rigidbody rigi;
    private Vector3 initialLocalPosition;

    private void Awake()
    {
        //rigi = GetComponent<Rigidbody>();
        //rigi.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void Start()
    {
        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float progress = Mathf.Clamp01(timer / duration);

        // Increase the scale by 2 units in all axes
        Vector3 newScale = Vector3.one * (0.5f + 1f * progress);

        // Set the new scale
        transform.localScale = newScale;

        // If the animation is complete, schedule destruction
        if (progress >= 0.5f && !destroyScheduled)
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
