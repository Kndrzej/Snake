using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public static PlayerBody Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public List<Transform> segments;
    [SerializeField] private Transform segmentPrefab;
    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }
    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
    public void ResetGame()
    {
        for (int i = 1; i < segments.Count; i++) Destroy(segments[i].gameObject);
        segments.Clear();
        segments.Add(this.transform);
        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "PowerUp")
        {
            ResetGame();
        }
    }
}
