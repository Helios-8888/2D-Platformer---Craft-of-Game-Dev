using UnityEditor.Rendering;
using UnityEngine;

public class scscsc :MonoBehaviour
{
    public float NME = 1.2f;
    public float lifeOrb = 1.333f;
    public float Tailwind = 2;

    private void Start()
    {
        Debug.Log(lifeOrb);
        Debug.Log(Tailwind);

        for (int i = 1000; i > 0; i -= 7)
        {
            Debug.Log(i);
        }
    }
}
