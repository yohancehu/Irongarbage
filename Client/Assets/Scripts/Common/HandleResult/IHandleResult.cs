using UnityEngine;

namespace SWLJ
{
    public interface IHandleResult
    {
    }
    public class HandleResultBase : IHandleResult
    {
        public string message;
        public bool success;
        public int errorCode;

        public void SetResult(int errorCode,string message,bool success)
        {
            this.message = message;
            this.success = success;
            this.errorCode = errorCode;
        }
    }
}
