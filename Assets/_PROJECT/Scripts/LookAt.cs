
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject Camera;

    private void Update()
    {
        transform.LookAt(Camera.transform);
    }
}
