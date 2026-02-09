using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float duration = 2f;

    private float timer;

    private bool isRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = duration;
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Debug.Log("Timer ran out");
        }
    }
}
