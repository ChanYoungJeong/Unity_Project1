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

    public GameObject LoadInfo;
    System_Info SystemInfo;
    bool isdone;
    public bool isUpdated;

    private void Awake()
    {
        isdone = false;
        isUpdated = false;
        UnityInitializer.AttachToGameObject(this.gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:1913bb15-47e3-43c0-8f00-e35cfe123455", RegionEndpoint.APNortheast2);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
        //
        SystemInfo = LoadInfo.GetComponent<System_Info>();
    }

    private void Update()
    {
        if(isdone == true)
        {
            SceneChange(isdone);
            isdone = false;
        }

        if(Input.GetKeyDown("up"))
        {
            UpdateData("admin", 190, 4, 1, 0);
        }
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
    }

    public void UpdateData(string _id, int _Gold, int _Stage, int _PlayerAttackRate, int _PlayerHpRate) //캐릭터 정보를 DB에 올리기
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
                context.SaveAsync<System>(s1, (result) =>
                {
                    if(result.Exception == null)
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
        context.LoadAsync<Users>(InputID.text , (AmazonDynamoDBResult<Users> result) =>
        {
            // id가 abcd인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }
            c = result.Result;
            if(c.password == InputPassword.text) //찾은 캐릭터 정보 중 아이템 정보 출력
            {
                CheckAccountInfo(c);
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
            SetLoading(ID, _stage, _Gold, _AtkR, _HPR);
            isdone = true;
        }, null);

    }

    void SetLoading(string ID, int Stage, int Gold, int PlayerAttack, int PlayerHp)
    {
        SystemInfo.UserAccount = ID;
        SystemInfo.Load_Stage = Stage;
        SystemInfo.Load_Gold = Gold;
        SystemInfo.Player_Attack_Rate = PlayerAttack;
        SystemInfo.Player_Hp_Rate = PlayerHp;
    }
}

