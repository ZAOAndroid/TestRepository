//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTestProject2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contacts
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public long CardId { get; set; }
        public int ContactTypeId { get; set; }
        public Nullable<int> isDeleted { get; set; }
    
        public virtual Cards Cards { get; set; }
        public virtual ContactType ContactType { get; set; }
    }
}
