using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPos;

    // Set Z offset = -10
    public Vector3 offset;

    private static bool cameraExists;

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (boundBox == null)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name != "Menu")
            {
               boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
               minBounds = boundBox.bounds.min;
               maxBounds = boundBox.bounds.max; 
            }
        }
        
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, followTarget.transform.position.z);
        transform.position = targetPos + offset;

        if (boundBox == null)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name != "Menu")
            {
               boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
               minBounds = boundBox.bounds.min;
               maxBounds = boundBox.bounds.max; 
            }
        }

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void SetBounds(BoxCollider2D newBounds)
    {
        boundBox = newBounds;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max; 
    }
}
