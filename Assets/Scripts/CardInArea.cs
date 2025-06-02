using UnityEngine;

public class CardInArea : MonoBehaviour
{
    [Header("Doors")]
    public Transform door1;
    public Transform door2;

    [Header("Card")]
    public GameObject card;

    [Header("Movement Settings")]
    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    [Header("Options")]
    public bool closeWhenCardLeaves = false;
    public float closeDelay = 5f;

    private Vector3 door1StartPos;
    private Vector3 door2StartPos;
    private Vector3 door1TargetPos;
    private Vector3 door2TargetPos;

    private bool isCardInside = false;
    private bool isClosing = false;
    private bool isOpening = false;
    private float closeTimer = 0f;

    void Start()
    {
        door1StartPos = door1.position;
        door2StartPos = door2.position;

        door1TargetPos = door1StartPos + new Vector3(0, moveDistance, 0);
        door2TargetPos = door2StartPos + new Vector3(0, -moveDistance, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == card)
        {
            isCardInside = true;
            isOpening = true;
            isClosing = false;
            closeTimer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == card)
        {
            isCardInside = false;
            if (closeWhenCardLeaves)
            {
                isClosing = true;
                closeTimer = closeDelay;
            }
        }
    }

    void Update()
    {
        if (isOpening)
        {
            door1.position = Vector3.MoveTowards(door1.position, door1TargetPos, moveSpeed * Time.deltaTime);
            door2.position = Vector3.MoveTowards(door2.position, door2TargetPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(door1.position, door1TargetPos) < 0.01f &&
                Vector3.Distance(door2.position, door2TargetPos) < 0.01f)
            {
                isOpening = false;
            }
        }
        else if (isClosing)
        {
            closeTimer -= Time.deltaTime;
            if (closeTimer <= 0f)
            {
                door1.position = Vector3.MoveTowards(door1.position, door1StartPos, moveSpeed * Time.deltaTime);
                door2.position = Vector3.MoveTowards(door2.position, door2StartPos, moveSpeed * Time.deltaTime);
            }
        }
    }
}
