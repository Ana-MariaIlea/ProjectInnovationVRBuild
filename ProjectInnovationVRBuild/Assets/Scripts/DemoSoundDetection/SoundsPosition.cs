using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPosition : MonoBehaviour
{
    [SerializeField]
    int numberOfTests = 10;

    [SerializeField]
    List<Vector3> positions;
    int currentSound = 0;

    [SerializeField]
    public Vector3 size;

    private void Start()
    {
        GenerateRandomPositions();
        UpdateSoundPosition();
    }

    void GenerateRandomPositions()
    {
        for (int i = 0; i < numberOfTests; i++)
        {

            float positionX = Random.Range(0, size.x) - (size.x / 2.0f);
            float positionY = Random.Range(0, size.y) - (size.y / 2.0f);
            float positionZ = Random.Range(0, size.z) - (size.z / 2.0f);
            Vector3 RelativePositionRange = new Vector3(positionX, positionY, positionZ);
            positions.Add(RelativePositionRange + transform.position);
        }

    }

    public void UpdateSoundPosition() {
        if (currentSound >= positions.Count) {
            FindObjectOfType<monogmail>().SendData(FindObjectOfType<TargetSound>().GetStats(), "DetectSoundDirection");


            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
            return;
        }
        Vector3 position = positions[currentSound];
        transform.position = position;
        currentSound++;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawCube(transform.position, size);
    }

}
