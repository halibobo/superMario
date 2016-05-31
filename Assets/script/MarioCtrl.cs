using UnityEngine;
using System.Collections;

public class MarioCtrl : MonoBehaviour {

    public float runSpeed = 1f;//跑 -> 速度
    public float movePower = 10f;
    public Animator myAnimator;
    public float jumpSeed = 2f;
    public bool isGround = false;
    public bool isJump = false;
    public bool isRun = false;
    public Transform[] groundCheck;
    private Transform myTransform;
    public Transform headCheck;

    private MPJoystick moveJoystick;
    private GameObject JoyHandle;

    private Transform joyJump;
    private Rect jumpRect;

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myTransform = transform;
        JoyHandle = GameObject.FindGameObjectWithTag("JoyHandle");
        moveJoystick = JoyHandle.transform.FindChild("Joy").GetComponent<MPJoystick>();
        joyJump = JoyHandle.transform.FindChild("jump");
        
       
    }

	// Use this for initialization
	void Start () {

        Vector3 pos = Camera.main.ViewportToScreenPoint(joyJump.position);
        //Debug.Log(pos);
        Rect guiRect = joyJump.gameObject.GetComponent<GUITexture>().pixelInset;
        Debug.Log("guiRect" + guiRect);
        jumpRect = new Rect(pos.x + guiRect.x, (pos.y) + guiRect.y, guiRect.width, guiRect.height);

        headCheck = transform.FindChild("HeadCheck");
        if (groundCheck == null || groundCheck.Length < 2)
        {
            groundCheck = new Transform[2];
            groundCheck[0] = transform.GetChild(0);
            groundCheck[1] = transform.GetChild(1);
        }
	}
	
	// Update is called once per frame
	void Update () {

        isGround = Physics2D.Linecast(myTransform.position, groundCheck[0].position, 1 << LayerMask.NameToLayer("Ground"))
                    || Physics2D.Linecast(myTransform.position, groundCheck[1].position, 1 << LayerMask.NameToLayer("Ground"));


        isRun = false;

        float touchKey_x = 1;//moveJoystick.position.x;

        if (Input.GetKey(KeyCode.A))
        //if (touchKey_x < -0.1f)
        {
            transform.localEulerAngles = new Vector3(0,180,0);
            if (Camera.main.WorldToScreenPoint(transform.position).x > 20)  //小玛丽不能超出坐屏幕
            {
                transform.Translate(Vector3.right * runSpeed * Time.deltaTime * Mathf.Abs(touchKey_x)); //移动位置
            }
            runAnim();
        }
        
        if (Input.GetKey(KeyCode.D))
        //else if (touchKey_x > 0.1f)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.Translate(Vector3.right * runSpeed * Time.deltaTime * Mathf.Abs(touchKey_x));
            runAnim(); 
        }

        if (Input.GetKeyDown(KeyCode.W) && isGround)
        //if (isTouchJump()&&isGround)
        {
            World.playAudio(World.jumpAudioIndex);
            rigidbody2D.velocity = new Vector2(0, jumpSeed);
            jumpAnim();
        }

        if (!isRun && isGround )
        {
            if (!isJump)
            {
                standAnim();
            }
            else if(rigidbody2D.velocity.y <= 0)
            {
                isJump = false;
            }
        }

      

       /* if(Physics2D.Linecast(myTransform.position, headCheck.position, 1 << LayerMask.NameToLayer("Weak")))
        {
            Debug.Log("I can play!");
        }*/

	}

    void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, myTransform.localEulerAngles.y, 0);
    }


    private void runAnim()
    {
        myAnimator.SetBool("isRun", true);
        myAnimator.SetBool("isJump", false);
        myAnimator.SetBool("isStand", false);
        isRun = true;
        isJump = false;
    }


    private bool isTouchJump()
    {
        for (int i = 0; i < Input.touchCount; i++)
        //if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            Debug.Log(jumpRect);
            if (jumpRect.Contains(Input.GetTouch(i).position))
           // if (jumpRect.Contains(Input.mousePosition))
            {
                Debug.Log(true);
                return true;
            }
            Debug.Log(false);
        }
        return false;
    }

    void OnGUI()
    {
       // GUI.Box(jumpRect,"测试框");
    }

    private void jumpAnim()
    {
        myAnimator.SetBool("isRun", false);
        myAnimator.SetBool("isJump", true);
        myAnimator.SetBool("isStand", false);
        isJump = true;
        isRun = false;
    }

    private void standAnim()
    {
        myAnimator.SetBool("isRun", false);
        myAnimator.SetBool("isJump", false);
        myAnimator.SetBool("isStand", true);
        isRun = false;
        isJump = false;
    }


    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "mushroom")
        {
           /* if (Physics2D.Linecast(myTransform.position, groundCheck[0].position, 1 << LayerMask.NameToLayer("Mushroom"))||
                Physics2D.Linecast(myTransform.position, groundCheck[1].position, 1 << LayerMask.NameToLayer("Mushroom")))
            {
                other.collider.isTrigger = true;
                other.gameObject.SendMessage("die");
            }else*/
            {
                GetComponent<ChenkMarioDie>().setMarioDie();
            }
        }
        if ((other.gameObject.tag == "why") && (Physics2D.Linecast(myTransform.position, headCheck.position, 1 << LayerMask.NameToLayer("Weak"))))
        {
            other.gameObject.GetComponent<Mushroomhy>().setHarm();
        }
       
        // Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "coin")
        {
            World.playAudio(World.coinAudio);
            Destroy(other.gameObject);
        }
        else if (other.tag ==  "flower")
        {
            GetComponent<ChenkMarioDie>().setMarioDie();
        }

        if (other.tag == "mushroom")
        {
            if (other.GetComponent<MushroomCtrl>().isDie)
                return;
            // other.collider.isTrigger = true;
            // other.gameObject.rre
            Destroy(other.GetComponent<BoxCollider2D>());
            if (other != null) { other.gameObject.SendMessage("die"); }
            //other.collider.isTrigger = true;
        }
    }
}
