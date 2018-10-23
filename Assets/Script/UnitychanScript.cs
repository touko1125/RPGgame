using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanScript : MonoBehaviour {
    public int Idou = 0;
    public float animSpeed = 2.0f;
    public float forwardSpeed = 4.0f;
    public float backwardSpeed = 4.0f;
    public float rotateSpeed = 2.0f;
    public float jumpPower = 3.0f;
    public bool useCurves = true;
    public Animator anim;
    private CapsuleCollider col;
    private float orgColHight;
    private Vector3 orgVectColCenter;
    public Rigidbody rb;
    private Vector3 velocity;
    private AnimatorStateInfo currentBaseState;
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int restState = Animator.StringToHash("Base Layer.Rest");
    // Use this for initialization
    void Start() {
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        anim.speed = animSpeed;
        velocity = new Vector3(0, 0, v);
        velocity = transform.TransformDirection(velocity);
        if (v < -0.1)
        {
            velocity *= backwardSpeed;
        }
        else if (v > 0.1)
        {
            velocity *= forwardSpeed;
        }
        if (Idou == 0)
        {
            // 上下のキー入力でキャラクターを移動させる
            transform.localPosition += velocity * Time.fixedDeltaTime;

            // 左右のキー入力でキャラクタをY軸で旋回させる
            transform.Rotate(0, h * rotateSpeed, 0);
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpPower);
                anim.SetBool("Jump", true);
            }
        }
        if (currentBaseState.nameHash == locoState)
        {
            //カーブでコライダ調整をしている時は、念のためにリセットする
            if (useCurves)
            {
                resetCollider();
            }
        }
        else if (currentBaseState.nameHash == idleState)
        {
            //カーブでコライダ調整をしている時は、念のためにリセットする
            if (useCurves)
            {
                resetCollider();
            }
            // スペースキーを入力したらRest状態になる
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("Rest", true);
            }
        }
        else if (currentBaseState.nameHash == restState)
        {
            //cameraObject.SendMessage("setCameraPositionFrontView");		// カメラを正面に切り替える
            // ステートが遷移中でない場合、Rest bool値をリセットする（ループしないようにする）
            if (!anim.IsInTransition(0))
            {
                anim.SetBool("Rest", false);
            }
        }
    }
    void resetCollider()
    {
        // コンポーネントのHeight、Centerの初期値を戻す
        col.height = orgColHight;
        col.center = orgVectColCenter;
    }
}
