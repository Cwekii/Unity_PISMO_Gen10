using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QRCodeScaner : MonoBehaviour
{
   [SerializeField] private TMP_Text scannedText;
   
   [SerializeField] private RawImage rawImage;
   [SerializeField] private AspectRatioFitter aspectRatioFitter;
   [SerializeField] private RectTransform scanZone;
   

   private bool isCameraAvailable;
   private WebCamTexture webcamTexture;


   private void Start()
   {
      SetUpCamera();
   }

   private void Update()
   {
      UpdateCameraRender();
      Scan();
   }

   private void SetUpCamera()
   {
      WebCamDevice[] devices = WebCamTexture.devices;
      
      if (devices.Length == 0)
      {
         isCameraAvailable = false;
         return;
      }

      for (int i = 0; i < devices.Length; i++)
      {
         if (!devices[i].isFrontFacing)
         {
            webcamTexture = new WebCamTexture(devices[i].name,(int) scanZone.rect.width,(int) scanZone.rect.height);
         }
      }
      
      webcamTexture.Play();
      rawImage.texture = webcamTexture;
      isCameraAvailable = true;
      
   }

   private void UpdateCameraRender()
   {
      if (!isCameraAvailable)
      {
         return;
      }
      
      float ratio = (float)webcamTexture.width / (float)webcamTexture.height;
      aspectRatioFitter.aspectRatio = ratio;
      
      int orientation = webcamTexture.videoRotationAngle;
      rawImage.rectTransform.localEulerAngles = new Vector3(0, 0, -orientation);
   }

   public void StartScan()
   {
      Scan();
   }


   private void Scan()
   {
      scannedText.color = Color.white;
      try
      {
         IBarcodeReader barcodeReader = new BarcodeReader();
         Result result = 
            barcodeReader.Decode(
               webcamTexture.GetPixels32(),
               webcamTexture.width,
               webcamTexture.height);

         if (result != null)
         {
            scannedText.text = result.Text;
            Application.OpenURL(result.Text);
            Debug.Log($"Scanned");
         }
         else
         {
            scannedText.color = Color.red;
            scannedText.text = "Not detected";
         }
      }
      catch (Exception e)
      {
            scannedText.text = $"Failed to scan: {e.Message}";
            throw;
      }
   }
   
   
}
