using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera aimVirtualCamera;

    [SerializeField] GameObject aimPanel;

    [SerializeField] HealthController healthController;

    [SerializeField] float normalSensitivity = 1.0f;

    [SerializeField] float aimSensitivity = 0.5f;

    [SerializeField] private GameObject panelGameOver;

    [SerializeField] private GameObject panelWin;

    [SerializeField] Animator animator;

    [Header("Health")]
    [SerializeField] int health = 100;

    ThirdPersonController _thirdPersonController;

    StarterAssetsInputs _starterAssetsInputs;

    int _currentHealth;

    public HealthBarController healthBarController;

    private void Start()
    {
        _currentHealth = health;
        healthBarController.SetMaxHealth(health);
    }

    private void Awake()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();

        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }

        if (_starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);

            _thirdPersonController.SetSensitivity(aimSensitivity);

            _thirdPersonController.SetRotateOnMove(false);

            aimPanel.SetActive(true);

            Vector3 mouseWorldPosition = Vector3.zero;

            Vector2 screenCenterPoint = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);

            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, 1000.0f))
            {
                mouseWorldPosition = raycastHit.point;
            }

            Vector3 worldAimTarget = mouseWorldPosition;

            worldAimTarget.y = transform.position.y;

            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 15.0f); //aimDirection;
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);

            _thirdPersonController.SetSensitivity(normalSensitivity);

            _thirdPersonController.SetRotateOnMove(true);

            aimPanel.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("ataque del enemigo");
            TakeDamage(4);
        }
        if (other.CompareTag("BulletEnemy"))
        {
            Debug.Log("ataque del enemigo");
            TakeDamage(4);
        }
        else if (other.CompareTag("Energy"))
        {
            if (_currentHealth < 100)
            {
                _currentHealth += Mathf.Abs(10);
                healthBarController.SetHealth(_currentHealth);
            }
        }
        else if (other.CompareTag("Win"))
        {
            Time.timeScale = 0.0f;
            Debug.Log("Consegui la mision");
            panelWin.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= Mathf.Abs(damage);

        healthBarController.SetHealth(_currentHealth);

        healthController.TakeDamage(damage);

        if (_currentHealth == 0)
        {
            animator.SetTrigger("dead");

            Time.timeScale = 0.0f;
            panelGameOver.SetActive(true);
        }
    }
}