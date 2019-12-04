using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisorderSystem : MonoBehaviour {

    public static DisorderSystem instance;

    public GameObject cameraParent;
    public GameObject earObject;

    private List<Behaviour> activeVisualDisorders;
    private List<Behaviour> activeAudioDisorders;
    private List<Behaviour> activeCognitiveDisorders;

    [SerializeField]
    private GameObject tinnitusSource;
    // [SerializeField]
    // private GameObject panicAttackSource;
    public void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {

        activeVisualDisorders = new List<Behaviour>();
        activeAudioDisorders = new List<Behaviour>();
        activeCognitiveDisorders = new List<Behaviour>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Achromatopsia()
    {

        foreach (UnityStandardAssets.ImageEffects.Grayscale comp in cameraParent.GetComponents< UnityStandardAssets.ImageEffects.Grayscale>())
        {
            activeVisualDisorders.Add(comp);
            comp.enabled = true;
        }
    }

    public void Protanopia()
    {
        foreach (ColorBlindFilter filter in cameraParent.GetComponents<ColorBlindFilter>())
        {
            activeVisualDisorders.Add(filter);
            filter.mode = ColorBlindMode.Protanopia;
            filter.enabled = true;
        }
    }

    public void Deuteranopia()
    {
        foreach (ColorBlindFilter filter in cameraParent.GetComponents<ColorBlindFilter>())
        {
            activeVisualDisorders.Add(filter);
            filter.mode = ColorBlindMode.Deuteranopia;
            filter.enabled = true;
        }
    }

    public void Tritanopia()
    {
        foreach (ColorBlindFilter filter in cameraParent.GetComponents<ColorBlindFilter>())
        {
            activeVisualDisorders.Add(filter);
            filter.mode = ColorBlindMode.Tritanopia;
            filter.enabled = true;
        }
    }


    
    public void PartialBlindness()
    {

        int random = Random.Range(0, 2);

        UnityStandardAssets.ImageEffects.BlurOptimized comp = cameraParent.GetComponents<UnityStandardAssets.ImageEffects.BlurOptimized>()[random];

        activeVisualDisorders.Add(comp);
        comp.enabled = true;



    }

    /*public void Prosopagnosia()
    {

        leftPersonRenderer.material.mainTexture = (Texture)leftPersonBlankFace;
        rightPersonRenderer.material.mainTexture = (Texture)rightPersonBlankFace;

    }*/

    public void LegalBlindness()
    {

        foreach (UnityStandardAssets.ImageEffects.BlurOptimized comp in cameraParent.GetComponents<UnityStandardAssets.ImageEffects.BlurOptimized>())
        {
            activeVisualDisorders.Add(comp);
            comp.enabled = true;
        }
    }

    public void Deafness()
    {
        
        AudioLowPassFilter filter = earObject.GetComponent<AudioLowPassFilter>();

        activeAudioDisorders.Add(filter);
        filter.enabled = true;
    }

    public void Tinnitus()
    {
        AudioSource source = tinnitusSource.GetComponent<AudioSource>();

        activeAudioDisorders.Add(source);
        source.enabled = true;
    }

    // public void PanicAttack()
    // {
    //     AudioSource[] source = panicAttackSource.GetComponents<AudioSource>();

    //     activeAudioDisorders.Add(source[1]);
    //     // source.enabled = true;
    //     source[1].Play();
    // }


    
    public void PanicAttack()
    {

        foreach (UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration comp in cameraParent.GetComponents<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>()) 
        {
            activeCognitiveDisorders.Add(comp);
            comp.enabled = true;
        }

        GetComponent<AudioSource>().enabled = true;
        GetComponent<AudioSource>().Play();
        activeCognitiveDisorders.Add(GetComponent<AudioSource>());

        cameraParent.GetComponent<Animator>().enabled = true;
        cameraParent.GetComponent<Animator>().Play("PanicAnimation");
        activeCognitiveDisorders.Add(cameraParent.GetComponent<Animator>());

    }

    /*

    public void ReturnVisual()
    {

        Return(DisorderButton.DisorderType.VISUAL);

    }

    public void ReturnAuditory()
    {

        Return(DisorderButton.DisorderType.AUDITORY);

    }
    public void ReturnCognitive()
    {

        Return(DisorderButton.DisorderType.COGNITIVE);

    }

    */
    public void RemoveFilter()
    {

        while (activeVisualDisorders.Count > 0)
        {
            activeVisualDisorders[0].enabled = false;
            activeVisualDisorders.RemoveAt(0);

        }
        while (activeAudioDisorders.Count > 0)
        {
            activeAudioDisorders[0].enabled = false;
            activeAudioDisorders.RemoveAt(0);

        }
        while (activeCognitiveDisorders.Count > 0)
        {
            activeCognitiveDisorders[0].enabled = false;
            activeCognitiveDisorders.RemoveAt(0);

        }
    }
}
