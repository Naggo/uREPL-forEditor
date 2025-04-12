using UnityEngine;
using System.Collections.Generic;

namespace uREPL
{

public static class KeyUtil
{
    public static bool Shift()
    {
        return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    public static bool Alt()
    {
        return Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
    }

    public static bool Control()
    {
        return Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
    }

    public static bool ControlOrShift()
    {
        return Control() || Shift();
    }

    public static bool Enter()
    {
        return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter);
    }
}


public class KeyEvent
{
    private const float holdInputStartDelay = 30f / 60;
    private const float holdInputFrameInterval = 5f / 60;

    public enum Option { None, Ctrl, Shift, Alt, CtrlOrShift };

    public delegate void KeyEventHandler();
    class EventInfo
    {
        public KeyCode key;
        public Option option;
        public int counter;
        public float timer;
        public System.Action onKeyEvent;
        public EventInfo(KeyCode key, Option option, System.Action onKeyEvent)
        {
            this.key = key;
            this.option = option;
            this.counter = 0;
            this.timer = 0;
            this.onKeyEvent = onKeyEvent;
        }
    }
    private List<EventInfo> keyEventList_ = new List<EventInfo>();

    public void Add(KeyCode code, Option option, System.Action onKeyEvent)
    {
        keyEventList_.Add(new EventInfo(code, option, onKeyEvent));
    }

    public void Add(KeyCode code, System.Action onKeyEvent)
    {
        Add(code, Option.None, onKeyEvent);
    }

    public void Check()
    {
        foreach (var info in keyEventList_) {
            if (CheckKey(info)) info.onKeyEvent();
        }
    }

    private bool CheckKey(EventInfo info)
    {
        bool option = false;
        switch (info.option) {
            case Option.None        : option = true;                     break;
            case Option.Ctrl        : option = KeyUtil.Control();        break;
            case Option.Shift       : option = KeyUtil.Shift();          break;
            case Option.Alt         : option = KeyUtil.Alt();            break;
            case Option.CtrlOrShift : option = KeyUtil.ControlOrShift(); break;
        }

        bool holdFlag = false;
        if (Input.GetKey(info.key) && option) {
            ++info.counter;
            info.timer += Time.deltaTime;
            if (info.timer >= holdInputStartDelay) {
                holdFlag = true;
                info.timer -= holdInputFrameInterval;
            }
        } else {
            info.counter = 0;
            info.timer = 0;
        }

        return info.counter == 1 || holdFlag;
    }

    public void Clear()
    {
        foreach (var info in keyEventList_) {
            info.counter = 0;
            info.timer = 0;
        }
    }
}

}
