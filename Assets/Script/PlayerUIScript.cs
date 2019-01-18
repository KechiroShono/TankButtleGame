using UnityEngine;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour
{
    #region Public Properties
    //頭上にくるためのオフセット
    public Vector3 ScreenOffset = new Vector3(0f, 30f, 0f);

    //Player名前設定用Text
    public Text PlayerNameText;

    //PlayerのHP用Slider
    public Slider PlayerHPSlider;
    #endregion

    #region Private Properties
    //追従するキャラのPlayerManager情報
    PlayerManager _target;
    float _characterControllerHeight;
    Transform _targetTransform;
    Vector3 _targetPosition;
    #endregion

    void Awake()
    {
        this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        if (PlayerHPSlider != null)
        {
            PlayerHPSlider.value = _target.HP;
        }
    }

    private void LateUpdate()
    {
        if (_targetTransform != null)
        {
            _targetPosition = _targetTransform.position;
            _targetPosition.y += _characterControllerHeight;

            this.transform.position = Camera.main.WorldToScreenPoint(_targetPosition) + ScreenOffset;
        }
    }
    public void SetTarget(PlayerManager target)
    {
        if (target == null)//targetがいなければエラーをConsoleに表示
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
            return;
        }
        //targetの情報をこのスクリプト内で使うのでコピー
        _target = target;
        _targetTransform = _target.GetComponent<Transform>();

        CharacterController _characterController = _target.GetComponent<CharacterController>();

        //PlayerManagerの頭上UIに表示したいデータをコピー
        if (_characterController != null)
        {
            _characterControllerHeight = _characterController.height;
        }

        if (PlayerNameText != null)
        {
            PlayerNameText.text = _target.photonView.owner.NickName;
        }
        if (PlayerHPSlider != null)
        {
            PlayerHPSlider.value = _target.HP;
        }
    }
}