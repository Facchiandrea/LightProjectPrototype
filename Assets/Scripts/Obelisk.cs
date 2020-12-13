using UnityEngine;

public class Obelisk : MonoBehaviour
{
    private Light obeliskRay1;
    private Light obeliskRay2;
    private LineRenderer lineRenderer;
    private Transform rayEmissionPoint;
    private Transform targetPoint;
    [SerializeField]
    public Transform nullPoint;
    [SerializeField]
    private ObeliskManager obeliskManager;
    [SerializeField]
    private MirrorManager mirrorManager;
    public bool obeliskSelected;


    private void Update()
    {
        GetSelectedObelisk();
        if (obeliskManager.obeliskHighlighted == true)
        {
            obeliskRay1.enabled = true;
            obeliskRay2.enabled = true;
            lineRenderer.SetPosition(0, rayEmissionPoint.position);
            lineRenderer.SetPosition(1, targetPoint.position);

            int obeliskMask = ~(1 << 10);
            Vector3 rayDirection = targetPoint.position - rayEmissionPoint.position;
            RaycastHit hit;
            if (Physics.Raycast(rayEmissionPoint.position, rayDirection, out hit, Mathf.Infinity, obeliskMask))
            {
                lineRenderer.SetPosition(0, rayEmissionPoint.position);
                lineRenderer.SetPosition(1, hit.point);
                if (hit.transform.CompareTag("Mirror"))
                {
                    mirrorManager.mirrorHitted = true;
                    mirrorManager.selectedMirror = hit.transform;
                }
                else
                {
                    mirrorManager.mirrorHitted = false;
                }
            }
            else
            {
                mirrorManager.mirrorHitted = false;
            }
        }
        else
        {
            obeliskRay1.enabled = false;
            obeliskRay2.enabled = false;
            lineRenderer.SetPosition(0, nullPoint.position);
            lineRenderer.SetPosition(1, nullPoint.position);
        }
    }

    public void GetSelectedObelisk()
    {
        lineRenderer = obeliskManager.selectedObelisk.GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        obeliskRay1 = obeliskManager.selectedObelisk.transform.GetChild(0).GetComponentInChildren<Light>();
        /*nota:il ray 1 è un'area light, quindi bisogna inserire un codice che ne modifichi la lunghezza in caso il raggio
        collida con qualcosa (l'area light deve avere la stessa lunghezza del raggio*/
        obeliskRay2 = obeliskManager.selectedObelisk.transform.GetChild(1).GetComponentInChildren<Light>();
        rayEmissionPoint = obeliskManager.selectedObelisk.transform.GetChild(2).GetComponentInChildren<Transform>();
        targetPoint = obeliskManager.selectedObelisk.transform.GetChild(3).GetComponentInChildren<Transform>();
    }

}
