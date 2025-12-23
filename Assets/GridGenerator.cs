using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    public GameObject plane;
    public float spacing = 0.3f;

    void Start()
    {
        GenerateGrid();
        
    }


    void GenerateGrid()
    {
        int gridSize = 33;
        float offset = ((gridSize - 1) * spacing)/2f;
        float planeY = plane.transform.position.y;

        for(int x = 0; x< gridSize; x++)
        {
            for(int z=0;z<gridSize;z++)
            {
                Vector3 position = new Vector3(
                    x * spacing  - offset,
                    planeY + 0.02f,
                    z * spacing - offset*4f
                );

                //デバッグ
                if(x < 2 && z < 2)
                {
                    Debug.Log($"Position [{x},{z}]: {position}");
                    Debug.Log($"spacing  {spacing}");

                }

                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = position;
                obj.transform.localScale = Vector3.one * 0.25f;

                //色分け
                 if((x+z)%2 == 1)
                 {
                    Renderer renderer = obj.GetComponent<Renderer>();
                    renderer.material.color = Color.black;

                 }
            }

        }
    }
}
