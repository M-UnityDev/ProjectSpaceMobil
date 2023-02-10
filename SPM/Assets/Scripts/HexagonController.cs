using UnityEngine;
public class HexagonController : MonoBehaviour
{
    [SerializeField] private float shsp;
    [SerializeField] private Rigidbody2D rb;
    private void Start()
    {
        rb.rotation= Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 50f;
    }
    void Update()
    {
        transform.localScale -= Vector3.one * shsp *Time.deltaTime;
        if (transform.localScale.x < 0.3)
        {Destroy(gameObject);}
    }
}