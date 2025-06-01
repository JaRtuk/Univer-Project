using UnityEngine;
using TMPro;

public class KeypadController : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI codeDisplay;

    [Header("Password")]
    public string correctPassword = "1234";
    private string enteredCode = "";

    [Header("Doors")]
    public Transform door1;
    public Transform door2;

    [Header("Door Movement")]
    public float moveDistance = 3f; // на сколько двигать двери
    public float moveSpeed = 2f;

    private Vector3 door1StartPos;
    private Vector3 door2StartPos;
    private Vector3 door1TargetPos;
    private Vector3 door2TargetPos;

    private bool unlocked = false;

    void Start()
    {
        // Запоминаем начальные позиции дверей
        door1StartPos = door1.position;
        door2StartPos = door2.position;

        // Цели: одна дверь вверх, другая вниз
        door1TargetPos = door1StartPos + new Vector3(0, moveDistance, 0);
        door2TargetPos = door2StartPos + new Vector3(0, -moveDistance, 0);
    }

    public void PressButton(string number)
    {
        if (unlocked || enteredCode.Length >= 4)
            return;

        enteredCode += number;
        UpdateDisplay();

        if (enteredCode.Length == 4)
        {
            if (enteredCode == correctPassword)
            {
                unlocked = true;
            }
            else
            {
                Invoke(nameof(ResetCode), 1f);
            }
        }
    }

    void UpdateDisplay()
    {
        codeDisplay.text = enteredCode;
    }

    void ResetCode()
    {
        enteredCode = "";
        UpdateDisplay();
    }

    void Update()
    {
        if (unlocked)
        {
            door1.position = Vector3.MoveTowards(door1.position, door1TargetPos, moveSpeed * Time.deltaTime);
            door2.position = Vector3.MoveTowards(door2.position, door2TargetPos, moveSpeed * Time.deltaTime);
        }
    }
}
