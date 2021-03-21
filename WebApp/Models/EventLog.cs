namespace WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("EventLog")]
    public partial class EventLog
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50), DisplayName("Action")]
        public string vAction { get; set; }

        [StringLength(200), DisplayName("Input")]
        public string vInput { get; set; }

        [StringLength(200), DisplayName("Output")]
        public string vOutput { get; set; }

        [DisplayName("Result")]
        public int? iResult { get; set; }

        [DisplayName("Timestamp (UTC)")]
        public DateTime? dProcessTimestamp { get; set; }

        [DisplayName("Client")]
        [StringLength(100)]
        public string vClientInfo { get; set; }
    }
}
