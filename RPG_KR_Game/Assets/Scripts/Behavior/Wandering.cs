using Interfaces;
using UnityEngine;

public class Wandering : MonoBehaviour, IMovment
{
    #region Properties
    
    public float moveSpeed = 2f;
    [SerializeField, Range(50,200)]public float rotationSpeed = 100f;
    [SerializeField, Range(0,360)]public float maxRotationAngle = 45f;
    private Quaternion targetRotation;

    #endregion
    #region Methouds
    public void Movement()
    {
        // Рухаємо тварину вперед
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        // Поворот до цільового кута
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // Якщо досягли цільового кута, встановлюємо новий цільовий кут
        if (Quaternion.Angle(transform.rotation, targetRotation) <= 0.1f)
        {
            targetRotation = Quaternion.Euler(0f, 0f, Random.Range(-maxRotationAngle, maxRotationAngle));
        }
    }
    #endregion
    #region StartAndUpdate
    private void Start()
    {
        // Встановлюємо початковий кут повороту
        targetRotation = Quaternion.Euler(0f, 0f, Random.Range(-maxRotationAngle, maxRotationAngle));
    }
    private void Update()
    {
        Movement();
    }
    #endregion
}