namespace ContactList.Server.Models
{
    public class CallLog
    {
        public int CallLogId { get; set; }
        public DateTime CallTime { get; set; }
        public string Outcome { get; set; }
        public string Notes { get; set; }


        // Foreign Key
        public int CustomerId { get; set; }

        // Navigation property
        public Customer Customer { get; set; }
    }

}
