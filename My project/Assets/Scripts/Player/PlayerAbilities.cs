using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAbilities : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI qText;
    [SerializeField] private TextMeshProUGUI eText;
    [SerializeField] private TextMeshProUGUI rText;

    [SerializeField] private float qTimer;
    [SerializeField] private float eTimer;
    [SerializeField] private float rTimer;
    private float currentQTimer;
    private float currentETimer;
    private float currentRTimer;

    private void Start()
    {
        currentQTimer = qTimer;
        currentETimer = eTimer;
        currentRTimer = rTimer;
    }

    private void Update()
    {
        currentQTimer -= Time.deltaTime;
        currentETimer -= Time.deltaTime;
        currentRTimer -= Time.deltaTime;

        qText.text = $"Q\n{currentQTimer.ToString("0.0")}";
        eText.text = $"E\n{currentETimer.ToString("0.0")}";
        rText.text = $"R\n{currentRTimer.ToString("0.0")}";


        if (currentQTimer <= 0f)
        {
            qText.text = $"Q\nReady";
        }

        if (currentETimer <= 0f)
        {
            eText.text = $"E\nReady";
        }

        if (currentRTimer <= 0f)
        {
            rText.text = $"R\nReady";
        }

        if (Input.GetKeyDown(KeyCode.Q) && currentQTimer <= 0f)
        {
            currentQTimer = qTimer;
        }

        if (Input.GetKeyDown(KeyCode.E) && currentETimer <= 0f)
        {
            currentETimer = eTimer;
        }

        if (Input.GetKeyDown(KeyCode.R) && currentRTimer <= 0f)
        {
            currentRTimer = rTimer;
        }
    }
}
