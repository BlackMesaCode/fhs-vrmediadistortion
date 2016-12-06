using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImageManager : MonoBehaviour {

    public string imageFolder = @".\Assets\Images";
    private List<Material> materials;

	// Use this for initialization
	void Start () {

	}
	
    void Awake()
    {
        materials = GetMaterials(); 
    }

    private List<Material> GetMaterials()
    {
        var materials = new List<Material>();
        var jpgFiles = Directory.GetFiles(imageFolder, "*.jpg");
        var pngFiles = Directory.GetFiles(imageFolder, "*.png");

        var files = new string[jpgFiles.Length + pngFiles.Length];
        jpgFiles.CopyTo(files, 0);
        pngFiles.CopyTo(files, jpgFiles.Length);

        foreach (var file in files)
        {
            Texture2D tex = LoadImage(file);
            Material mat = CreateMat(tex);
            materials.Add(mat);
        }
        return materials;
    }


	// Update is called once per frame
	void Update () {
		
	}

    public Material GetRandomMaterial()
    {
        var randomIndex = Random.Range(0, materials.Count - 1);
        return materials[randomIndex];
    }

    private static Texture2D LoadImage(string filePath)
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            if (fileData == null || fileData.Length == 0)
                Debug.Log($"{filePath} is null");
            tex = new Texture2D(2, 2);
            if (!tex.LoadImage(fileData))
                Debug.Log("Load image failed for: " + filePath);
        }
        else
            Debug.Log("missing: " + filePath);
        return tex;
    }

    private Material CreateMat(Texture2D texture)
    {
        Material mat = new Material(Shader.Find("Standard"));
        mat.SetTexture("_MainTex", texture);
        mat.color = Color.white;
        return mat;
    }
}
