using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public GameObject objToTP;
    public Transform tpLoc;

    Texture2D blk;
    public bool fade;
    public float alph;
    void Start()
    {
        blk = new Texture2D(1, 1);
        blk.SetPixel(0, 0, new Color(0, 0, 0, 0));
        blk.Apply();

    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blk);
    }

    void Update(){
	    if (Input.GetKeyDown(KeyCode.Z))
        {
            fade = !fade;
            
        }

        if (!fade)
        {
            if (alph > 0)
            {
                alph -= Time.deltaTime * .5f;
                if (alph < 0) { alph = 0f; }
                blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
                blk.Apply();
            }
            else
            {
                fade = false;
            }
        }
        
        if (fade)
        {
            if (alph < 1)
            {
                alph += Time.deltaTime * .5f;
                if (alph > 1) { alph = 1f; }
                blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
                blk.Apply();
            }
            else
            {
                objToTP.transform.position = tpLoc.transform.position;
                fade = !fade;
            }
        }


    }

	
}