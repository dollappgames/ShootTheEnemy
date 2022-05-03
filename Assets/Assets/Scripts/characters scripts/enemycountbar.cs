using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class enemycountbar : MonoBehaviour
{
    //enemiescount
    public TMP_Text counttext;
    public Image countbarr;
    [SerializeField] public float enemys, maxenemy ;
    //enemiescount
    //barspeed
    float lerpspeed;
    //barspeed
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        counttext.text = "" + enemys;// + "%";

        if (enemys > maxenemy) enemys = maxenemy;

        lerpspeed = 3f * Time.deltaTime;

        enemybarfiller();
        colorcchanger();
    }
    void enemybarfiller()
    {
        countbarr.fillAmount = Mathf.Lerp(countbarr.fillAmount, enemys / maxenemy, lerpspeed);
    }
    public void decreaseenemies(float decreasepoint)
    {
        if (enemys > 0)

            enemys -= decreasepoint;

    }

    void colorcchanger()
    {
        Color barcolor = Color.Lerp(Color.red, Color.green, (enemys / maxenemy));
        countbarr.color = barcolor;
    }
    public void increaseenemies(float increasepoint)
    {
        if (enemys < maxenemy)

            enemys += increasepoint;

    }
}
