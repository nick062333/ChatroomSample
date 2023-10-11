using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Utility.Extensions
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            // 使用Reflection獲取枚舉字段
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString())!;

            // 檢查是否存在DisplayName屬性
            if (fieldInfo != null)
            {
                var displayNameAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();
                if (displayNameAttribute != null)
                    return displayNameAttribute.Name ?? string.Empty;
            }

            return enumValue.ToString();
        } 
    }
}