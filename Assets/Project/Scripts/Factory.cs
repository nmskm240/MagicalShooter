using UnityEngine;

[System.Serializable]
public class Factory : MonoBehaviour 
{
    [SerializeField]
    private GameObject _origin;

    public GameObject Create()
    {
        return Instantiate(_origin, transform.position, transform.rotation);
    }
}