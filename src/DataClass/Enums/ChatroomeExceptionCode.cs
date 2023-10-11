using System.ComponentModel.DataAnnotations;

namespace DataClass.Enums
{
    public enum ChatroomeExceptionCode
    {
        /// <summary>
        /// 資料驗證失敗
        /// </summary>
        [Display(Name = "資料驗證失敗")]
        DataVerificationFailed = 0
    }
}
