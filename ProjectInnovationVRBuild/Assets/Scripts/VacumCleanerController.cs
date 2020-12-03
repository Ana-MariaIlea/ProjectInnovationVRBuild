using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacumCleanerController : MonoBehaviour
{
    public bool isMoving;

    public List<Vector3> positions;


    [SerializeField]
    float speed;

    int targetIndex =1;
    Vector3 target;


    float timer;

    [SerializeField]
    float colliderRange;


    public void EnableMoving() {
        Debug.Log("Enabled Vacum Cleaner");
        isMoving = true;
    }
    public void DisableMoving() {
        Debug.Log("Stopped vacum cleaner");
        isMoving = false;
    }

    private void Awake()
    {
    }


    private void Start()
    {
        transform.position = positions[0];
        target = positions[targetIndex];
        timer = 0;
    }


    void Update()
    {
        if (!isMoving) {
            return;
        }
        timer += Time.deltaTime;
        GoTo(target);
        if (ReachedTarget()) {
            getNextTarget();
        }
    }

    void GoTo(Vector3 target) {
        Vector3 differece = target - transform.position;
        Quaternion rotation = Quaternion.LookRotation(differece, Vector3.up);
        transform.rotation = rotation;
        transform.position += transform.forward * speed;
    }

    bool ReachedTarget() {
        Vector3 vectorDifference = target - transform.position;
        return vectorDifference.sqrMagnitude <= colliderRange;
    }

    void getNextTarget() {
        if (targetIndex >= positions.Count - 1)
        {
            return;
        }

        targetIndex++;
        int arrayIndex = targetIndex % positions.Count;
        
        
        target = positions[targetIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<DemoPlayerController>()) {
        //    Debug.Log("Time to catch the vacum cleaner" + timer);
        //    #if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //    #endif
        //    return;
        //}
    }

}
