using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adapter.Models;

namespace Adapter.Interfaces
{
    public interface IChatroomMemberAdapter
    {
        Task AddChatroomMemberAsync(ChatroomMember chatroomMember);
    }
}