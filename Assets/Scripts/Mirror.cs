using UnityEngine;

public class Mirror : MonoBehaviour
{
    private Light mirrorRay1;
    private Light mirrorRay2;
    private LineRenderer lineRenderer;
    private Transform rayEmissionPoint;
    private Transform targetPoint;
    [SerializeField]
    public Transform nullPoint;
    [SerializeField]
    private MirrorManager mirrorManager;

    private void Update()
    {
        GetSelectedMirror();
        if (mirrorManager.mirrorHitted == true)
        {
            mirrorRay1.enabled = true;
            mirrorRay2.enabled = true;
            lineRenderer.SetPosition(0, rayEmissionPoint.position);
            lineRenderer.SetPosition(1, targetPoint.position);

            int mirrorMask = ~(1 << 10);
            Vector3 rayDirection = targetPoint.position - rayEmissionPoint.position;
            RaycastHit hit;
            if (Physics.Raycast(rayEmissionPoint.position, rayDirection, out hit, Mathf.Infinity, mirrorMask))
            {
                lineRenderer.SetPosition(0, rayEmissionPoint.position);
                lineRenderer.SetPosition(1, hit.point);

                if (hit.transform.CompareTag("Mirror"))
                {
                    mirrorManager.mirrorHitted = true;
                    mirrorManager.selectedMirror = hit.transform;
                }
            }
        }
        else
        {
            mirrorRay1.enabled = false;
            mirrorRay2.enabled = false;
            lineRenderer.SetPosition(0, nullPoint.position);
            lineRenderer.SetPosition(1, nullPoint.position);
        }
    }
    public void GetSelectedMirror()
    {
        lineRenderer = mirrorManager.selectedMirror.GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        mirrorRay1 = mirrorManager.selectedMirror.transform.GetChild(0).GetComponentInChildren<Light>();
        /*nota:il ray 1 è un'area light, quindi bisogna inserire un codice che ne modifichi la lunghezza in caso il raggio
        collida con qualcosa (l'area light deve avere la stessa lunghezza del raggio*/
        mirrorRay2 = mirrorManager.selectedMirror.transform.GetChild(1).GetComponentInChildren<Light>();
        rayEmissionPoint = mirrorManager.selectedMirror.transform.GetChild(2).GetComponentInChildren<Transform>();
        targetPoint = mirrorManager.selectedMirror.transform.GetChild(3).GetComponentInChildren<Transform>();
    }

}
