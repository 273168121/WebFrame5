﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
namespace CH.Common
{
    public class DynamicParameters:DynamicObject
    {
        public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
        {
            if (map != null)
            {
                string name = binder.Name;
                object value;
                if (map.TryGetValue(name, out value))
                {
                    result = value;
                    return true;
                }
            }
            return base.TryGetMember(binder, out result);
        }

       public System.Collections.Generic.Dictionary<string, object> map;

        public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name == "set" && binder.CallInfo.ArgumentCount == 2)
            {
                string name = args[0] as string;
                if (name == null)
                {
                    //throw new ArgumentException("name");
                    result = null;
                    return false;
                }
                if (map == null)
                {
                    map = new System.Collections.Generic.Dictionary<string, object>();
                }
                object value = args[1];
                map.Add(name, value);
                result = value;
                return true;

            }
            return base.TryInvokeMember(binder, args, out result);
        }
    }
}
