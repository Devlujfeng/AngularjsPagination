//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserLogin
    {
        public string LoginID { get; set; }
        public string LoginType { get; set; }
        public string UserType { get; set; }
        public string RoleID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string PW { get; set; }
        public string PW1 { get; set; }
        public string PW2 { get; set; }
        public string PW3 { get; set; }
        public string ActivationKey { get; set; }
        public Nullable<System.DateTime> AccountExpiryDate { get; set; }
        public Nullable<short> FailedLoginCount { get; set; }
        public Nullable<short> IsLocked { get; set; }
        public Nullable<short> ForcedChangePassword { get; set; }
        public string PasswordExpiryDate { get; set; }
        public Nullable<short> IsPermanentAccount { get; set; }
        public Nullable<short> CanByPassPWExpiry { get; set; }
        public Nullable<short> UnlimitedLoginAttempt { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<short> IsActive { get; set; }
        public string ShopID { get; set; }
        public Nullable<long> TeamID { get; set; }
        public Nullable<long> DepartmentID { get; set; }
    }
}
