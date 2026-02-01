using UnityEngine;

public class OxygenGauge : MonoBehaviour
{
    public Oxygen oxygenTracker;
    public RectTransform circleTransform;

    private RectTransform lineTransform;
    [SerializeField]
    private float initialWidth, initalCirclePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineTransform = GetComponent<RectTransform>();
        initialWidth = lineTransform.localScale.x;

        initalCirclePos = circleTransform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float oxygenPercent = oxygenTracker.GetOxygenPercent();

        Vector3 scale = lineTransform.localScale;
        scale.x = initialWidth * oxygenPercent;
        lineTransform.localScale = scale;

        Vector3 circlePos = circleTransform.position;
        circlePos.x = oxygenPercent * initalCirclePos + 20;
        Debug.Log(circlePos.x);
        circleTransform.position = circlePos;
    }
}
