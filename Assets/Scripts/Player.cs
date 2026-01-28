using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementInputNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime ;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 11f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
        
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
