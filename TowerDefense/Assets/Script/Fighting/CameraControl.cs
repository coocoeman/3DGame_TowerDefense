using UnityEngine;

public class CameraControl : MonoBehaviour
{
    /// <summary>
    /// 紀錄手指觸碰位置
    /// </summary>
    //private Vector2 recordPosition = new Vector2();
    /// <summary>
    /// 移動速度
    /// </summary>
    public float mobileSpeed;    
    /// <summary>
    /// 縮放速度
    /// </summary>
    public float zoomSpeed;
    /// <summary>
    /// 最低高度
    /// </summary>
    public float heightMin = 20f;
    /// <summary>
    /// 最高高度
    /// </summary>
    public float heightMax = 50f;

    void Start()
    {
        //允許多點觸碰
        Input.multiTouchEnabled = true;
    }
    void Update()
    {
        MobileInput();
        CameraLimit();
    }
    /// <summary>
    /// 移動畫面，縮放畫面
    /// </summary>
    void MobileInput()
    {
        //無觸碰跳出
        if (Input.touchCount <= 0)
            return;
        #region 移動畫面，1根手指觸碰到螢幕
        if (Input.touchCount == 1)
        {
            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began)//如果第一個點為開始點時
            {
                
                //recordPosition = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                //移動攝影機
                //Camera.main.transform.Translate(new Vector3(-Input.touches[0].deltaPosition.x * Time.deltaTime*mobileSpeed, -Input.touches[0].deltaPosition.y * Time.deltaTime * mobileSpeed, 0));
                Camera.main.transform.position += new Vector3(-Input.touches[0].deltaPosition.x * Time.deltaTime * mobileSpeed,0, -Input.touches[0].deltaPosition.y * Time.deltaTime * mobileSpeed);
            }
        }
        #endregion//1根手指觸碰到螢幕時
        
        #region 畫面縮放，1個手指以上觸碰螢幕
        else if (Input.touchCount > 1 )//&& Camera.main.transform.position.y>20)
        {
            //記錄兩個手指位置
            Vector2 finger1 = new Vector2();
            Vector2 finger2 = new Vector2();
            //記錄兩個手指移動距離
            Vector2 move1 = new Vector2();
            Vector2 move2 = new Vector2();

            //是否是小於2點觸碰
            for (int i = 0; i < 2; i++)
            {
                UnityEngine.Touch touch = UnityEngine.Input.touches[i];
                if (touch.phase == TouchPhase.Ended)
                    break;
                if (touch.phase == TouchPhase.Moved)
                {
                    //每次都重置
                    float move = 0;
                    //觸碰一點
                    if (i == 0)
                    {
                        finger1 = touch.position;
                        move1 = touch.deltaPosition;
                        //另一點
                    }
                    else
                    {
                        finger2 = touch.position;
                        move2 = touch.deltaPosition;
                        //取最大X
                        if (finger1.x > finger2.x)
                        { move = move1.x; }
                        else
                        { move = move2.x; }
                        //取最大Y，並與取出的X累加
                        if (finger1.y > finger2.y)
                        { move += move1.y; }
                        else
                        { move += move2.y; }
                        //當兩指距離越遠，Z位置加的越多，相反之
                        Camera.main.transform.Translate(0, 0, move * Time.deltaTime * zoomSpeed);
                    }
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// 攝影機限制
    /// </summary>
    void CameraLimit()
    {
        #region 方向限制

        #endregion
        #region 縮放限制
        if (Camera.main.transform.position.y < heightMin)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, heightMin, Camera.main.transform.position.z);
        }
        else if (Camera.main.transform.position.y > heightMax)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, heightMax, Camera.main.transform.position.z);
        }
        #endregion
    }
}
