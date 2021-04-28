using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace BakTraCam.Common.Helper.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescription(this Enum en)
        {
            if (en == null)
                return null;

            var type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
                return en.ToString();
            }

            return null;
        }
    }
}
