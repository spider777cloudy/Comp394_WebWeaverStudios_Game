using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxController : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distance;
    
    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;
    [Range(0.01f,0.05f)]
    public float parallaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i<backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        BackspeedCalculate(backCount);
    }

    void BackspeedCalculate(int backCount)
    {
        for(int i = 0; i < backCount; i++)
        {
            if((backgrounds[i].transform.position.z - cam.position.z)>farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i< backCount; i++)
        {
            backSpeed[i] =1-(backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
            
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        for (int i = 0; i< backgrounds.Length; i++)
        {
            float speed = backSpeed[i]*parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}