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
    
    public partial class Table_Meaning
    {
        public int IdMeaning { get; set; }
        public Nullable<int> IdClothes { get; set; }
        public Nullable<int> IdShoes { get; set; }
        public int IdCharacteristic { get; set; }
        public string Meaning { get; set; }
    
        public virtual Table_Characteristic Table_Characteristic { get; set; }
        public virtual Table_Clothes Table_Clothes { get; set; }
        public virtual Table_Shoes Table_Shoes { get; set; }
    }
}
