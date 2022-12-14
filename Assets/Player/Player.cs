using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.InputSystem;



[RequireComponent(typeof(CharacterController),typeof(PlayerInput))]

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private Animator animator;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform barrelTransform;
    [SerializeField]
    private Transform bulletParent;

    [SerializeField]
    private GameObject construction;
    [SerializeField]
    private Transform turretTransform;

    public int numTuercas;


    public float playerSpeed = 7f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public float rotationSpeed = 3f;
    public float bulletDistance = 25f;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;
    private InputAction constructAction;



    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        PlayerInput playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        constructAction = playerInput.actions["Construct"];
        animator = GetComponent<Animator>();

        
    }

    private void OnEnable()
    {
        shootAction.performed += _ => ShootGun();
        constructAction.performed += _ => turretConstruct();
    }

    private void OnDisable()
    {
        shootAction.performed -= _ => ShootGun();
        constructAction.performed -= _ => turretConstruct();
    }




    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
        animator.SetFloat("Speed",GetCurrentSpeed());

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

       
        Quaternion targetRotation =  Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


    private void ShootGun() 
    {
        RaycastHit hit;  
        if(Physics.Raycast(cameraTransform.position,cameraTransform.forward,out hit, Mathf.Infinity))
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab,barrelTransform.position,Quaternion.identity, bulletParent);

            BulletController bulletController = bullet.GetComponent<BulletController>();

            bulletController.target = hit.point;
            bulletController.hit = true;

        }
        else
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, Quaternion.identity, bulletParent);

            BulletController bulletController = bullet.GetComponent<BulletController>();

            bulletController.target = cameraTransform.position + cameraTransform.forward * bulletDistance;
            bulletController.hit = false;
        }
    }


    private void turretConstruct()
    {
        if(numTuercas >= 4)
        {
            GameObject turret = GameObject.Instantiate(construction, turretTransform.position, Quaternion.identity);
            numTuercas = 0;
        }
    }

    public float GetCurrentSpeed()
    {
        return this.controller.velocity.magnitude;
    }
}
