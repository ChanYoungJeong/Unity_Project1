using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;


public class Amazon_CognitoSync : MonoBehaviour
{
    DynamoDBContext context;
    AmazonDynamoDBClient DBclient;
    CognitoAWSCredentials credentials;
    public InputField InputID;
    public InputField InputPassword;

    public InputField createID;
    public InputField createPassword;

    public GameObject LoadInfo;
    System_Info SystemInfo;
    bool isdone;

    bool hasID;

    public bool isUpdated;

    private void Awake()
    {
        hasID = true;
        isdone = false;
        isUpdated = false;
        UnityInitializer.AttachToGameObject(this.gameObject);
        CreateClilent();
        //
        SystemInfo = LoadInfo.GetComponent<System_Info>();
    }

    private void Update()
    {
        if (isdone == true)
        {
            SceneChange(isdone);
            isdone = false;
        }
    }

    void CreateClilent()
    {
        credentials = new CognitoAWSCredentials("ap-northeast-2:1913bb15-47e3-43c0-8f00-e35cfe123455", RegionEndpoint.APNortheast2);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
    }

    void DisposeClient()
    {
        context.Dispose();
        DBclient.Dispose();
        credentials.Dispose();
    }

    [DynamoDBTable("Users")]
    public class Users
    {
        [DynamoDBHashKey] // Hash key.
        public string userID { get; set; }
        [DynamoDBProperty]
        public string password { get; set; }

    }

    [DynamoDBTable("System")]
    public class System
    {
        [DynamoDBHashKey] // Hash key.
        public string UserID { get; set; }
        [DynamoDBProperty]
        public int Gold { get; set; }
        [DynamoDBProperty]
        public int Stage { get; set; }
        [DynamoDBProperty]
        public int PlayerAttackRate { get; set; }
        [DynamoDBProperty]
        public int PlayerHpRate { get; set; }
        [DynamoDBProperty]
        public int PlayerLV { get; set; }
        [DynamoDBProperty]
        public int PlayerEXP { get; set; }
        [DynamoDBProperty]
        public bool RogueActive { get; set; }
        [DynamoDBProperty]
        public bool MagicCasterActive { get; set; }
        [DynamoDBProperty]
        public bool PriestActive { get; set; }
        [DynamoDBProperty]
        public bool ArcherActive { get; set; }
        [DynamoDBProperty]
        public bool AlchemistActive { get; set; }

    }

    public void UpdateData(string _id, int _Gold, int _Stage, int _PlayerAttackRate, int _PlayerHpRate, int _PlayerLV, int _PlayerEXP,
                            bool _rogueAct, bool _MCAct, bool _PriestAct, bool _ArcherAct, bool _AlchemistAct) //캐릭터 정보를 DB에 올리기
    {
        System s1 = null;
        context.LoadAsync<System>(_id, (result) =>
        {
            //id가 happy, item이 1111인 캐릭터 정보를 DB에 저장
            if (result.Exception == null)
            {
                s1 = result.Result;
                s1.Stage = _Stage;
                s1.Gold = _Gold;
                s1.PlayerAttackRate = _PlayerAttackRate;
                s1.PlayerHpRate = _PlayerHpRate;
                s1.PlayerLV = _PlayerLV;
                s1.PlayerEXP = _PlayerEXP;
                s1.RogueActive = _rogueAct;
                s1.MagicCasterActive = _MCAct;
                s1.PriestActive = _PriestAct;
                s1.ArcherActive = _ArcherAct;
                s1.AlchemistActive = _AlchemistAct;
                context.SaveAsync<System>(s1, (result) =>
                {
                    if (result.Exception == null)
                    {
                        Debug.Log("Success!");
                    }
                });
            }
            else
            {
                Debug.Log(result.Exception);
            }
            isUpdated = true;
        });
        
    }

    public void LogIN() //DB에서 캐릭터 정보 받고 로그인
    {
        Users c;
        context.LoadAsync<Users>(InputID.text, (AmazonDynamoDBResult<Users> result) =>
       {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
           {
               Debug.LogException(result.Exception);
               return;
           }
           c = result.Result;
           if (c.password == InputPassword.text) //찾은 캐릭터 정보 중 아이템 정보 출력
            {
               CheckAccountInfo(c);
           }
       }, null);
       
    }

    public void SignIn()
    {
        StartCoroutine(loadingDelay());
    }

    IEnumerator loadingDelay()
    {
        while (hasID == true)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Checking if ID exist");
        }
        if (hasID == false)
        {
            Users newUser = new Users
            {
                userID = createID.text,
                password = createPassword.text
            };
            context.SaveAsync(newUser, (result) =>
            {
                if (result.Exception == null)
                {
                    CreateNewAccountTable(newUser.userID);
                    Debug.Log("Account has created Successfully");
                    hasID = true;
                    StopCoroutine(loadingDelay());
                }
            });
        }
        else
        {
            Debug.Log("ID already Exist");
        }
    }

    public void CheckID()
    {
        context.LoadAsync<Users>(createID.text, (AmazonDynamoDBResult<Users> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                
                Debug.LogException(result.Exception);
                hasID = true;
                Debug.Log("There is same ID : " + createID.text);
                return;
            }
            else
            {
                hasID = false;
                Debug.Log("There is no sameID : " + createID.text);
            }
        }, null);
    }

    

    public void SceneChange(bool _isdone)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("Project");
        op.allowSceneActivation = _isdone;
        DontDestroyOnLoad(LoadInfo);
        
    }

    void CheckAccountInfo(Users _loginUser)
    {
        System s;
        Debug.Log(_loginUser.userID);
        context.LoadAsync<System>(_loginUser.userID, (AmazonDynamoDBResult<System> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }
           
            s = result.Result;
            string ID = InputID.text;
            int _stage = s.Stage;
            int _Gold = s.Gold;
            int _AtkR = s.PlayerAttackRate;
            int _HPR = s.PlayerHpRate;
            SystemInfo.SetLoading(ID, _stage, _Gold, _AtkR, _HPR, s.PlayerLV, s.PlayerEXP,
                                  s.RogueActive, s.MagicCasterActive, s.PriestActive, s.ArcherActive, s.AlchemistActive);
            isdone = true;
            DisposeClient();
        }, null);

    }

    void CreateNewAccountTable(string _UserID)
    {
        System newUserSystem = new System
        {
            UserID = _UserID,
            Gold = 0,
            Stage = 1,
            PlayerAttackRate = 1,
            PlayerHpRate = 0,
            PlayerLV = 1,
            PlayerEXP = 0,
            RogueActive = false,
            MagicCasterActive = false,
            PriestActive = false,
            ArcherActive = false,
            AlchemistActive = false
        };

        context.SaveAsync(newUserSystem, (result) =>
        {
            if (result.Exception == null)
                Debug.Log("System for " + _UserID + "has created");
        });
    }


}

