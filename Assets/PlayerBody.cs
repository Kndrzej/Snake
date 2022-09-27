using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public delegate void PlayerCollisionAction();
    public static event PlayerCollisionAction OnPlayerCollision;
    public delegate void ResetGameAction();
    public static event ResetGameAction OnGameReset;
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
    public void Shrink()
    {
        if (segments.Count > 1)
        {
            Destroy(segments[segments.Count - 1].gameObject);
            segments.RemoveAt(segments.Count - 1);
        }
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
        if (other.tag == "PowerUp")
        {
            OnPlayerCollision();

        }
        else if (other.tag == "Player")
        {
            OnGameReset();
            ResetGame();
        }
        else
        {
            Debug.Log("niewiem co to");

        }
    }
}
