using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        this.transform.position = this.transform.position +
        new Vector3(moveHorizontal * speed * Time.fixedDeltaTime, 0, moveVertical * speed * Time.fixedDeltaTime);
    }
}
