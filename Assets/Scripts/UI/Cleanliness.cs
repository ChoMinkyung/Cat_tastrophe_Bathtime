/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cleanliness : MonoBehaviour
{
    public CleanlinessProgressBar cleanProgress;
    public CleanlinessPopUp cleanPopUp;

    // �� ��ô��
    private float _cleanliness;
    public float cleanliness
    {
        get { return _cleanliness; }
        set
        {
            _cleanliness = value;
            cleanProgress.UpdateProgress(_cleanliness);
        }
    }

    // ������ ��ô��
    // 1. ��ü
    private float _upperBodyCleanliness;
    public float upperBodyCleanliness
    {
        get { return _upperBodyCleanliness; }
        set 
        {
            _upperBodyCleanliness = value;
            cleanPopUp.CleanCat(CleanEnums.UPPERBODY, _upperBodyCleanliness);
        }
    }

    // 2. ��ü
    private float _lowerBodyCleanliness;
    public float lowerBodyCleanliness
    {
        get { return _lowerBodyCleanliness; }
        set
        {
            _lowerBodyCleanliness = value;
            cleanPopUp.CleanCat(CleanEnums.LOWERBODY, _lowerBodyCleanliness);
        }
    }

    // 3. �޹� (��)
    private float _rearPawRightCleanliness;
    public float rearPawRightCleanliness
    {
        get { return _rearPawRightCleanliness; }
        set
        {
            _rearPawRightCleanliness = value;
            cleanPopUp.CleanCat(CleanEnums.REARPAWRIGHT, _rearPawRightCleanliness);
        }
    }

    // 4. �޹� (��)
    private float _rearPawLeftCleanliness;
    public float rearPawLeftCleanliness
    {
        get { return _rearPawLeftCleanliness; }
        set
        {
            _rearPawLeftCleanliness = value;
            cleanPopUp.CleanCat(CleanEnums.REARPAWLEFT, _rearPawLeftCleanliness);
        }
    }

    // 5. �չ� (��)
    private float _forePawRightCleanliness;
    public float forePawRightCleanliness
    {
        get { return _forePawRightCleanliness; }
        set
        {
            _forePawRightCleanliness = value;
            cleanPopUp.CleanCat(CleanEnums.FOREPAWRIGHT, _forePawRightCleanliness);
        }
    }

    // 6. �չ� (��)
    private float _forePawLeftCleanliness;
    public float forePawLeftCleanliness
    {
        get { return _forePawLeftCleanliness; }
        set
        {
            _forePawLeftCleanliness = value;
            cleanPopUp.CleanCat(CleanEnums.FOREPAWLEFT, _forePawLeftCleanliness);
        }
    }

    // 7. ��
    private float _backCleanliness;
    public float backCleanliness
    {
        get { return _backCleanliness; }
        set
        {
            _backCleanliness = value;
            cleanPopUp.CleanCat(CleanEnums.BACK, _backCleanliness);
        }
    }
    void Start()
    {
        upperBodyCleanliness = 0;
        lowerBodyCleanliness = 0;
        rearPawRightCleanliness = 0;
        rearPawLeftCleanliness = 0;
        forePawRightCleanliness = 0;
        forePawLeftCleanliness = 0;
        backCleanliness = 0;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // ��ü
        {
            if(upperBodyCleanliness < 100)
               upperBodyCleanliness += 1;
        }
        else if(Input.GetKeyDown(KeyCode.X)) // ��ü
        {
            if (lowerBodyCleanliness < 100)
                lowerBodyCleanliness += 1;
        }
        else if(Input.GetKeyDown(KeyCode.C)) // �չ� ��
        {
            if (forePawRightCleanliness < 100)
                forePawRightCleanliness += 1;
        }
        else if(Input.GetKeyDown(KeyCode.V)) // �չ� ��
        {
            if (forePawLeftCleanliness < 100)
                forePawLeftCleanliness += 1;
        }
        else if(Input.GetKeyDown(KeyCode.B)) // �޹� ��
        {
            if (rearPawRightCleanliness < 100)
                rearPawRightCleanliness += 1;
        }
        else if(Input.GetKeyDown(KeyCode.N)) // �޹� ��
        {
            if (rearPawLeftCleanliness < 100)
                rearPawLeftCleanliness += 1;
        }
        else if(Input.GetKeyDown(KeyCode.M)) // ��
        {
            if (backCleanliness < 100)
            {
                backCleanliness += 1;
            }
        }

        cleanliness = upperBodyCleanliness + lowerBodyCleanliness + forePawRightCleanliness + forePawLeftCleanliness +
            rearPawRightCleanliness + rearPawLeftCleanliness + backCleanliness;
    }
}
*/