using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
public class Movement : MonoBehaviour
{
    public float additianalHeight = 0.2f;
    public float speed = 1;
    private XROrigin rig;
    public float gravity = -9.81f;
    public LayerMask groundLayer;

    private float fallingSpeed; 
    public XRNode inputSource;
    private Vector2 inputAxis;
    private CharacterController character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0,rig.Camera.gameObject.transform.eulerAngles.y,0);

        Vector3 direction  = headYaw* new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction*Time.fixedDeltaTime * speed);

        //Gravity
        bool isGrounded = checkIfGrounded();
        if (isGrounded)
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
        }
        
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

    }


    bool checkIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLenght = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLenght, groundLayer);
        return hasHit;
    }
    
    void CapsuleFollowHeadset()
    {
        character.height = rig.CameraInOriginSpaceHeight + additianalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }
}
