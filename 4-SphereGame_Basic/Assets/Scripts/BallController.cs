using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BallController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _balls = new List<GameObject>();
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _horizontalLimit;
    [SerializeField] private float _moveSpeed;
    private float _horizontal;
    [SerializeField] private TMP_Text _ballCountText = null;
    private int _gatenumber;
    private int _targetCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HorizontalBallMove();
        ForwardBallMove();
        UpdateBallCountText();
    }




    void HorizontalBallMove()
    {
        float _newX;
        if (Input.GetMouseButton(0))
        {
            _horizontal = Input.GetAxisRaw("Mouse X");
        }else
        {
            _horizontal = 0;
        }
        _newX = transform.position.x + _horizontal * _horizontalSpeed * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -_horizontalLimit, _horizontalLimit);

        transform.position = new Vector3(_newX, transform.position.y, transform.position.z);
    }



    private void ForwardBallMove()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallStack"))
        {

            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, _balls[_balls.Count - 1].transform.localPosition.z - 1f);
            _balls.Add(other.gameObject);
        }
        if (other.gameObject.CompareTag("Gate"))
        {
            _gatenumber = other.gameObject.GetComponent<GateController>().GetGateNumber();
            _targetCount = _balls.Count + _gatenumber;

            if (_gatenumber > 0)
            {
                IncreseBallCount();
            }
            else if (_gatenumber < 0)
            {
                DecreaseBallCount();
            }
        }
    }

    private void UpdateBallCountText()
    {
        _ballCountText.text = _balls.Count.ToString();
    }



    private void IncreseBallCount()
    {
        for (int i = 0; i < _gatenumber; i++)
        {
            GameObject _newBall = Instantiate(_ballPrefab);
            _newBall.transform.SetParent(transform);
            _newBall.GetComponent<SphereCollider>().enabled = false;
            _newBall.transform.localPosition = new Vector3(0f, 0f, _balls[_balls.Count - 1].transform.localPosition.z - 1f);
            _balls.Add(_newBall);
        }
    }
    private void DecreaseBallCount()
    {
        for (int i = _balls.Count - 1; i >= _targetCount; i--)
        {     
            _balls[i].SetActive(false);
            _balls.RemoveAt(i);
        }
    }

}
//Translate = Dönüþümü yönüne ve mesafesine taþýr.