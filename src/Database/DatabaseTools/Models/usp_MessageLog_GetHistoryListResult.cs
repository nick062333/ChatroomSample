﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseTools.Models
{
    public partial class usp_MessageLog_GetHistoryListResult
    {
        public long Id { get; set; }
        public Guid GroupId { get; set; }
        public byte Status { get; set; }
        public string Message { get; set; }
        public long SendUserId { get; set; }
        public DateTime SendTime { get; set; }
        public string UserName { get; set; }
    }
}
