#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER

using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace uREPL
{

static class Input {
    public static bool GetKey(KeyCode key) {
        Key sKey = KeyCode2Key(key);
        return Keyboard.current[sKey].isPressed;
    }

    public static bool GetKeyDown(KeyCode key) {
        Key sKey = KeyCode2Key(key);
        return Keyboard.current[sKey].wasPressedThisFrame;
    }


    static Key KeyCode2Key(KeyCode keyCode) {
        return keyCode switch {
            KeyCode.A               => Key.A,
            KeyCode.B               => Key.B,
            KeyCode.C               => Key.C,
            KeyCode.D               => Key.D,
            KeyCode.E               => Key.E,
            KeyCode.F               => Key.F,
            KeyCode.G               => Key.G,
            KeyCode.H               => Key.H,
            KeyCode.I               => Key.I,
            KeyCode.J               => Key.J,
            KeyCode.K               => Key.K,
            KeyCode.L               => Key.L,
            KeyCode.M               => Key.M,
            KeyCode.N               => Key.N,
            KeyCode.O               => Key.O,
            KeyCode.P               => Key.P,
            KeyCode.Q               => Key.Q,
            KeyCode.R               => Key.R,
            KeyCode.S               => Key.S,
            KeyCode.T               => Key.T,
            KeyCode.U               => Key.U,
            KeyCode.V               => Key.V,
            KeyCode.W               => Key.W,
            KeyCode.X               => Key.X,
            KeyCode.Y               => Key.Y,
            KeyCode.Z               => Key.Z,

            KeyCode.Comma           => Key.Comma,
            KeyCode.Period          => Key.Period,
            KeyCode.Slash           => Key.Slash,
            KeyCode.Backslash       => Key.Backslash,
            KeyCode.LeftBracket     => Key.LeftBracket,
            KeyCode.RightBracket    => Key.RightBracket,
            KeyCode.Semicolon       => Key.Semicolon,
            KeyCode.Quote           => Key.Quote,
            KeyCode.BackQuote       => Key.Backquote,
            KeyCode.Minus           => Key.Minus,
            KeyCode.Equals          => Key.Equals,

            KeyCode.F1              => Key.F1,
            KeyCode.F2              => Key.F2,
            KeyCode.F3              => Key.F3,
            KeyCode.F4              => Key.F4,
            KeyCode.F5              => Key.F5,
            KeyCode.F6              => Key.F6,
            KeyCode.F7              => Key.F7,
            KeyCode.F8              => Key.F8,
            KeyCode.F9              => Key.F9,
            KeyCode.F10             => Key.F10,
            KeyCode.F11             => Key.F11,
            KeyCode.F12             => Key.F12,

            KeyCode.UpArrow         => Key.UpArrow,
            KeyCode.DownArrow       => Key.DownArrow,
            KeyCode.LeftArrow       => Key.LeftArrow,
            KeyCode.RightArrow      => Key.RightArrow,

            KeyCode.LeftShift       => Key.LeftShift,
            KeyCode.RightShift      => Key.RightShift,
            KeyCode.LeftAlt         => Key.LeftAlt,
            KeyCode.RightAlt        => Key.RightAlt,
            KeyCode.LeftControl     => Key.LeftCtrl,
            KeyCode.RightControl    => Key.RightCtrl,

            KeyCode.Space           => Key.Space,
            KeyCode.Return          => Key.Enter,
            KeyCode.KeypadEnter     => Key.NumpadEnter,
            KeyCode.Escape          => Key.Escape,
            KeyCode.Tab             => Key.Tab,
            KeyCode.Backspace       => Key.Backspace,
            KeyCode.Delete          => Key.Delete,

            _ => throw new ArgumentException($"Not Implemented Key : {keyCode}")
        };
    }
}

}

#endif
