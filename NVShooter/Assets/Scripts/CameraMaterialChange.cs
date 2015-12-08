using UnityEngine;
using System.Collections;

public class CameraMaterialChange : MonoBehaviour {

    public Material[] materialList;
    public GameObject[] parts;

    public CameraColors cameraColor;

    public enum CameraColors
    {
        BLUE,
        INDIGO,
        PURPLE,
        RED,
        ORANGE,
        YELLOW,
        GREEN,
        WHITE,
        BLACK,
        BROWN
    };

	// Use this for initialization
	void Start () {
        //parts = gameObject.GetComponentsInChildren<GameObject>();

        ChangeColor();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ChangeColor()
    {
        foreach (GameObject part in parts)
        {
            Renderer render = part.GetComponent<Renderer>();
            switch (cameraColor)
            {
                case CameraColors.BLACK:
                    render.material = materialList[(int)CameraColors.BLACK];
                    break;
                case CameraColors.BLUE:
                    render.material = materialList[(int)CameraColors.BLUE];
                    break;
                case CameraColors.BROWN:
                    render.material = materialList[(int)CameraColors.BROWN];
                    break;
                case CameraColors.GREEN:
                    render.material = materialList[(int)CameraColors.GREEN];
                    break;
                case CameraColors.INDIGO:
                    render.material = materialList[(int)CameraColors.INDIGO];
                    break;
                case CameraColors.ORANGE:
                    render.material = materialList[(int)CameraColors.ORANGE];
                    break;
                case CameraColors.PURPLE:
                    render.material = materialList[(int)CameraColors.PURPLE];
                    break;
                case CameraColors.RED:
                    render.material = materialList[(int)CameraColors.RED];
                    break;
                case CameraColors.WHITE:
                    render.material = materialList[(int)CameraColors.WHITE];
                    break;
                case CameraColors.YELLOW:
                    render.material = materialList[(int)CameraColors.YELLOW];
                    break;
                default:
                    Debug.Log("Problem with setting camera part color.");
                    break;
            }
        }
    }
}
