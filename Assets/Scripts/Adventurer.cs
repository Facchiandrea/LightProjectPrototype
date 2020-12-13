using UnityEngine;

public class Adventurer : MonoBehaviour
{
    [SerializeField]
    private GameObject directions;
    [SerializeField]
    private GameObject obeliskActionsCanvas;
    [SerializeField]
    private GameObject mirrorActionsCanvas;
    private Transform obeliskTransform;
    private Transform mirrorTransform;
    [SerializeField]
    private ui ui;
    public void MoveDX()
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        directions.transform.position = transform.position;
    }
    public void MoveSX()
    {
        transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        directions.transform.position = transform.position;
    }
    public void MoveUP()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        directions.transform.position = transform.position;
    }
    public void MoveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        directions.transform.position = transform.position;
    }

    //fa comparire i bottoni ui quando vicino a un obelisco
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obelisk"))
        {
            obeliskActionsCanvas.SetActive(true);
            obeliskTransform = other.transform;
        }
        if (other.CompareTag("MirrorPedestal"))
        {
            mirrorActionsCanvas.SetActive(true);
            mirrorTransform = other.transform;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obelisk"))
        {
            obeliskActionsCanvas.SetActive(false);
            obeliskTransform = null;
        }
        if (other.CompareTag("MirrorPedestal"))
        {
            mirrorActionsCanvas.SetActive(false);
            mirrorTransform = null;
        }

    }
    public void PullButton()
    {
        if (transform.position.z < obeliskTransform.position.z)
        {
            obeliskTransform.position = transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            directions.transform.position = transform.position;
            ui.MoveUsed();
        }
        if (transform.position.z > obeliskTransform.position.z)
        {
            obeliskTransform.position = transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            directions.transform.position = transform.position;
            ui.MoveUsed();

        }
        if (transform.position.x < obeliskTransform.position.x)
        {
            obeliskTransform.position = transform.position;
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            directions.transform.position = transform.position;
            ui.MoveUsed();

        }
        if (transform.position.x > obeliskTransform.position.x)
        {
            obeliskTransform.position = transform.position;
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            directions.transform.position = transform.position;
            ui.MoveUsed();

        }





    }
    public void PushButton()
    {
        if (transform.position.z < obeliskTransform.position.z)
        {
            transform.position = obeliskTransform.position;
            directions.transform.position = transform.position;
            obeliskTransform.position = new Vector3(obeliskTransform.position.x, obeliskTransform.position.y, obeliskTransform.position.z + 1);
            ui.MoveUsed();

        }
        if (transform.position.z > obeliskTransform.position.z)
        {
            transform.position = obeliskTransform.position;
            directions.transform.position = transform.position;
            obeliskTransform.position = new Vector3(obeliskTransform.position.x, obeliskTransform.position.y, obeliskTransform.position.z - 1);
            ui.MoveUsed();

        }
        if (transform.position.x < obeliskTransform.position.x)
        {
            transform.position = obeliskTransform.position;
            directions.transform.position = transform.position;
            obeliskTransform.position = new Vector3(obeliskTransform.position.x + 1, obeliskTransform.position.y, obeliskTransform.position.z);
            ui.MoveUsed();

        }
        if (transform.position.x > obeliskTransform.position.x)
        {
            transform.position = obeliskTransform.position;
            directions.transform.position = transform.position;
            obeliskTransform.position = new Vector3(obeliskTransform.position.x - 1, obeliskTransform.position.y, obeliskTransform.position.z);
            ui.MoveUsed();

        }
    }

    public void RotateMirrorClockwise()
    {
        mirrorTransform.Rotate(0, 90, 0);
    }
    public void RotateMirrorAnticlockwise()
    {
        mirrorTransform.Rotate(0, -90, 0);
    }

}
