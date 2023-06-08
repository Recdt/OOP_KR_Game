using Interfaces;
using UnityEngine;

public class Wandering : MonoBehaviour, IMovment
{
    #region Properties
    
    public float moveSpeed = 10f;
    [SerializeField, Range(50,200)]public float rotationSpeed = 100f;
    public float maxRotationAngle = 360f;
    private Quaternion _targetRotation;
    private Vector3 _randomSide;

    #endregion
    #region Methouds

    private Vector3 ChooseRandSide()
    {
        int temporary = Random.Range(1, 4);
        switch (temporary)
        {
            case 1:
                return Vector3.up;
            case 2:
                return Vector3.down;
            case 3:
                return Vector3.left;
            case 4:
                return Vector3.right;
        }
        return Vector3.up;
    }
    public void Movement()
    {
        
        // Рухаємо тварину вперед
        transform.Translate(ChooseRandSide() * moveSpeed * Time.deltaTime);
        // Поворот до цільового кута
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, rotationSpeed * Time.deltaTime);
        // Якщо досягли цільового кута, встановлюємо новий цільовий кут
        if (Quaternion.Angle(transform.rotation, _targetRotation) <= 0.1f)
        {
            _targetRotation = Quaternion.Euler(0f, 0f, Random.Range(-maxRotationAngle, maxRotationAngle));
        }
    }
    #endregion
    #region StartAndUpdate
    private void Start()
    {
        // Встановлюємо початковий кут повороту
        _targetRotation = Quaternion.Euler(0f, 0f, Random.Range(-maxRotationAngle, maxRotationAngle));
    }
    private void Update()
    {
        Movement();
    }
    #endregion
}