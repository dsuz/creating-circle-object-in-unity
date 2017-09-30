using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LineRenderer を使って円を描くクラス。
/// 円を描くやり方は次で説明されている方法で行った。
/// 
/// Draw Circle and place object on circle using Line Renderer - Unity [ENG]
/// https://www.youtube.com/watch?v=BoDwchoM9Ic
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class DrawingCircleController : MonoBehaviour
{
    public int m_vertexCount = 20;
    public float m_lineWidth = 0.2f;
    public float m_radius = 1f;

    private LineRenderer m_lineRenderer;
    private float m_savedRadius;
    private int m_savedVertexCount;
    private float m_savedLineWidth;

    private void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        m_lineRenderer.enabled = false;
    }

    private void Start()
    {
        m_lineRenderer.useWorldSpace = false;
        m_lineRenderer.loop = true;
    }

    private void Update()
    {
        if (m_radius != m_savedRadius || m_vertexCount != m_savedVertexCount || m_lineWidth != m_savedLineWidth)
        {
            if (m_vertexCount < 3) m_vertexCount = 3;
            if (m_radius < 0f) m_radius = 0f;
            if (m_lineWidth < 0f) m_lineWidth = 0f;

            SetupCircle();
            m_savedRadius = m_radius;
            m_savedVertexCount = m_vertexCount;
            m_savedLineWidth = m_lineWidth;
        }
    }

    private void SetupCircle()
    {
        m_lineRenderer.widthMultiplier = m_lineWidth;
        float deltaTheta = (2f * Mathf.PI) / m_vertexCount;
        float theta = 0f;
        m_lineRenderer.positionCount = m_vertexCount;
        for (int i = 0; i < m_lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(m_radius * Mathf.Cos(theta), m_radius * Mathf.Sin(theta), 0f);
            m_lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
        if (!m_lineRenderer.enabled) m_lineRenderer.enabled = true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / m_vertexCount;
        float theta = 0f;
        Vector3 oldPos = Vector3.zero;
        for (int i = 0; i < m_vertexCount + 1; i++)
        {
            Vector3 pos = new Vector3(m_radius * Mathf.Cos(theta), m_radius * Mathf.Sin(theta), 0f);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
    }
#endif
}
