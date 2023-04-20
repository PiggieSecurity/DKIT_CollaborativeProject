using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Destroy : MonoBehaviour
{
    void onCollsionEnter(Collision other)
    {
        if (other.gameObject.tag == "AI")
        {
            Destroy((gameObject));
        }
    }
}

