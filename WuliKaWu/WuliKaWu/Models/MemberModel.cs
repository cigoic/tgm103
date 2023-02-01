﻿using WuliKaWu.Data;

namespace WuliKaWu.Models
{
    public class MemberModel
    {
        public int MemberId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string? Name { get; internal set; }
        public MemberRole.RoleType Role { get; set; }
        public bool RememberMe { get; set; }
    }
}