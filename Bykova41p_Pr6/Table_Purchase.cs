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
    
    public partial class Table_Purchase
    {
        public int IdPurchase { get; set; }
        public int IdCustomer { get; set; }
        public int IdClothes { get; set; }
        public int IdShoes { get; set; }
        public int AmountPurchase { get; set; }
        public System.DateTime DatePurchase { get; set; }
        public decimal TotalPurchase { get; set; }
    
        public virtual Table_Clothes Table_Clothes { get; set; }
        public virtual Table_Customer Table_Customer { get; set; }
        public virtual Table_Shoes Table_Shoes { get; set; }
    }
}
