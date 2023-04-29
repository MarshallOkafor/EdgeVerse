using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FrameRateLogger : MonoBehaviour
{
    public string fileName = "frame_rate_data_edge.txt";
    private string filePath;
    private List<float> frameRates = new List<float>();
    private float elapsedTime = 0.0f;
    private int maxLines = 100;
    private float maxTime = 180.0f; // 3 minutes in seconds

    // Start is called before the first frame update
    void Start()
    {
        string folderPath = Path.Combine(Application.streamingAssetsPath);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        filePath = Path.Combine(folderPath, fileName);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate frame rate
        float frameRate = 1.0f / Time.deltaTime;
        frameRates.Add(frameRate);

        // Update elapsed time
        elapsedTime += Time.deltaTime;

        // Stop collecting data after maxLines or maxTime
        if (frameRates.Count >= maxLines || elapsedTime >= maxTime)
        {
            OnApplicationQuit();
            enabled = false; // Disable the script
        }
    }

    void OnApplicationQuit()
    {
        // Save frame rate data to a file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (float frameRate in frameRates)
            {
                writer.WriteLine(frameRate);
            }
        }
    }
}
