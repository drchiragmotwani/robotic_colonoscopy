using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scopeControl : MonoBehaviour
{
    private GameObject frontSection, colonoscope, colon;
    // private GameObject[] backSectionsArray;
    private float scrollDir;
    private Vector3 previousSectionAngles, currentSectionAngles;
    private float scopeSpeed = 5f;
    private float stiffnessFactor = 15;
    private float intracolonicPressure = 37;
    private List<Transform> sections;
    public Light scopeLight;
    public Text pressure;

    // Start is called before the first frame update
    void Start()
    {
        scopeLight.intensity = 0.5f;
        colon = GameObject.Find("colon");
        colonoscope = GameObject.Find("colonoscope");
        frontSection = GameObject.FindGameObjectWithTag("frontSec");
        previousSectionAngles = frontSection.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        pressure.text = intracolonicPressure.ToString() + " mm Hg";
        scrollDir = Input.mouseScrollDelta.y;
        Debug.Log("PRE: " + previousSectionAngles);

        if (Input.GetKey(KeyCode.UpArrow)) {
            frontSection.transform.Translate(new Vector3(0, 0, scopeSpeed*Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            frontSection.transform.Translate(new Vector3(0, 0, -scopeSpeed*Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            frontSection.transform.Translate(new Vector3(scopeSpeed*Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            frontSection.transform.Translate(new Vector3(-scopeSpeed*Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            frontSection.transform.Rotate(stiffnessFactor*Time.deltaTime, 0, 0);
            previousSectionAngles = frontSection.transform.localEulerAngles;
        }

        if (Input.GetKey(KeyCode.S))
        {
            frontSection.transform.Rotate(-stiffnessFactor*Time.deltaTime, 0, 0);
            previousSectionAngles = frontSection.transform.localEulerAngles;
        }

        if (Input.GetKey(KeyCode.A))
        {
            frontSection.transform.Rotate(0, stiffnessFactor*Time.deltaTime, 0);
            previousSectionAngles = frontSection.transform.localEulerAngles;
        }

        if (Input.GetKey(KeyCode.D))
        {
            frontSection.transform.Rotate(0, -stiffnessFactor*Time.deltaTime, 0);
            previousSectionAngles = frontSection.transform.localEulerAngles;
        }

        if (Input.GetMouseButton(0) && scrollDir == 0)
        {
            float inflateVal = 0.005f*Time.deltaTime;
            colon.transform.localScale += new Vector3(inflateVal, inflateVal, inflateVal);
            intracolonicPressure += 0.05f;
        }

        if (Input.GetMouseButton(1))
        {
            float suctionVal = 0.005f*Time.deltaTime;
            colon.transform.localScale -= new Vector3(suctionVal, suctionVal, suctionVal);
            intracolonicPressure -= 0.05f;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            scopeLight.intensity += 0.05f;
        }

        if (Input.GetKey(KeyCode.X))
        {
            scopeLight.intensity -= 0.05f;            
        }

        if (Input.GetMouseButton(0) && scrollDir == 1)
        {
            stiffnessFactor += 1;
        }

        if (Input.GetMouseButton(0) && scrollDir == -1)
        {
            stiffnessFactor -= 1;
        }
    }
}
