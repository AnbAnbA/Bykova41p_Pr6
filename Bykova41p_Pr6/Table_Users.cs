//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bykova41p_Pr6
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_Users
    {
        public int IdUsers { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime DateBirthday { get; set; }
        public int IdGender { get; set; }
        public string Login { get; set; }
        public int Pssword { get; set; }
        public int IdRole { get; set; }
    
        public virtual Table_Gender Table_Gender { get; set; }
        public virtual Table_Role Table_Role { get; set; }
    }
}
