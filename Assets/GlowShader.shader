using System.Collections;
using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    private Renderer renderer;
    private Material originalMaterial;
    private Material glowMaterial;
    private Coroutine glowCoroutine;

    public void StartGlow(Color glowColor)
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
        glowMaterial = new Material(originalMaterial);
        //glowMaterial.SetColor("_EmissionColor", glowColor);
        glowMaterial.color = Color.green;
        renderer.material = glowMaterial;
        glowCoroutine = StartCoroutine(RemoveGlowEffect());
    }

    private IEnumerator RemoveGlowEffect()
    {
        yield return new WaitForSeconds(2f);
        renderer.material = originalMaterial;
        Destroy(this);
    }
}
