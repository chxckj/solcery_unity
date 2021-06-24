using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using Solcery.Utils;
using Solcery.UI.Create;

namespace Solcery.WebGL
{
    public class UnityToReact : Singleton<UnityToReact>
    {
        [DllImport("__Internal")] private static extern void LogToConsole(string message);
        [DllImport("__Internal")] private static extern void OpenLinkInNewTab(string link);
        [DllImport("__Internal")] private static extern void OnUnityLoaded(string message);
        [DllImport("__Internal")] private static extern void CreateCard(string card, string cardName);
        [DllImport("__Internal")] private static extern void CreateBoard();
        [DllImport("__Internal")] private static extern void JoinBoard(string gameKey);
        [DllImport("__Internal")] private static extern void UseCard(string cardMintAddress, int card);


        public void CallLogToConsole(string message)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    LogToConsole (message);
#endif
        }

        public void CallOpenLinkInNewTab(string link)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    OpenLinkInNewTab (link);
#endif
        }

        public void CallOnUnityLoaded()
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    OnUnityLoaded ("message");
#endif
        }

        public void CallCreateBoard()
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    CreateBoard();
#endif
        }

        public void CallJoinBoard(string gameKey)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    JoinBoard(gameKey);
#endif
        }

        public void CallUseCard(string cardMintAddress, int cardIndex)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    UseCard(cardMintAddress, cardIndex);
#endif
        }

        public void CallCreateCard()
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
            List<byte> buffer = new List<byte>();
            UICreate.Instance.NodeEditor.BrickTree.SerializeToBytes(ref buffer);
            string buf = String.Join("|", buffer.ToArray());
            CreateCard(buf, UICreate.Instance.NodeEditor.BrickTree.MetaData.Name);
#endif
        }
    }
}
