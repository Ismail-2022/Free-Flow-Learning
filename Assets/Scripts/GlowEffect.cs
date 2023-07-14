using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    private bool hasGlowEffect = false;
    private float glowDuration = 2.0f;
    private float glowTimer = 0.0f;
    private Material originalMaterial;
    public Material glowMaterial;

    private void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (hasGlowEffect)
        {
            glowTimer += Time.deltaTime;
            if (glowTimer >= glowDuration)
            {
                hasGlowEffect = false;
                GetComponent<Renderer>().material = originalMaterial;
            }
        }
    }

    public void ApplyGlowEffect()
    {
        if (!hasGlowEffect)
        {
            hasGlowEffect = true;
            glowTimer = 0.0f;
            GetComponent<Renderer>().material = glowMaterial;
        }
    }
}
