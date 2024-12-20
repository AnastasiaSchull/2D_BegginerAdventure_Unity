using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed; 

    void Start()
    {
        rotationSpeed = 250f;
    }

    void Update()
    {
        // вращение вокруг оси Y
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}

