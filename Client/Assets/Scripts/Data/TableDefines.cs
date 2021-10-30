

using SWLJ;
using System.Collections.Generic;

namespace TableDefines
{
    public class dialogconfig : TableSrc
    {
        public string id;
        public int nextId;
        public string content;
        public int speakerId;
        public int triggerType;
        public int triggerId;
        public string triggerParam;
        public List<Branch> branch;
        

        public class Branch
        {
            public string description;
            public int triggerType;
            public int triggerId;
            public string triggerParam;
        }
    }
    public class unitconfig : TableSrc
    {
        public string id;
        public string name;
        public string picture;
    }
    public class uiconfig : TableSrc
    {
        public string id;
        public int type;
        public string className;
        public string prefab;
        public int layer;
    }
}
