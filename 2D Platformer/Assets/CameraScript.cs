using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Camera playerCam;
    public Transform playerTarget;
    public float blendAmount = 0.05f;
    public float boxSizeX, boxSizeY = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerTarget.transform.position;
        Vector3 cameraPos = transform.position;
        float camX, camY;
        camX = cameraPos.x;
        camY = cameraPos.y;
        float screenX0, screenX1, screenY0, screenY1;
        float box_x0, box_x1, box_y0, box_y1;
        box_x0 = playerPos.x - boxSizeX;
        box_x1 = playerPos.x + boxSizeX;
        box_y0 = playerPos.y - boxSizeY;
        box_y1 = playerPos.y + boxSizeY;
        Vector3 bottomLeft = playerCam.ViewportToWorldPoint(new Vector3(0, 0,
        0));
        Vector3 topRight = playerCam.ViewportToWorldPoint(new Vector3(1, 1, 0));
        screenX0 = bottomLeft.x;
        screenX1 = topRight.x;
        if (box_x0 < screenX0)
            camX = playerPos.x + 0.5f * (screenX1 - screenX0) - boxSizeX;
        else if (box_x1 > screenX1)
            camX = playerPos.x - 0.5f * (screenX1 - screenX0) + boxSizeX;
        screenY0 = bottomLeft.y;
        screenY1 = topRight.y;
        if (box_y0 < screenY0)
            camY = playerPos.y + 0.5f * (screenY1 - screenY0) - boxSizeY;
        else if (box_y1 > screenY1)
            camY = playerPos.y - 0.5f * (screenY1 - screenY0) + boxSizeY;
        transform.position = new Vector3(camX, camY, cameraPos.z);
    }
}

