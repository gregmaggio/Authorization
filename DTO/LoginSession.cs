//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginSession
    {
        public string SessionId { get; set; }
        public int UserId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime Expires { get; set; }
    
        public virtual User User { get; set; }
    }
}
