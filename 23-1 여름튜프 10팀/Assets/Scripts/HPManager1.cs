using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI와 관련된 변수나 함수를 사용하려면 이 문장을 적어줘야 합니다.

// 8번!
// 이번에는 시간이 아닌 플레이어의 체력을 관리해 봅시다.
public class HPManager : MonoBehaviour
{
    // 이번에도 싱글톤을 사용합니다.
    // 사실, TimeManager랑 HPManager를 합쳐서 UIManager로 사용하면 더욱 좋겠지만, 여기서는 각 기능별로 추가하다 보니 구별했습니다.
    // 싱글톤의 강점은 여러 관리를 하나에서 할 수 있는 것입니다. 따라서 실전에서는 합쳐서 사용하게 될 겁니다.
    public static HPManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    [Header("HP를 표현할 이미지")]
    public Image image_HP;
    [Header("게임 오버 UI")]
    public GameObject ui_GameOver;
    
    // HP UI를 해당 값으로 표시합니다.
    public void SetHP(int nowHP, int maxHP)
    {
        if (image_HP != null)
        {
            // Image 타입에 내장되어 있는 변수 값으로, 이미지가 보이는 크기를 관리할 수 있습니다.
            // 최댓값이 1, 최솟값이 0으로, 소수(분수) 형태를 이용해야 합니다.
            image_HP.fillAmount = (float)nowHP / maxHP;
        }
    }

    // 플레이어의 체력이 0이 되면, PlayerHP 스크립트에서 이 함수를 작동시킬거에요.
    public void SetGameOver()
    {
        if(ui_GameOver != null)
        {
            // SetActive(true/false) 함수로 어떠한 오브젝트를 활성, 비활성 상태로 바꿀 수 있어요.
            ui_GameOver.SetActive(true);
        }
    }
}
