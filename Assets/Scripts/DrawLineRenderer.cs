using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public Transform joint0;
    public Transform joint1;
    public Transform joint2;

    public LineRenderer lineRenderer1;  // LineRenderer for joint0 -> joint1
    public LineRenderer lineRenderer2;  // LineRenderer for joint1 -> joint2

    void Start()
    {
        InitializeLineRenderer(lineRenderer1);
        InitializeLineRenderer(lineRenderer2);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVisualLinks();
    }


    void InitializeLineRenderer(LineRenderer lineRenderer)
    {
        // Set up the LineRenderer properties like width, color, etc.
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2; // Each bone only needs 2 points (start and end)
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));  // Basic material for 2D
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
    }

    void UpdateVisualLinks()
    {
        // Update line from joint0 to joint1
        lineRenderer1.SetPosition(0, joint0.position); // Start point at joint0
        lineRenderer1.SetPosition(1, joint1.position); // End point at joint1

        // Update line from joint1 to joint2
        lineRenderer2.SetPosition(0, joint1.position); // Start point at joint1
        lineRenderer2.SetPosition(1, joint2.position); // End point at joint2
    }
}