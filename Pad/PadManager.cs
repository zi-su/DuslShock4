using UnityEngine;
using System.Collections;

public class PadManager : MonoBehaviour {

    public enum BUTTON_BIT{
        PAD_LEFT    = 0x01 << 1,
        PAD_RIGHT   = 0x01 << 2,
        PAD_UP      = 0x01 << 3,
        PAD_DOWN    = 0x01 << 4,
        PAD_SQUARE  = 0x01 << 5,
        PAD_TRI     = 0x01 << 6,
        PAD_CROSS   = 0x01 << 7,
        PAD_CIRCLE  = 0x01 << 8,
        PAD_L1      = 0x01 << 9,
        PAD_L2      = 0x01 << 10,
        PAD_R1      = 0x01 << 11,
        PAD_R2      = 0x01 << 12,
        PAD_SELECT  = 0x01 << 13,
        PAD_START   = 0x01 << 14,
        PAD_R3      = 0x01 << 15,
        PAD_L3      = 0x01 << 16,
        PAD_HOME    = 0x01 << 17,
        PAD_OPTION  = 0x01 << 18,
        PAD_SHARE   = 0x01 << 19,
        PAD_TOUCH   = 0x01 << 20,
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
    private static PadInfo pad;
    private static PadInfo beforePad;
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

	}
	
	// Update is called once per frame
	void Update () {
        beforePad = pad;
        pad.leftStick.x = Input.GetAxis("Horizontal") * -1.0f;
        pad.leftStick.y = 0.0f;
        pad.leftStick.z = Input.GetAxis("Vertical");
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

    public static Vector3 GetLeftStick()
    {
        return pad.leftStick;
    }

    public static Vector3 GetRightStick()
    {
        return pad.rightStick;
    }
}
