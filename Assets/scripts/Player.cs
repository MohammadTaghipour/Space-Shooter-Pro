using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private float _speedMultiplyer = 2;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotlaserPrefab;
    [SerializeField]
    private float _fireRate = 0.1f;
    private float _nextFire;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    // variable for isTripleShotActive
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private bool _isSpeedBoostActive = false;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _speed = 10f;
        _fireRate = 0.1f;
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The SpawnManager is null!");
        }
    }

    void Update()
    {
        CalculateMovement();

        // if i hit the space key
        // spawn gameObject

        if (Input.GetKey(KeyCode.Space) && (Time.time > _nextFire))
        {
            _nextFire = Time.time + _fireRate;
            // Vector3 laserPosition = transform.position;
            // laserPosition.y += 0.8f;
            if (_isTripleShotActive)
            {
                Instantiate(_tripleShotlaserPrefab, transform.position + new Vector3(0, 1.032f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.032f, 0), Quaternion.identity);    
            }
            // instantiate 3 lasers (triple shot prefab)

        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 _direction = new Vector3(horizontalInput, verticalInput, 0);

        if (_isSpeedBoostActive)
        {
            transform.Translate(_direction * _speed * _speedMultiplyer * Time.deltaTime);
        }
        else
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        if (transform.position.x < -11.4f)
        {
            transform.position = new Vector3(11.4f, transform.position.y, 0);
        }
        else if (transform.position.x > 11.4f)
        {
            transform.position = new Vector3(-11.4f, transform.position.y, 0);
        }
        transform.position = new Vector3(transform.position.x,
             Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
    }

    public void Damage()
    {
        _lives--;
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        // tripleshotactive becomes true
        // start the power down coroutine for triple shot

        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    
    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        while (_isTripleShotActive)
        {
            yield return new WaitForSeconds(5.0f);
            _isTripleShotActive = false;
        }
        
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        while (_isSpeedBoostActive)
        {
            yield return new WaitForSeconds(5.0f);
            _isSpeedBoostActive = false;
        }
    }
}