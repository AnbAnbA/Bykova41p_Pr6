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
    
    public partial class Table_Nomenclature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_Nomenclature()
        {
            this.Table_Meaning = new HashSet<Table_Meaning>();
            this.Table_Products = new HashSet<Table_Products>();
        }
    
        public int idNomenclature { get; set; }
        public string NameNom { get; set; }
        public decimal PriceNom { get; set; }
        public string ImageNom { get; set; }
        public int idGenderNom { get; set; }
        public int idMeaningNom { get; set; }
        public int vidNom { get; set; }
    
        public virtual Table_Gender Table_Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_Meaning> Table_Meaning { get; set; }
        public virtual Table_VidNom Table_VidNom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_Products> Table_Products { get; set; }
    }
}