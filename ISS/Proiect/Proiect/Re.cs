namespace Proiect
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /**
     * class from entity
     * re is a table from database and it stores the details
     * of reservations
     */
    public partial class Re
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string nameP { get; set; }

        public int? places { get; set; }
    }
}
