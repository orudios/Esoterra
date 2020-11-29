using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Outline : MonoBehaviour
{
    public Shader solidColourShader;
	public Shader outlineShader;
	Material outlineMaterial;
	Camera outlineCam;
	float[] kernel;


    void Start()
    {
        outlineMaterial = new Material(outlineShader);
        outlineCam = new GameObject().AddComponent<Camera>();
        kernel = GaussianKernel(5, 20);
    }
	
	// Post-processing
	void OnRenderImage(RenderTexture source, RenderTexture dest)
    {
        // Prepare camera to render outline
		outlineCam.CopyFrom(Camera.current);
		outlineCam.backgroundColor = Color.black;
		outlineCam.clearFlags = CameraClearFlags.Color;
        outlineCam.cullingMask = 1 << LayerMask.NameToLayer("Outline");
		
        // Allocate texture
		var renderTexture = RenderTexture.GetTemporary(
            source.width, source.height, 0, RenderTextureFormat.R8);

        // Render texture
		outlineCam.targetTexture = renderTexture;
        outlineCam.RenderWithShader(solidColourShader, "");

        // Gaussian blur
		outlineMaterial.SetFloatArray("kernel", kernel);
		outlineMaterial.SetInt("_kernelWidth", kernel.Length);
		outlineMaterial.SetTexture("_SceneTex", source);
		
		// Copy texture to destination
		renderTexture.filterMode = FilterMode.Point;
		Graphics.Blit(renderTexture, dest, outlineMaterial);

        // Release texture
        outlineCam.targetTexture = source;
		RenderTexture.ReleaseTemporary(renderTexture);
	}

    float[] GaussianKernel(double sigma, int size)
	{
		float[] ret = new float[size];
		double sum = 0;
		int half = size / 2;
		for (int i = 0; i < size; i++)
		{
            // Gaussian function
			ret[i] = (float)(
                1 / (Mathf.Sqrt(2 * Mathf.PI) * sigma)
                * Mathf.Exp((float)(
                    -(i - half) * (i - half) / (2 * sigma * sigma))
                )
            );
			sum += ret[i];
		}
		return ret;
	}
}