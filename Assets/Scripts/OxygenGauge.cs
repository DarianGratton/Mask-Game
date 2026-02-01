using UnityEngine;

public class OxygenGauge : MonoBehaviour
{
    public Oxygen oxygenTracker;

    private RectTransform rectTransform;
    [SerializeField]
    private float initialWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialWidth = rectTransform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float oxygenPercent = oxygenTracker.GetOxygenPercent();

        Vector3 scale = rectTransform.localScale;
        scale.x = initialWidth * oxygenPercent;
        rectTransform.localScale = scale;
    }
}
