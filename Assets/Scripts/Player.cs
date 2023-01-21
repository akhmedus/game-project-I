using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotateSpeed;
    public AudioClip moveClip;
    public AudioClip endClip;

    public Gameplay gameplay;
    public GameObject prefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            SoundManager.Instance.PlaySound(moveClip);
            rotateSpeed *= 1;
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Instantiate(prefab, transform.GetChild(0).position, Quaternion.identity);
            SoundManager.Instance.PlaySound(endClip);
            gameplay.GameFinish();
            Destroy(gameObject);
        }
    }
}
