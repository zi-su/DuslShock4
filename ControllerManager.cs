using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour {

    public enum BUTTON_BIT{
        PAD_LEFT    = 2,
        PAD_RIGHT   = 4,
        PAD_UP      = 8,
        PAD_DOWN    = 16,
        PAD_SQUARE  = 32,
        PAD_TRI     = 64,
        PAD_CROSS   = 128,
        PAD_CIRCLE  = 256,
        PAD_L1      = 512,
        PAD_L2      = 1024,
        PAD_R1      = 2048,
        PAD_R2      = 4096,
        PAD_SELECT  = 8192,
        PAD_START   = 16384,
        PAD_R3      = 32768,
        PAD_L3      = 65536,
        PAD_HOME    = 131072,
        PAD_OPTION  = 262144,
        PAD_SHARE   = 524288,
        PAD_TOUCH   = 1048576,
    };

    public struct PadInfo{
        public Vector3 leftStick;
        public Vector3 rightStick;
        public float L2;
        public float R2;
        public uint button_bit;
    };

    enum PAD_ID{
        PAD_1,
        PAD_2,
        PAD_NUM,
    }
    public static PadInfo pad;
    public static PadInfo beforePad;
	// Use this for initialization
	void Start () {
        pad.leftStick.x = Input.GetAxis("Horizontal");
        pad.leftStick.y = 0.0f;
        pad.leftStick.z = Input.GetAxis("Vertical");

        pad.rightStick.x = Input.GetAxis("Horizontal2");
        pad.rightStick.y = 0.0f;
        pad.rightStick.z = Input.GetAxis("Vertical2");

        if (Input.GetButton("square"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_SQUARE;
        }
        if (Input.GetButton("circle"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_CIRCLE;
        }
        if (Input.GetButton("triangle"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_TRI;
        }
        if (Input.GetButton("cross"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_CROSS;
        }
        if (Input.GetButton("L1"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_L1;
        }
        if (Input.GetButton("L2"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_L2;
        }
        if (Input.GetButton("R1"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_R1;
        }
        if (Input.GetButton("R2"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_R2;
        }
        Debug.Log(pad.leftStick);
        Debug.Log(pad.rightStick);
	}
	
	// Update is called once per frame
	void Update () {
        beforePad = pad;
        pad.leftStick.x = Input.GetAxis("Horizontal");
        pad.leftStick.y = 0.0f;
        pad.leftStick.z = Input.GetAxis("Vertical");
        Debug.Log(pad.leftStick);
        pad.rightStick.x = Input.GetAxis("Horizontal2");
        pad.rightStick.y = 0.0f;
        pad.rightStick.z = Input.GetAxis("Vertical2");

        pad.button_bit = 0;
        if (Input.GetButton("square"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_SQUARE;
        }
        if (Input.GetButton("circle"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_CIRCLE;
        }
        if (Input.GetButton("triangle"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_TRI;
        }
        if (Input.GetButton("cross"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_CROSS;
        }
        if (Input.GetButton("L1"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_L1;
        }
        pad.L2 = Input.GetAxis("L2");
        if (Input.GetButton("R1"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_R1;
        }
        
        pad.R2 = Input.GetAxis("R2");

        if (Input.GetAxis("UpDown") == 1.0f)
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_UP;
        }
        if (Input.GetAxis("UpDown") == -1.0f)
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_DOWN;
        }
        if (Input.GetAxis("LeftRight") == -1.0f)
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_LEFT;
        }
        if (Input.GetAxis("LeftRight") == 1.0f)
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_RIGHT;
        }
        if (Input.GetButton("R3"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_R3;
        }
        if (Input.GetButton("L3"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_L3;
        }
        if (Input.GetButton("Home"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_HOME;
        }
        if (Input.GetButton("Option"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_OPTION;
        }
        if (Input.GetButton("Share"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_SHARE;
        }
        if (Input.GetButton("TouchPad"))
        {
            pad.button_bit |= (uint)BUTTON_BIT.PAD_TOUCH;
        }

        Debug.Log("ButtonBit" + pad.button_bit);
        if((pad.button_bit & (uint)BUTTON_BIT.PAD_CROSS) != 0){
            Debug.Log("Press cross");
        }
        if ((pad.button_bit & (uint)BUTTON_BIT.PAD_L1) != 0)
        {
            Debug.Log("Press L1");
        }
	}

    public static bool IsPressButton(BUTTON_BIT bit)
    {
        if (0 != (pad.button_bit & (uint)bit))
        {
            return true;
        }
        return false;
    }

    public static bool IsOneShotButton(BUTTON_BIT bit)
    {
        if ((0 != (pad.button_bit & (uint)bit)) && ((0 == (beforePad.button_bit & (uint)bit))))
        {
            return true;
        }
        return false;
    }
}
