using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    private Transform cameraToLook;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cameraToLook.transform.position);
    }
}
