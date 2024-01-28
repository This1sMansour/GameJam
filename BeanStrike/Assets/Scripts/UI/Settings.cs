using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    public bool keySelectionEnabled = false;
    
    public string up = "w";
    public string down = "s";
    public string left = "a";
    public string right = "d";
    public string call = "1";
    public string command = "2";
    public string dismiss = "3";

    [SerializeField] TMP_Text txt_up;
    [SerializeField] TMP_Text txt_down;
    [SerializeField] TMP_Text txt_left;
    [SerializeField] TMP_Text txt_right;
    [SerializeField] TMP_Text txt_call;
    [SerializeField] TMP_Text txt_command;
    [SerializeField] TMP_Text txt_dismiss;
    
    TMP_Text selectedSetting;
    string context = "";
    
    [SerializeField] GameObject promptTicket;
    [SerializeField] GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        keySelectionEnabled = false;
        promptTicket.SetActive(false);

        if (!SaveDataAvailable())
        {
            Debug.Log("Save data not found. Setting to default...");
            RestoreDefault();
            SaveData();
        }
        else
        {
            LoadData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if (keySelectionEnabled)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                string input = e.keyCode.ToString().ToLower();
                Debug.Log("Detected key code: " + input);
                selectedSetting.text = context + input;
                SetStringVar(context, input);
                context = "";
                keySelectionEnabled = false;
                promptTicket.SetActive(false);
            }
        }
    }

    public void SetUp()
    {
        keySelectionEnabled = true;
        selectedSetting = txt_up;
        context = "Up\n";
        // Show prompt ticket where it asks you to input a key value
        promptTicket.SetActive(true);
    }

    public void SetDown()
    {
        keySelectionEnabled = true;
        selectedSetting = txt_down;
        context = "Down\n";
        // Show prompt ticket where it asks you to input a key value
        promptTicket.SetActive(true);
    }

    public void SetLeft()
    {
        keySelectionEnabled = true;
        selectedSetting = txt_left;
        context = "Left\n";
        // Show prompt ticket where it asks you to input a key value
        promptTicket.SetActive(true);
    }

    public void SetRight()
    {
        keySelectionEnabled = true;
        selectedSetting = txt_right;
        context = "Right\n";
        // Show prompt ticket where it asks you to input a key value
        promptTicket.SetActive(true);
    }

    public void SetCall()
    {
        keySelectionEnabled = true;
        selectedSetting = txt_call;
        context = "Call\n";
        // Show prompt ticket where it asks you to input a key value
        promptTicket.SetActive(true);
    }

    public void SetCommand()
    {
        keySelectionEnabled = true;
        selectedSetting = txt_command;
        context = "Command\n";
        // Show prompt ticket where it asks you to input a key value
        promptTicket.SetActive(true);
    }

    public void SetDismiss()
    {
        keySelectionEnabled = true;
        selectedSetting = txt_dismiss;
        context = "Dismiss\n";
        // Show prompt ticket where it asks you to input a key value
        promptTicket.SetActive(true);
    }

    void SetStringVar(string context, string input)
    {
        if (context == "Up\n")
        {
            up = input;
        }
        if (context == "Down\n")
        {
            down = input;
        }
        if (context == "Left\n")
        {
            left = input;
        }
        if (context == "Right\n")
        {
            right = input;
        }
        if (context == "Call\n")
        {
            call = input;
        }
        if (context == "Command\n")
        {
            command = input;
        }
        if (context == "Dismiss\n")
        {
            dismiss = input;
        }
    }

    public void BackToMenu()
    {
        SaveData();
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }


    bool SaveDataAvailable()
    {
        if (!PlayerPrefs.HasKey("up"))
        {
            return false;
        }
        if (!PlayerPrefs.HasKey("down"))
        {
            return false;
        }
        if (!PlayerPrefs.HasKey("left"))
        {
            return false;
        }
        if (!PlayerPrefs.HasKey("right"))
        {
            return false;
        }
        if (!PlayerPrefs.HasKey("call"))
        {
            return false;
        }
        if (!PlayerPrefs.HasKey("command"))
        {
            return false;
        }
        if (!PlayerPrefs.HasKey("dismiss"))
        {
            return false;
        }
        return true;
    }

    public void RestoreDefault()
    {
        up = "w";
        down = "s";
        left = "a";
        right = "d";
        call = "Alpha1";
        command = "Alpha2";
        dismiss = "Alpha3";

        UpdateGUI();
    }

    public void UpdateGUI()
    {
        txt_up.text = "Up\n" + up;
        txt_down.text = "Down\n" + down;
        txt_left.text = "Left\n" + left;
        txt_right.text = "Right\n" + right;
        txt_call.text = "Call\n" + call;
        txt_command.text = "Command\n" + command;
        txt_dismiss.text = "Dismiss\n" + dismiss;
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("up", up);
        PlayerPrefs.SetString("down", down);
        PlayerPrefs.SetString("left", left);
        PlayerPrefs.SetString("right", right);
        PlayerPrefs.SetString("call", call);
        PlayerPrefs.SetString("command", command);
        PlayerPrefs.SetString("dismiss", dismiss);
    }

    public void LoadData()
    {
        up = PlayerPrefs.GetString("up");
        down = PlayerPrefs.GetString("down");
        left = PlayerPrefs.GetString("left");
        right = PlayerPrefs.GetString("right");
        call = PlayerPrefs.GetString("call");
        command = PlayerPrefs.GetString("command");
        dismiss = PlayerPrefs.GetString("dismiss");

        UpdateGUI();
    }
}
