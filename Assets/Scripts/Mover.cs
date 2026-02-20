using UnityEngine;

public class Mover : MonoBehaviour
{
    private Vector3 _movement = Vector3.forward * 2;

    private void Update()
    {
        transform.Translate(_movement * Time.deltaTime);
    }
}