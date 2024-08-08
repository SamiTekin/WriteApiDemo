namespace Entities.Exceptions
{
    public class PriceOutofRangeBadRequestException : BadRequestException
    {
        public PriceOutofRangeBadRequestException() : base("Fiyat aralığı 10 ve 200000 arasında olmalıdır")
        {
        }
    }
}
