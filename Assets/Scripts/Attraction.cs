using System;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public LayerMask targetLayer;  // Слой объектов, которые будут притягиваться
    public float attractionRadius = 5f;  // Радиус притяжения
    public float attractionSpeed = 2f;  // Скорость притяжения

    void Update()
    {
        // Находим все объекты в радиусе притяжения с помощью Physics2D.OverlapCircle
        Collider2D[] targetsInRange = Physics2D.OverlapCircleAll(transform.position, attractionRadius, targetLayer);

        foreach (Collider2D target in targetsInRange)
        {
            Transform targetTransform = target.transform;

            // Рассчитываем направление от объекта к нашему положению и двигаем их к нам
            Vector3 directionToMe = (transform.position - targetTransform.position).normalized;
            targetTransform.position += directionToMe * attractionSpeed * Time.deltaTime;
        }
    }

    // Визуализация радиуса притяжения в редакторе Unity
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attractionRadius);  // Отображаем радиус притяжения
    }
}
