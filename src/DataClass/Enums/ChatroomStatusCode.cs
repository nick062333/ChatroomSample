﻿using System.ComponentModel.DataAnnotations;

namespace DataClass.Enums
{
    public enum ChatroomStatusCode
    {
        [Display(Name = "成功")]
        Success = 200,

        [Display(Name = "伺服器異常")]
        ServiceError = 500,

        [Display(Name = "資料驗證失敗")]
        DataVerificationFailed = 501,

        [Display(Name = "登入失敗，帳號或密碼有誤")]
        LoginFail = 502,
    }
}
