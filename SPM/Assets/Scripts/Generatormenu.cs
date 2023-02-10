using UnityEngine;
public class Generatormenu : MonoBehaviour
{
    public float spwnrt = 2f;
    public GameObject hexpref;
    public float nxttimetispwn = 0f;
    void Update()
    {
        if (Time.time >= nxttimetispwn)
        {
            Instantiate(hexpref, Vector3.zero, Quaternion.identity);
            nxttimetispwn = Time.time + 1f / spwnrt;
        }
    }
}