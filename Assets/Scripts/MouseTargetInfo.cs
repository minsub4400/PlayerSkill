using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTargetInfo : MonoBehaviour
{
    // 디버프 리스트
    public List<string> debuffList = new List<string>();

    // 테스트를 위해서 임시로 리스트에 값을 넣는다.
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
                // 스턴이면
                if (debuffList[i] == "Stun")
                {
                    Debug.Log("스턴 메소드 실행");
                    debuffList.RemoveAt(i);
                    StartCoroutine(Stun());
                    return;
                }

                if (debuffList[i] == "Burn") // 에러나 발생할 거임
                {
                    Debug.Log("화상 메소드 실행");
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
        // hp가 초당 10씩 단다.
        health.health -= 10;
        yield return new WaitForSeconds(1f);
        health.health -= 10;
        yield return new WaitForSeconds(1f);
        health.health -= 10;
    }




    // 상태이상에 걸렸다면 상태이상 리스트에 넣어야한다.
    private void OnTriggerEnter(Collider other)
    {
        debuffList.Add(other.gameObject.name);
    }




}
