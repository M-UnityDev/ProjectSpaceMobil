using System.Collections;
using UnityEngine;
public class OptimizeCollectables : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(disapear());
    }
    void Update()
    {
        if (gameObject.tag == "Coin" || gameObject.tag == "Shield")
        {transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);}
    }
    IEnumerator disapear()
    {
        if (gameObject.tag == "Coin" || gameObject.tag == "Shield")
        { yield return new WaitForSeconds(10); }
        else if (gameObject.tag == "Shieldprev")
        { yield return new WaitForSeconds(30); }
        Destroy(gameObject);
    }
}