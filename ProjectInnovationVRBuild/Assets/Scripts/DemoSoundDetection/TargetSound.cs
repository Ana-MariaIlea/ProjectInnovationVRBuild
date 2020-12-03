using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSound : MonoBehaviour
{
    [SerializeField]
    GameObject soundTarget;

    public float angleAccesptance = 50.0f;

    int wins=0;
    int loses=0;


    monogmail gmail;

    private void Start()
    {
       // gmail = GetComponent<monogmail>();
       // Debug.Log(gmail.name);
    }

    public string GetStats() {
        return (wins + " / " + loses + " = " + ((float)wins) / ((float)loses + wins) * 100 + "%");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            float angle =GetAngle();
            if (angle < angleAccesptance) {
                wins++;
            }
            else {
                loses++;
            }
            soundTarget.GetComponent<SoundsPosition>().UpdateSoundPosition();
        }
    }


    float GetAngle() {
        Vector3 difference = soundTarget.transform.position - this.transform.position;
        float angles=0.0f;


        float length1 = transform.forward.magnitude;
        float length2 = difference.magnitude;


        float dotProduct = Vector3.Dot(transform.forward, difference);


        //if (dotProduct < -1)
        //{
        //    Debug.Log("look to opposite direction");
        //    angles = -1w
        //}
        //else {
            float anglesRadians = Mathf.Acos(dotProduct / (length1 * length2));
            angles = anglesRadians *  Mathf.Rad2Deg;

            Debug.Log(angles);
        //}

        return angles;
    }

}
