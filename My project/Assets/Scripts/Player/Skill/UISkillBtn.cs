using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UISkillBtnExam
{
    public class UISkillBtn : MonoBehaviour
    {
        SkilList SkillList;

        public Button btn;
        public float coolTime = 10f;
        public TMP_Text textCoolTime;

        private Coroutine coolTimeRoutine;

        public Image imgFill;

        public void Init()
        {
            this.textCoolTime.gameObject.SetActive(false);
            this.imgFill.fillAmount = 0;
        }

        public void Awake()
        {
            SkillList = GameObject.Find("SkillList").GetComponent<SkilList>();
        }
        void Start()
        {
            this.btn = this.GetComponent<Button>();
            this.btn.onClick.AddListener(() =>
            {
                if (this.coolTimeRoutine != null)
                {
                    Debug.Log("쿨타임 중입니다...");
                }
                else
                {
                    this.coolTimeRoutine = this.StartCoroutine(this.CoolTimeRoutine());
                }
            });

            Init();
        }
        private IEnumerator CoolTimeRoutine()
        {
            this.textCoolTime.gameObject.SetActive(true);
            
            bool isFind = false;
            string key = " ";

            if (this.name == "Double Slash Btn")
            {
                isFind = SkillList.skilList.ContainsKey("Double Slash");
                key = "Double Slash"; 
            }
            else if(this.name == "Fire Slash Btn")
            {
                isFind = SkillList.skilList.ContainsKey("Fire Slash");
                key = "Fire Slash";
            }
            else if (this.name == "Fountain Of Blood Btn")
            {
                isFind = SkillList.skilList.ContainsKey("Fountain Of Blood");
                key = "Fountain Of Blood";
            }
            else if (this.name == "MegaSlash Btn")
            {
                isFind = SkillList.skilList.ContainsKey("Mega Slash");
                key = "Mega Slash";
            }

            if (isFind == true)
            {
                coolTime = SkillList.skilList[key].cooldown;
            }

            var time = coolTime;

            while (true)
            {
                time -= Time.deltaTime;
                this.textCoolTime.text = time.ToString("F1");

                var per = time / this.coolTime;
               
                this.imgFill.fillAmount = per;

                if (time <= 0)
                {
                    this.textCoolTime.gameObject.SetActive(false);
                    break;
                }
                yield return null;
            }

            this.coolTimeRoutine = null;
        }
    }
}