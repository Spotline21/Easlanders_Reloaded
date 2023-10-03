using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 2D персонаж, за которым следит камера
    public float smoothSpeed = 0.125f; // —корость следовани€ камеры
    public Vector3 offset; // —мещение камеры относительно центра

    void FixedUpdate()
    {
        if (target == null)
        {
            // ≈сли персонаж отсутствует, не выполн€ем следование камеры
            return;
        }

        // ѕолучаем позицию персонажа с учетом смещени€
        Vector3 desiredPosition = target.position + offset;

        // »нтерполируем плавное перемещение к целевой позиции
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ”станавливаем позицию камеры
        transform.position = smoothedPosition;
    }
}
