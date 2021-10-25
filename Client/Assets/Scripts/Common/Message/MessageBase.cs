using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWLJ
{
    public interface IMessage
    {
        MessageType MessageType { get; }
    }

    public abstract class MessageBase : IMessage
    {
        protected MessageType _messageType;
        public MessageType MessageType => _messageType;
    }

    public class EnterGameMessage : MessageBase
    {
        public string name;
        public EnterGameMessage(string name)
        {
            this._messageType = MessageType.EnterGame;
            this.name = name;
        }
    }
    public class LoadSceneFinishedMessage : MessageBase
    {
        public string sceneName;
        public LoadSceneFinishedMessage(string sceneName)
        {
            this._messageType = MessageType.LoadSceneFinished;
            this.sceneName = sceneName;
        }
    }
}