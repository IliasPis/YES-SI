using System.Collections;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void TakeScreenshot()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        yield return new WaitForEndOfFrame();

        // Capture the screenshot
        Texture2D screenImage = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();

        // Encode texture into PNG
        byte[] imageBytes = screenImage.EncodeToPNG();
        string base64Image = System.Convert.ToBase64String(imageBytes);

        // Call the JavaScript function to download the image
        Application.ExternalCall("DownloadImage", base64Image);
    }
}
