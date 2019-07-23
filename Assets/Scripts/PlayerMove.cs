using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float moveSpeed = 6.0f;      //角色移动速度
	public float rotateSpeed = 3.0f;    //角色转向速度
	public float jumpVelocity = 5f;     //角色起跳时的速度

	private float miniMouseRotateX = -75.0f;        //摄像机旋转角度的最小值
	private float maxiMouseRotateX = 75.0f;         //摄像机旋转角度的最大值

	private float mouseRotateX;                     //当前摄像机在X轴的旋转角度
	private bool isGrounded;                        //玩家是否在地面上
	private float groundedRaycastDistance;          //在判定玩家是否在地面上时，向地面发射射线的射线长度

	private Camera camera;                    //角色的摄像机子对象
	private Rigidbody rigidbody;                    //角色刚体组件
	private CapsuleCollider collider;    //角色的胶囊体碰撞体
	private Animator animator;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		collider = GetComponent<CapsuleCollider>();
		animator = GetComponent<Animator>();

		camera = GetComponentInChildren<Camera>();

		mouseRotateX = camera.transform.eulerAngles.x;

		groundedRaycastDistance = 0.5f;
	}

	private void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Move(h, v);

		float rh = Input.GetAxis("Mouse Y");
		float rv = Input.GetAxis("Mouse X");
		Rotate(rh, rv);

		Jump();
	}

	private void FixedUpdate()
	{
		isGrounded = Physics.Raycast(transform.position + Vector3.up, Vector3.down, groundedRaycastDistance + 1f);
		animator.SetBool("is_in_air", !isGrounded);
	}

	private void Move(float h,float v)
	{
		var translation = (Vector3.forward * v + Vector3.right * h) * moveSpeed * Time.deltaTime;

		transform.Translate(translation);

		animator.SetBool("run", translation != Vector3.zero);
	}

	private void Rotate(float rh,float rv)
	{
		transform.Rotate(0, rv * rotateSpeed, 0);
		mouseRotateX -= rh * rotateSpeed;
		mouseRotateX = Mathf.Clamp(mouseRotateX, miniMouseRotateX, maxiMouseRotateX);
		camera.transform.localEulerAngles = new Vector3(mouseRotateX, 0, 0);
	}

	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
		}
	}
}
