using UnityEngine;

public class 精靈動畫命令 : MonoBehaviour
{
    private Animation anim;
    public string st;
    private void Start()
    {
        anim = GetComponent<Animation>();

    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Idle();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Attack(a);
        }
    }*/
    public void Idle()
    {
        anim.PlayQueued("Idle");
    }
    public void Attack()
    {
        anim.Play(st);
        Idle();
    }
}
