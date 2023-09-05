using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrail : MonoBehaviour
{
    SkinnedMeshRenderer[] skinnedMeshRenderers;

    private bool isCon = false;
    public string shaderVarRef;
    public Transform playerTransform;
    public static bool StartTrail = false;
    private float time = 0;
    public Material material;
    public Color[] myColor;
    private Color currentColor;
    private int ColorIndex = 2;
    public float LerpSpeed;
    public float ColorIndexSpeed;

    private void Start()
    {
        Color currentColor = myColor[0];
        StartCoroutine(changeColorIndex());
    }
    private void Update()
    {
        if (isCon == false)
        { StartCoroutine(trail()); }

        currentColor = Color.Lerp(currentColor, myColor[ColorIndex], LerpSpeed * Time.deltaTime);
    }


    public IEnumerator trail()
    {
        while (StartTrail == true)
        {
            time += Time.deltaTime;

            isCon = true;
            if (skinnedMeshRenderers == null)
                skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();




            for (int i = 0; i < skinnedMeshRenderers.Length; i++)

            {
                GameObject gameObject = new GameObject();
                gameObject.transform.SetLocalPositionAndRotation(playerTransform.position, playerTransform.rotation);


                MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
                MeshFilter mf = gameObject.AddComponent<MeshFilter>();

                Mesh mesh = new Mesh();
                skinnedMeshRenderers[i].BakeMesh(mesh);

                mf.mesh = mesh;
                material.color = currentColor;
                mr.material = material;


                StartCoroutine(materialFade(mr.material));
                Destroy(gameObject, 3f);
            }



            yield return new WaitForSeconds(0.01f);
        }

        time = 0;
        isCon = false;

    }

    IEnumerator materialFade(Material mat)
    {
        float valueToAnimate = mat.GetFloat(shaderVarRef);

        while (valueToAnimate > 0)
        {
            valueToAnimate -= 0.05f;
            mat.SetFloat(shaderVarRef, valueToAnimate);
            yield return new WaitForSeconds(0.005f);

        }

    }

    IEnumerator changeColorIndex()
    {
        while (true)
        {
            ColorIndex++;
            if (ColorIndex >= myColor.Length)
                ColorIndex = 0;
            yield return new WaitForSeconds(ColorIndexSpeed);
        }
    }
}
