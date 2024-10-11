using System;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public LayerMask targetLayer;  // ���� ��������, ������� ����� �������������
    public float attractionRadius = 5f;  // ������ ����������
    public float attractionSpeed = 2f;  // �������� ����������

    void Update()
    {
        // ������� ��� ������� � ������� ���������� � ������� Physics2D.OverlapCircle
        Collider2D[] targetsInRange = Physics2D.OverlapCircleAll(transform.position, attractionRadius, targetLayer);

        foreach (Collider2D target in targetsInRange)
        {
            Transform targetTransform = target.transform;

            // ������������ ����������� �� ������� � ������ ��������� � ������� �� � ���
            Vector3 directionToMe = (transform.position - targetTransform.position).normalized;
            targetTransform.position += directionToMe * attractionSpeed * Time.deltaTime;
        }
    }

    // ������������ ������� ���������� � ��������� Unity
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attractionRadius);  // ���������� ������ ����������
    }
}
