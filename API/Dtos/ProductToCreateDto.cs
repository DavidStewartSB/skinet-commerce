namespace API.Dtos
{
    public class ProductToCreateDto
    {
        public string Name { get; set; }
        public string Descripton { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
    }
}