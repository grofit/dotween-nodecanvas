using UnityEngine;
using System.Collections;

public class PointsLine : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

	// Use this for initialization
	void Start ()
	{
	    var getStartPosition = transform.FindChild("StartPoint");
	    var getEndPosition = transform.FindChild("EndPoint");
        _lineRenderer.SetPosition(0, getStartPosition.transform.position);
        _lineRenderer.SetPosition(1, getEndPosition.transform.position);
	}
	
	// Update is called once per frame
	void Update () {

    }
}
