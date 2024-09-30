using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SoundConfig movementSFX;
    [SerializeField] private AudioSource _compAudioSource;
    [SerializeField] private Rigidbody _compRigidbody;
    [SerializeField] private float velocity;
    private bool booleano = false;
    private Vector2 movement;

    void Awake()
    {
        _compAudioSource = GetComponent<AudioSource>();
        _compRigidbody = GetComponent<Rigidbody>();

        if (movementSFX != null)
        {
            _compAudioSource.clip = movementSFX.SoundClip;
        }
    }
    private void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector3(movement.x, _compRigidbody.velocity.y, movement.y);
    }
    private void Update()
    {
        PlaySoundMovement();
    }

    private void PlaySoundMovement()
    {
        if (booleano == true)
        {
            if (!_compAudioSource.isPlaying)
            {
                _compAudioSource.Play();
            }
        }
        else
        {
            _compAudioSource.Stop();
        }
    }
    public void ChangeScene2() 
    { 
            SceneManager.LoadScene("Scene2");
    }
 
    public void Movement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>() * velocity;
        booleano = movement.magnitude > 0;
    }
}
