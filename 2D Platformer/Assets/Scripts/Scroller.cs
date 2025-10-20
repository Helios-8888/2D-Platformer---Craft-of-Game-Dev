using UnityEngine;

public class Scroller : MonoBehaviour
{
    int numLayers;
    Transform[] layers;
    public float[] layerFactor;
    public Camera attachedCam;
    Vector3 initialPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numLayers = layerFactor.Length;
        layers = new Transform[numLayers];  
        initialPos = attachedCam.transform.position;    

        for (int i = 0; i< numLayers; i++)
        {
            layers[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = attachedCam.transform.position - initialPos;
        for (int i = 0; i < numLayers; i++)
        {
            Vector3 scaledOffset = offset * layerFactor[i];
            layers[i].transform.localPosition = new Vector3(scaledOffset.x, scaledOffset.y, 0f);
        }
    }
}
