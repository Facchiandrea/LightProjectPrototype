using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private GameObject affectedObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Adventurer") | other.CompareTag("Obelisk"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            affectedObject.transform.position = new Vector3(affectedObject.transform.position.x, affectedObject.transform.position.y - 2f, affectedObject.transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Adventurer") | other.CompareTag("Obelisk"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            affectedObject.transform.position = new Vector3(affectedObject.transform.position.x, affectedObject.transform.position.y + 2f, affectedObject.transform.position.z);
        }
    }
}
