﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DatabaseTools.Models;

public partial class User
{
    public long Id { get; set; }

    public string Account { get; set; }

    public string Password { get; set; }

    public string UserName { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime? LastLoginTime { get; set; }
}