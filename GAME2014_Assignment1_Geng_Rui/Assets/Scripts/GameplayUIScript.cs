using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIScript : MonoBehaviour
{
    public Text UIText;
    public enum UICategory
    {
        Manpower,
        EnemyKilled,
        Health,
        Score
    };

    public UICategory UICat;

    [SerializeField]
    private int UIValue;

    // Start is called before the first frame update
    void Start()
    {
        UIText = GetComponent<Text>();
        UIValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        setCategory(UICat);
    }

    public void setCategory(UICategory c)
    {
        UICat = c;

        switch (c)
        {
            case UICategory.Manpower:
                UIText.text = "Manpower Left: " + UIValue.ToString();
                break;
            case UICategory.EnemyKilled:
                UIText.text = "Enemy Killed: " + UIValue.ToString();
                break;
            case UICategory.Health:
                UIText.text = "Health Left: " + UIValue.ToString();
                break;
            case UICategory.Score:
                UIText.text = "Score: " + UIValue.ToString();
                break;
        }
    }

    public void setValue (int v)
    {
        UIValue = v;
    }
}
