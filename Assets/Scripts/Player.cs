using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private int _speed = 5;

    [Header("Boundaries")]
    [SerializeField] private float _topBoundary = 0f;
    [SerializeField] private float _bottomBoundary = -3.8f;
    [SerializeField] private float _leftBoundary = -11.2f;
    [SerializeField] private float _rightBoundary = 11.2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {


        CalcuateMovement();
      
        
    }

    void CalcuateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        float clampedY = Mathf.Clamp(transform.position.y, _bottomBoundary, _topBoundary);
        float wrappedX = Mathf.Repeat(transform.position.x - _leftBoundary, _rightBoundary - _leftBoundary) + _leftBoundary;

        transform.position = new Vector3(wrappedX, clampedY, 0);

    }
}
