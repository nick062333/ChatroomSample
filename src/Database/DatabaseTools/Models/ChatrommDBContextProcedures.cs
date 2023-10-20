﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using DatabaseTools.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseTools.Models
{
    public partial class ChatrommDBContext
    {
        private IChatrommDBContextProcedures _procedures;

        public virtual IChatrommDBContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new ChatrommDBContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IChatrommDBContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<usp_Chatroom_AddResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_ChatroomMember_AddResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_ChatroomMember_GetListResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_ChatroomMember_GetListByUserIdResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_MessageLog_GetHistoryListResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_MessageLog_GetHistoryListCountResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_MessageLog_GetNewMessageListResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_MessageLog_GetNewMessageListCountResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_MessageLog_GroupTotalCount_GetResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_MessageLog_InsertResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_User_GetResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_User_GetListResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<usp_User_InsertResult>().HasNoKey().ToView(null);
        }
    }

    public partial class ChatrommDBContextProcedures : IChatrommDBContextProcedures
    {
        private readonly ChatrommDBContext _context;

        public ChatrommDBContextProcedures(ChatrommDBContext context)
        {
            _context = context;
        }

        public virtual async Task<List<usp_Chatroom_AddResult>> usp_Chatroom_AddAsync(Guid? Id, byte? ChatroomType, DateTime? CreateTime, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Id",
                    Value = Id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                },
                new SqlParameter
                {
                    ParameterName = "ChatroomType",
                    Value = ChatroomType ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.TinyInt,
                },
                new SqlParameter
                {
                    ParameterName = "CreateTime",
                    Value = CreateTime ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_Chatroom_AddResult>("EXEC @returnValue = [dbo].[usp_Chatroom_Add] @Id, @ChatroomType, @CreateTime", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_ChatroomMember_AddResult>> usp_ChatroomMember_AddAsync(Guid? ChatroomId, long? UserId, DateTime? EntryTime, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ChatroomId",
                    Value = ChatroomId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                },
                new SqlParameter
                {
                    ParameterName = "UserId",
                    Value = UserId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.BigInt,
                },
                new SqlParameter
                {
                    ParameterName = "EntryTime",
                    Value = EntryTime ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_ChatroomMember_AddResult>("EXEC @returnValue = [dbo].[usp_ChatroomMember_Add] @ChatroomId, @UserId, @EntryTime", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_ChatroomMember_GetListResult>> usp_ChatroomMember_GetListAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_ChatroomMember_GetListResult>("EXEC @returnValue = [dbo].[usp_ChatroomMember_GetList]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_ChatroomMember_GetListByUserIdResult>> usp_ChatroomMember_GetListByUserIdAsync(long? UesrId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "UesrId",
                    Value = UesrId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.BigInt,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_ChatroomMember_GetListByUserIdResult>("EXEC @returnValue = [dbo].[usp_ChatroomMember_GetListByUserId] @UesrId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_MessageLog_GetHistoryListResult>> usp_MessageLog_GetHistoryListAsync(Guid? GroupId, long? EndMessageId, int? PageNumber, int? PageSize, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "GroupId",
                    Value = GroupId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                },
                new SqlParameter
                {
                    ParameterName = "EndMessageId",
                    Value = EndMessageId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.BigInt,
                },
                new SqlParameter
                {
                    ParameterName = "PageNumber",
                    Value = PageNumber ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "PageSize",
                    Value = PageSize ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_MessageLog_GetHistoryListResult>("EXEC @returnValue = [dbo].[usp_MessageLog_GetHistoryList] @GroupId, @EndMessageId, @PageNumber, @PageSize", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_MessageLog_GetHistoryListCountResult>> usp_MessageLog_GetHistoryListCountAsync(Guid? GroupId, int? EndMessageId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "GroupId",
                    Value = GroupId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                },
                new SqlParameter
                {
                    ParameterName = "EndMessageId",
                    Value = EndMessageId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_MessageLog_GetHistoryListCountResult>("EXEC @returnValue = [dbo].[usp_MessageLog_GetHistoryListCount] @GroupId, @EndMessageId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_MessageLog_GetNewMessageListResult>> usp_MessageLog_GetNewMessageListAsync(Guid? GroupId, long? StartId, int? PageNumber, int? PageSize, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "GroupId",
                    Value = GroupId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                },
                new SqlParameter
                {
                    ParameterName = "StartId",
                    Value = StartId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.BigInt,
                },
                new SqlParameter
                {
                    ParameterName = "PageNumber",
                    Value = PageNumber ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "PageSize",
                    Value = PageSize ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_MessageLog_GetNewMessageListResult>("EXEC @returnValue = [dbo].[usp_MessageLog_GetNewMessageList] @GroupId, @StartId, @PageNumber, @PageSize", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_MessageLog_GetNewMessageListCountResult>> usp_MessageLog_GetNewMessageListCountAsync(Guid? GroupId, int? StartId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "GroupId",
                    Value = GroupId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                },
                new SqlParameter
                {
                    ParameterName = "StartId",
                    Value = StartId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_MessageLog_GetNewMessageListCountResult>("EXEC @returnValue = [dbo].[usp_MessageLog_GetNewMessageListCount] @GroupId, @StartId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_MessageLog_GroupTotalCount_GetResult>> usp_MessageLog_GroupTotalCount_GetAsync(Guid? GroupId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "GroupId",
                    Value = GroupId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_MessageLog_GroupTotalCount_GetResult>("EXEC @returnValue = [dbo].[usp_MessageLog_GroupTotalCount_Get] @GroupId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_MessageLog_InsertResult>> usp_MessageLog_InsertAsync(Guid? GroupId, long? SendUserId, string Message, DateTime? SendTime, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "GroupId",
                    Value = GroupId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                },
                new SqlParameter
                {
                    ParameterName = "SendUserId",
                    Value = SendUserId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.BigInt,
                },
                new SqlParameter
                {
                    ParameterName = "Message",
                    Size = 0,
                    Value = Message ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "SendTime",
                    Value = SendTime ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_MessageLog_InsertResult>("EXEC @returnValue = [dbo].[usp_MessageLog_Insert] @GroupId, @SendUserId, @Message, @SendTime", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_User_GetResult>> usp_User_GetAsync(string Account, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Account",
                    Size = 20,
                    Value = Account ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_User_GetResult>("EXEC @returnValue = [dbo].[usp_User_Get] @Account", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_User_GetListResult>> usp_User_GetListAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_User_GetListResult>("EXEC @returnValue = [dbo].[usp_User_GetList]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<usp_User_InsertResult>> usp_User_InsertAsync(string Account, string Password, string UserName, DateTime? CreateTime, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = returnValue?._value,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Account",
                    Size = 20,
                    Value = Account ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Password",
                    Size = 64,
                    Value = Password ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                new SqlParameter
                {
                    ParameterName = "UserName",
                    Size = 20,
                    Value = UserName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "CreateTime",
                    Value = CreateTime ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<usp_User_InsertResult>("EXEC @returnValue = [dbo].[usp_User_Insert] @Account, @Password, @UserName, @CreateTime", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}