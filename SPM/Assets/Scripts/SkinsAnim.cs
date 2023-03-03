using UnityEngine;
public class SkinsAnim : MonoBehaviour
{
    public void Right() => transform.Rotate(new Vector3(0, 0, 45));
    public void Left() => transform.Rotate(new Vector3(0, 0, -45));
    private void Update()
    {
        
    }
}
