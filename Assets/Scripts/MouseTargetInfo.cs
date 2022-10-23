using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTargetInfo : MonoBehaviour
{
    // ����� ����Ʈ
    public List<string> debuffList = new List<string>();

    // �׽�Ʈ�� ���ؼ� �ӽ÷� ����Ʈ�� ���� �ִ´�.
    private void Start()
    {
        //debuffList.Add("Stun");
    }

    private void Update()
    {
        if (debuffList.Count != 0)
        {
            for (int i = 0; i < debuffList.Count; i++)
            {
                // �����̸�
                if (debuffList[i] == "Stun")
                {
                    Debug.Log("���� �޼ҵ� ����");
                    debuffList.RemoveAt(i);
                    StartCoroutine(Stun());
                    return;
                }

                if (debuffList[i] == "Burn") // ������ �߻��� ����
                {
                    Debug.Log("ȭ�� �޼ҵ� ����");
                    debuffList.RemoveAt(i);
                    StartCoroutine(Burn());
                    return;
                }
            }
        }
    }

    float debuffTime = 3;
    public IEnumerator Stun()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        gameObject.GetComponent<Abilities>().enabled = false;

        yield return new WaitForSeconds(debuffTime);

        gameObject.GetComponent<Movement>().enabled = true;
        gameObject.GetComponent<Abilities>().enabled = true;
    }

    [SerializeField]
    public Health health;

    public IEnumerator Burn()
    {
        // hp�� �ʴ� 10�� �ܴ�.
        health.health -= 10;
        yield return new WaitForSeconds(1f);
        health.health -= 10;
        yield return new WaitForSeconds(1f);
        health.health -= 10;
    }




    // �����̻� �ɷȴٸ� �����̻� ����Ʈ�� �־���Ѵ�.
    private void OnTriggerEnter(Collider other)
    {
        debuffList.Add(other.gameObject.name);
    }




}
