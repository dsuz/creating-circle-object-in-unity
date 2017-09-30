using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タンクを動かすクラス
/// InputManager で定義された Vertical, Horizontal, Fire1 でそれぞれ前後移動, 回転, 弾の発射をする。
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class TankController : MonoBehaviour
{
    /// <summary>GameObjectに追加されたキャラクターコントローラー</summary>
    CharacterController m_charCtrl;

    /// <summary>前後移動の速度</summary>
    [SerializeField] private float m_MoveSpeed = 1f;

    /// <summary>回転速度</summary>
    [SerializeField] private float m_RotateSpeed = 1f;

    /// <summary>弾が発射されるポイント</summary>
    [SerializeField] private GameObject m_muzzle;

    /// <summary>弾のプレハブのパス。弾のプレハブは BulletController クラスが追加されていなければならない。</summary>
    [SerializeField] private string m_bulletPrefabPath = "Prefabs/Circle";

    void Start () {
        m_charCtrl = GetComponent<CharacterController>();
	}
	
	void Update () {
        /* 入力に応じて移動・回転・発射する */
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (vertical != 0) m_charCtrl.SimpleMove(vertical * transform.forward * m_MoveSpeed);
        if (horizontal != 0) transform.Rotate(0, horizontal * m_RotateSpeed, 0);
        if (Input.GetButtonDown("Fire1")) Fire();
	}

    /// <summary>
    /// 弾を発射する
    /// </summary>
    void Fire()
    {
        GameObject bulletPrefab = (GameObject)Resources.Load(m_bulletPrefabPath);

        var bullet = Instantiate(bulletPrefab, m_muzzle.transform.position, m_muzzle.transform.rotation);
        bullet.transform.Rotate(90f, 0, 0); // そのままだと角度がおかしいので X軸を90度回す
        bullet.GetComponent<BulletController>().Fire(transform.forward);
    }
}
