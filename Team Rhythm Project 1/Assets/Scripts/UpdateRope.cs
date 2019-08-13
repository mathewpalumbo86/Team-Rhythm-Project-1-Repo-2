using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRope : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField]
    GameObject target;

    [SerializeField]
    GameObject hoverBoard;
    int myPositionElement = 0;
    int targetPositionElement = 1;

    private void Awake()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.SetPosition(myPositionElement, hoverBoard.transform.position);
        lineRenderer.SetPosition(targetPositionElement, target.transform.position); // sets position of the target (updates line)
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(myPositionElement, hoverBoard.transform.position);
        lineRenderer.SetPosition(targetPositionElement, target.transform.position); // sets position of the target (updates line)
    }
}
