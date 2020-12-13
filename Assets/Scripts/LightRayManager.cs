using UnityEngine;

public class LightRayManager : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform nullPoint;
    private Adventurer adventurerScript;
    public Transform _selection;
    private ui ui;
    public Transform lightOfPlayer;

    [SerializeField]
    private ObeliskManager obeliskManager;
    [SerializeField]
    private MirrorManager mirrorManager;
    public bool adventurerCanGoHere;
    [HideInInspector]
    public Vector3 selectedPosition;


    private void Start()
    {
        lineRenderer.SetPosition(0, nullPoint.position);
        lineRenderer.SetPosition(1, nullPoint.position);
        adventurerCanGoHere = false;
        adventurerScript = FindObjectOfType<Adventurer>();
        ui = FindObjectOfType<ui>();
    }
    void FixedUpdate()
    {
        if (_selection != null)
        {
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int layerMask = 1 << 11 | 1 << 12;
        int layerMask2 = 1 << 9;

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            var selection = hit.transform;
            if (Input.GetMouseButtonDown(0) && selection.CompareTag("DX") && adventurerCanGoHere == true)
            {
                adventurerScript.MoveDX();
                ui.MoveUsed();
            }
            if (Input.GetMouseButtonDown(0) && selection.CompareTag("SX") && adventurerCanGoHere == true)
            {
                adventurerScript.MoveSX();
                ui.MoveUsed();

            }
            if (Input.GetMouseButtonDown(0) && selection.CompareTag("UP") && adventurerCanGoHere == true)
            {
                adventurerScript.MoveUP();
                ui.MoveUsed();

            }
            if (Input.GetMouseButtonDown(0) && selection.CompareTag("DOWN") && adventurerCanGoHere == true)
            {
                adventurerScript.MoveDown();
                ui.MoveUsed();

            }

            _selection = selection;



            Vector3 rayDirection = hit.point - player.position;

            RaycastHit collision;
            if (Physics.Raycast(player.position, rayDirection, out collision, Mathf.Infinity, layerMask2))
            {
                lineRenderer.SetPosition(0, player.position);
                lineRenderer.SetPosition(1, collision.point);
                Debug.DrawLine(player.position, collision.point, Color.red);


                // Rotate the camera every frame so it keeps looking at the target
                lightOfPlayer.LookAt(collision.point);


                adventurerCanGoHere = false;

                if (collision.transform.CompareTag("Obelisk"))
                {
                    obeliskManager.obeliskHighlighted = true;
                    obeliskManager.selectedObelisk = collision.transform;
                }
                else
                {
                    obeliskManager.obeliskHighlighted = false;
                    mirrorManager.mirrorHitted = false;
                }
            }
            else
            {
                lineRenderer.SetPosition(0, player.position);
                lineRenderer.SetPosition(1, hit.point);
                Debug.DrawLine(player.position, hit.point, Color.green);

                // Rotate the camera every frame so it keeps looking at the target
                lightOfPlayer.LookAt(hit.point);


                adventurerCanGoHere = true;
                obeliskManager.obeliskHighlighted = false;
                mirrorManager.mirrorHitted = false;
            }
        }
        else
        {
            lineRenderer.SetPosition(0, nullPoint.position);
            lineRenderer.SetPosition(1, nullPoint.position);
        }

    }
}
