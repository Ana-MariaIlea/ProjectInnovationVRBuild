using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsCollision : MonoBehaviour
{
    [SerializeField]
    Transform player;


    [SerializeField]
    int numberOfTests = 10;

    [SerializeField]
    List<Vector3> positions;
    int currentSound = 0;

    [SerializeField]
    public Vector3 size;


    Vector3 lastPosition;
    float time;

    List<TimeDistance> Performance = new List<TimeDistance>();

    private void Start()
    {

        lastPosition = player.position;
        UpdateSoundPosition();
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void GenerateRandomPositions()
    {
        positions.Clear();
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
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            return;
        }
        Vector3 position = positions[currentSound];
        transform.position = position;

        RecordPerformance();
        currentSound++;
    }

    void RecordPerformance() {
        float distance = (transform.position - lastPosition).magnitude;
        Performance.Add(new TimeDistance(time, distance));

        time = 0;
        lastPosition = player.position;
    }


    float AveragePerformance() {
        float sum = 0;
        for (int i = 0; i < Performance.Count; i++) {
            sum += Performance[i].timePerUnitOfDistance;
        }
        float average = sum/Performance.Count;
        return average;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<DemoPlayerController>() != null) {
            UpdateSoundPosition();
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Time required per unit of distance " + AveragePerformance());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawCube(transform.position, size);
    }

}

public class TimeDistance {
    float timeSpent=0;
    float distance = 0;
    public float timePerUnitOfDistance;

    public TimeDistance(float time, float distance) {
        timeSpent = time;
        this.distance = distance;

        timePerUnitOfDistance = timeSpent / this.distance;
    }
}
