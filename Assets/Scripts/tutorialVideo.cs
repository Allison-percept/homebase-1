using UnityEngine;
using UnityEngine.Video;
using Unity.XR.CompositionLayers;
using Unity.XR.CompositionLayers.Extensions;
using Unity.XR.CompositionLayers.Layers;
using Unity.XR.CompositionLayers.Services;



public class tutorialVideo : MonoBehaviour

{


    [Tooltip("Drag tutorial video to here")] public VideoClip clip;
    public int clipWidth = 1024;
    public int clipHeight = 1024;
    [Tooltip("External render texture matching clip, no need to change with clip")] public RenderTexture videoTex;
    
    
    private CompositionLayer overlay;



    private VideoPlayer player;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make a VideoPlayer
        player = gameObject.AddComponent<VideoPlayer>();
        player.playOnAwake = true;
        player.isLooping = true;
        player.clip = clip;

        // create a render texture to render video to
        //videoTex = new RenderTexture(clipWidth, clipHeight, 0, RenderTextureFormat.ARGB32);
        //videoTex.Create();

        // direct video player output to texture
        player.renderMode = VideoRenderMode.RenderTexture;
        player.targetTexture = videoTex;


        overlay = gameObject.AddComponent<CompositionLayer>();
        overlay.ChangeLayerDataType(typeof(QuadLayerData));
        overlay.AddSuggestedExtensions();

        overlay.GetComponent<TexturesExtension>().LeftTexture = videoTex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
