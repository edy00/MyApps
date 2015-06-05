namespace Proiect
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /**
     * Class generated from entity 
     * play is a table from the database
     */


    [Table("Play")]
    public partial class play
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string nameP { get; set; }

        [StringLength(10)]
        public string data { get; set; }

        public int? L { get; set; }

        public int? ocp { get; set; }
    }
}
