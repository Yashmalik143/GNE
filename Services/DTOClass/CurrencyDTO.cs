namespace Services.DTOClass
{
    public class CurrencyDTO
    {

        public int Id { get; set; }
        public string CurrencyCode { get; set; } = null!;

        public string CurrencyName { get; set; } = null!;

        public string Symbol { get; set; } = null!;
    } 
}
