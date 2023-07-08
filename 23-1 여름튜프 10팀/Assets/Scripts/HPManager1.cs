using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI�� ���õ� ������ �Լ��� ����Ϸ��� �� ������ ������� �մϴ�.

// 8��!
// �̹����� �ð��� �ƴ� �÷��̾��� ü���� ������ ���ô�.
public class HPManager : MonoBehaviour
{
    // �̹����� �̱����� ����մϴ�.
    // ���, TimeManager�� HPManager�� ���ļ� UIManager�� ����ϸ� ���� ��������, ���⼭�� �� ��ɺ��� �߰��ϴ� ���� �����߽��ϴ�.
    // �̱����� ������ ���� ������ �ϳ����� �� �� �ִ� ���Դϴ�. ���� ���������� ���ļ� ����ϰ� �� �̴ϴ�.
    public static HPManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    [Header("HP�� ǥ���� �̹���")]
    public Image image_HP;
    [Header("���� ���� UI")]
    public GameObject ui_GameOver;
    
    // HP UI�� �ش� ������ ǥ���մϴ�.
    public void SetHP(int nowHP, int maxHP)
    {
        if (image_HP != null)
        {
            // Image Ÿ�Կ� ����Ǿ� �ִ� ���� ������, �̹����� ���̴� ũ�⸦ ������ �� �ֽ��ϴ�.
            // �ִ��� 1, �ּڰ��� 0����, �Ҽ�(�м�) ���¸� �̿��ؾ� �մϴ�.
            image_HP.fillAmount = (float)nowHP / maxHP;
        }
    }

    // �÷��̾��� ü���� 0�� �Ǹ�, PlayerHP ��ũ��Ʈ���� �� �Լ��� �۵���ų�ſ���.
    public void SetGameOver()
    {
        if(ui_GameOver != null)
        {
            // SetActive(true/false) �Լ��� ��� ������Ʈ�� Ȱ��, ��Ȱ�� ���·� �ٲ� �� �־��.
            ui_GameOver.SetActive(true);
        }
    }
}
