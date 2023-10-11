using System.ComponentModel.DataAnnotations;

namespace DataClass.Enums
{
    public enum ChatroomeExceptionCode
    {
        /// <summary>
        /// 資料驗證失敗
        /// </summary>
        [Display(Name = "資料驗證失敗")]
        DataVerificationFailed = 0,

        /// <summary>
        /// 登入失敗
        /// </summary>
        [Display(Name = "登入失敗，帳號或密碼有誤")]
        LoginFail = 1
    }
}
