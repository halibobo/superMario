# superMario
# 超级马里奥
[我的个人博客](http://www.dahei.me)


## 利用unity引擎做的超级马里奥，完全自学，现在开源
## 亲测可以在windows电脑、wp手机和android手机上玩


![enter image description here](https://raw.githubusercontent.com/halibobo/BlogImage/master/blog/mario/mario.gif)


## 【注】在手机端上玩需要打开虚拟摇杆
MarioCtrl.cs

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

