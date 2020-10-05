using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public GameObject targetMarker;

    public ARRaycastManager rayManager;

    public GameObject spider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = Screen.width / 2;
        var y = Screen.height / 2;

        var screenCenter = new Vector2(x, y);

        var hitResults = new List<ARRaycastHit>();

        rayManager.Raycast(screenCenter, hitResults, TrackableType.Planes);

        if (hitResults.Count > 0)
        {
            transform.position = hitResults[0].pose.position;
            transform.rotation = hitResults[0].pose.rotation;

            if (!targetMarker.activeInHierarchy)
            {
                targetMarker.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            var spiderClone = Instantiate(spider);

            spiderClone.transform.position = transform.position;
            spiderClone.transform.rotation = transform.rotation;

            if (!spiderClone.activeInHierarchy)
            {
                spiderClone.SetActive(true);
            }
        }
    }
}
