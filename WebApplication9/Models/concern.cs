//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class concern
    {
        public int concern_id { get; set; }
        public Nullable<int> follower_id { get; set; }
        public Nullable<int> concerned_id { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
        public virtual UserInfo UserInfo1 { get; set; }
    }
}
