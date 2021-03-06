﻿using FriendOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public interface IFriendLookupDataService
    {
        Task<List<LookupItem>> GetFriendLookupAsync();
    }
}