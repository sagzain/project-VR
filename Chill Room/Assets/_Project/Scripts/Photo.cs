using System.Collections;
using UnityEngine;


public class Photo : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(AnimatePhoto());
    }

    IEnumerator AnimatePhoto()
    {
        yield return new WaitForSeconds(.1f);

        transform.SetParent(null);
    }
}
