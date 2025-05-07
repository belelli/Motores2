using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsManager : MonoBehaviour
{
    bool _replaceCannons;
    [SerializeField] GameObject _cannonsToHide;
    [SerializeField] GameObject _cannonsToShow;


    private void Awake()
    {
        _replaceCannons = RemoteConfig.Instance.replaceCannons;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_replaceCannons)
        {
            _cannonsToHide.SetActive(false);
            _cannonsToShow.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
