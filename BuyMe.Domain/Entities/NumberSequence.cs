namespace BuyMe.Domain.Entities
{
    public class NumberSequence
    {
        public int NumberSequenceId { get; set; }
        public string NumberSequenceName { get; set; }
        public string Module { get; set; }
        public string Prefix { get; set; }
        public int LastNumber { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}