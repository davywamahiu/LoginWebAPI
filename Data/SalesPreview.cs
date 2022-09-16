namespace LoginWebAPI.Data
{
    public partial class SalesPreview
    {
        public int Id { get; set; }
        public string Driver { get; set; } = null!;
        public long Phone { get; set; }
        public string Plate { get; set; } = null!;
        public string Material { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string Time { get; set; }
        public int Ticket { get; set; }
        public double SWeight { get; set; }
        public double Weight { get; set; }
        public string AccountNo { get; set; }
        public double Balance { get; set; }
        public double Amount { get; set; }
        public double SpentAmount { get; set; }
    }
}
