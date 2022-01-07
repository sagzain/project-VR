using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PhotoCamera : MonoBehaviour
{
    [Header("Camera")]
    [Tooltip("Camera inside the PhotoCamera prefab that is going to take the photo.")]
    [SerializeField] private Camera _camera;
    [Tooltip("Output transform where we are going to instantiate the photo taken.")]
    [SerializeField] private Transform _output;
    [Tooltip("Sound that is going to be played when camera is activated.")]
    [SerializeField] private AudioClip _cameraSound;

    [Header("Photo")]
    [Tooltip("Photo prefab that is going to be instantiated when the camera is activated.")]
    [SerializeField] private GameObject _photoPrefab;

    [Range(2, 4)]
    [Tooltip("Delay until camera can be used again. The min value is matching the length of the camera sound.")]
    [SerializeField] private int _photoDelay;

    private bool _canShot; // Boolean variable to ensure the camera has a delay.
    private AudioSource _audioSource; // Audio source used to play the shoting sound.

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _canShot = true;
    }

    /*
        Public method that is called by the Activated Event on the 
        XR Offset Interactable script
    */
    public void TakeShot()
    {
        if (_canShot)
        {
            StartCoroutine(TakeShotRoutine());
        }
    }

    /*
        Method that takes the RenderTexture from the camera and transforms 
        it into a material, then instantiates a new photo where it is assigned.
        Once the photo is instantiated bool _canShot is setted to false and
        ShotingDelay coroutine is started in order to wait _photoDelay seconds
        until the next shot.
    */
    IEnumerator TakeShotRoutine()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture renderTexture = _camera.targetTexture;
        Texture2D photoTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        photoTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        // photoTexture.LoadRawTextureData(photoTexture.GetRawTextureData());
        photoTexture.Apply();

        Material photoMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        photoMaterial.mainTexture = photoTexture;

        var go = Instantiate(_photoPrefab, _output.position, _photoPrefab.transform.rotation);
        go.transform.localScale = _photoPrefab.transform.localScale;
        go.transform.Find("Image").GetComponent<MeshRenderer>().material = photoMaterial;

        _audioSource.PlayOneShot(_cameraSound);

        _canShot = false;
        StartCoroutine(ShotingDelay());
    }


    /*
        Coroutine that waits _photoDelay seconds and then sets the
        _canShot boolean to true in order to be able to take another
        shot.
    */
    IEnumerator ShotingDelay()
    {
        yield return new WaitForSeconds(_photoDelay);
        _canShot = true;
    }
}
